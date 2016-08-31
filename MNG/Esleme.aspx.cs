using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MNG_Esleme : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            KategoriListesi();
            MarkaListesi();
        }
    }
    DataAccessLayer db = new DataAccessLayer();
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
            new Parametreler{ Name="@id", Value=ddlKategori.SelectedValue}
            );
        
        ddlMarka.DataTextField="MarkaAdi";
        ddlMarka.DataValueField="MarkaID";
        ddlMarka.DataSource = db.GetDataTable("select * from Markalar where MarkaID not in(select MarkaId from KategoriMarka where kategoriId =@id)", liste);
        ddlMarka.DataBind();
    }
    protected void ddlKategori_SelectedIndexChanged(object sender, EventArgs e)
    {
        MarkaListesi();
    }
    protected void btnEslestir_Click(object sender, EventArgs e)
    {
        List<Parametreler> liste = new List<Parametreler>();
        liste.Add(new Parametreler { Name = "@kat", Value = ddlKategori.SelectedValue });
        liste.Add(new Parametreler { Name = "@marka", Value = ddlMarka.SelectedValue });

        db.RunASqlStatement("insert KategoriMarka values(@kat, @marka)", liste);

        //sayfa postback olacak ancak Kategori ddl si değer değiştirmediği veya !ispostback durumu sağlanmadığından MarkaListesi tekrar çağırılmalı.
        MarkaListesi();
    }
}                            