using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FirsatUrunleri();
        SonEklenenler();
        AlisVeris.Listele();
    }
    DataAccessLayer db = new DataAccessLayer();
    void FirsatUrunleri()
    {
        rpFirsat.DataSource = db.GetDataTable("SELECT  top 2    dbo.Urunler.UrunID, dbo.Urunler.UrunAdi, dbo.Urunler.Fiyat, dbo.Urunler.SonFiyat, dbo.Fotograflar.FotoYol FROM dbo.Fotograflar INNER JOIN                         dbo.Urunler ON dbo.Fotograflar.UrunId = dbo.Urunler.UrunID						 where IndirimOrani>10 and FotoVitrin=1 order by newid()");
        rpFirsat.DataBind();
    }

    void SonEklenenler()
    {
        rpLatest.DataSource = db.GetDataTable("SELECT top 5 dbo.Urunler.UrunID, dbo.Urunler.UrunAdi, dbo.Urunler.Fiyat, dbo.Urunler.SonFiyat, dbo.Fotograflar.FotoYol FROM dbo.Fotograflar INNER JOIN dbo.Urunler ON dbo.Fotograflar.UrunId = dbo.Urunler.UrunID where  FotoVitrin=1 order by UrunId desc");
        rpLatest.DataBind();
    }
}
