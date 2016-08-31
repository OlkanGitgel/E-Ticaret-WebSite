using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for AlisVeris
/// </summary>
public class AlisVeris
{
    public AlisVeris()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    static DataAccessLayer db = new DataAccessLayer();
    public static void SepeteAt(object s, CommandEventArgs e, string urunID)
    {
        string id = urunID;
        List<Parametreler> liste = new List<Parametreler>();
        liste.Add(new Parametreler { Name = "@id", Value = id });
        //hangi üründen alınacağını biliyoruz.

        DataRow satir = db.GetDataRow("SELECT  dbo.Fotograflar.FotoYol, dbo.Urunler.* FROM   dbo.Fotograflar right JOIN  dbo.Urunler ON dbo.Fotograflar.UrunId = dbo.Urunler.UrunID  where Urunler.UrunId = @id and (FotoVitrin=1 or FotoVitrin is null)", liste);
        //ürüne ait tüm bilgileri aktaralım
        int adet = 1;
        string urunAdi = satir["UrunAdi"].ToString();
        double fiyat = Convert.ToDouble(string.Format("{0:0.00}", satir["SonFiyat"].ToString()));//virgünden sonra 2 basamak için

        //sepette gösterilecek bilgiler hazır


        DataTable dt = new DataTable();//ürün bilgilerini saklasın

        if (HttpContext.Current.Session["sepet"] != null)//sepete daha önce 1 ürün atılmışsa
        {
            dt = (DataTable)HttpContext.Current.Session["sepet"];//önceki eklenen ürün bilgilerini dt ye yükle
        }
        else//sepete ilk ürünün eklenmesi
        {
            dt.Columns.Add("id");
            dt.Columns.Add("isim");
            dt.Columns.Add("fiyat");
            dt.Columns.Add("adet");
            dt.Columns.Add("tutar");//her ürüne ait tutar.
            dt.Columns.Add("yol");
        }

        bool urunSepetteMi = Kontrol(id);//ürünün daha önce eklenip eklenmediğini kontrol et

        //eğer ürün sepetteyse arttırma yapılmalı

        if (urunSepetteMi)//true is
        {
            Arttir(id, adet);
        }
        else
        {
            DataRow row = dt.NewRow();
            row["id"] = urunID;
            row["isim"] = urunAdi;
            row["fiyat"] = fiyat;
            row["adet"] = adet;
            row["tutar"] = adet * fiyat;
            row["yol"] = satir["FotoYol"];
            dt.Rows.Add(row);
        }
        Listele();
        HttpContext.Current.Session["sepet"] = dt;//ürün ilk kez ekleniyor ya da var olanın sayısı arttırılıyorsa bile her durumda session son bilgileri saklamalı.
       
    }

    private static void Arttir(string id, int adet)
    {
        DataTable dt = new DataTable();
        if (HttpContext.Current.Session["sepet"] != null)
        {
            dt = (DataTable)HttpContext.Current.Session["sepet"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["id"].ToString() == id)
                {
                    int urunAdedi = Convert.ToInt32(dt.Rows[i]["adet"]);
                    urunAdedi += adet;
                    dt.Rows[i]["adet"] = urunAdedi;
                    dt.Rows[i]["tutar"] = urunAdedi * Convert.ToDouble(dt.Rows[i]["fiyat"]);
                    HttpContext.Current.Session["sepet"] = dt;//güncellenmiş bilgiler session atılsın
                    break;
                }
            }
        }
    }

    public static DataTable IslemYap(object s, CommandEventArgs e, string yeniMiktar)
    {
        DataTable dtSession = (DataTable)HttpContext.Current.Session["sepet"];
        if (e.CommandName == "sil")
        {
            for (int i = 0; i < dtSession.Rows.Count; i++)
            {
                if (dtSession.Rows[i]["id"].ToString() == e.CommandArgument.ToString())
                {
                    dtSession.Rows.RemoveAt(i);
                    break;
                }
            }
            HttpContext.Current.Session["sepet"] = dtSession;
            //silinen ürün session dan da kaldırılsın ki kullanıcı başka sayfaya gidip tekrar sepete döndüğünde sildiği ürünü görmesin.
           
        }
        else if (e.CommandName == "guncelle")
        {
            string[] dizi = yeniMiktar.Split(',');
            ArrayList arr = new ArrayList();
            for (int i = 0; i < dizi.Length; i++)
            {
                if (dizi[i].ToString()!=",")
                {
                    arr.Add(dizi[i]);
                }
            }
            for (int i = 0; i < dtSession.Rows.Count; i++)
            {
                if (dtSession.Rows[i]["id"].ToString() == e.CommandArgument.ToString())
                {
                    dtSession.Rows[i]["adet"] =arr[i];
                    dtSession.Rows[i]["tutar"] = Convert.ToInt32(dtSession.Rows[i]["adet"]) * Convert.ToDouble(dtSession.Rows[i]["fiyat"]);
                    break;
                }
            }
            HttpContext.Current.Session["sepet"] = dtSession;
        }
        Listele();
        return dtSession;
    }

    private static bool Kontrol(string id)
    {
        DataTable dt = new DataTable();
        bool onay = false;
        if (HttpContext.Current.Session["sepet"] != null)
        {
            dt = (DataTable)HttpContext.Current.Session["sepet"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["id"].ToString() == id)
                {
                    onay = true;
                    break;//diğer ürünlerin id bilgisi aynı olamayacağı için eşleşme durumundan hemen sonra diğer id leri kontrol etmesin.
                }
            }
            return onay;//ürün var
        }
        else
            return onay;//ürün yok
    }

    //kaç adet ürün alındı ve toplam tutar nedir?
    public static void Listele()
    {
        double tutar=0;
        if (HttpContext.Current.Session["sepet"]!=null)
        {
            DataTable dt = (DataTable)HttpContext.Current.Session["sepet"];
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tutar += Convert.ToDouble(dt.Rows[i]["tutar"]);
            }
        }

        genelToplam= string.Format("₺{0}", tutar);
    }
    public static string genelToplam;
}