using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MNG_UrunEkleme : System.Web.UI.Page
{
    DataAccessLayer db = new DataAccessLayer();
    string kategori = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            kategori = Request.QueryString["id"];
            KategoriListesi();
            ddlKategori.SelectedValue = kategori;
            MarkaListesi();
        }
    }

    void KategoriListesi()
    {
        //tüm kategoriler gelecek
        ddlKategori.DataValueField = "KategoriID";
        ddlKategori.DataTextField = "KategoriAdi";
        ddlKategori.DataSource = db.GetDataTable("select * from Kategoriler order by KategoriAdi");
        ddlKategori.DataBind();
    }

    void MarkaListesi()
    {
        List<Parametreler> liste = new List<Parametreler>();
        liste.Add(
            new Parametreler { Name = "@id", Value = ddlKategori.SelectedValue }
            );

        ddlMarka.DataTextField = "MarkaAdi";
        ddlMarka.DataValueField = "MarkaID";
        ddlMarka.DataSource = db.GetDataTable("select * from Markalar where MarkaID in(select MarkaId from KategoriMarka where kategoriId =@id)", liste);
        ddlMarka.DataBind();
    }
    protected void ddlKategori_SelectedIndexChanged(object sender, EventArgs e)
    {
        MarkaListesi();
    }
    protected void btnEkle_Click(object sender, EventArgs e)
    {
        int oran;
        int.TryParse(txtOran.Text, out oran);//txtOran dönüştürülebilir bir değere sahipse OK, boş bırakılmış veya dönüştürülemezse oran 0 kabul edilir.

        List<Parametreler> liste = new List<Parametreler>();
        liste.Add(new Parametreler { Name = "@kat", Value = ddlKategori.SelectedValue });
        liste.Add(new Parametreler { Name = "@marka", Value = ddlMarka.SelectedValue });
        liste.Add(new Parametreler { Name = "@ad", Value = txtAd.Text });
        liste.Add(new Parametreler { Name = "@stok", Value = txtStok.Text });//stok fiyat vs. gibi alanların sayısallığından emin olmak gerek

        liste.Add(new Parametreler { Name = "@indirim", Value = oran });

        double sonFiyat, fiyat;
        double.TryParse(db.ToCurrencyCode(txtFiyat.Text), out fiyat);
        sonFiyat = fiyat - (fiyat * oran / 100);


        liste.Add(new Parametreler { Name = "@fiyat", Value = fiyat });
        liste.Add(new Parametreler { Name = "@son", Value = sonFiyat });
        liste.Add(new Parametreler { Name = "@detay", Value = txtDetay.Text });
        liste.Add(new Parametreler { Name = "@aktif", Value = chkAktif.Checked });
        liste.Add(new Parametreler { Name = "@vitrin", Value = chkVitrin.Checked });

        db.RunASqlStatement("insert Urunler values(@kat,@marka,@ad,@stok,@fiyat,@indirim,@son,@detay,@aktif,@vitrin)", liste);
    }
}