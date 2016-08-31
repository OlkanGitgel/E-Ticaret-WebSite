<%@ Page Title="" Language="C#" MasterPageFile="~/MNG/MNG.master" AutoEventWireup="true" CodeFile="UrunEkleme.aspx.cs" Inherits="MNG_UrunEkleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="frm" runat="server">
    <table class="nav-justified">
        <tr>
            <td>Kategori:</td>
            <td>
                <asp:DropDownList ID="ddlKategori" Width="250px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlKategori_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Marka:</td>
            <td><asp:DropDownList ID="ddlMarka" Width="250px" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Ürün Adı:</td>
            <td>
                <asp:TextBox ID="txtAd" Width="250px" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Stok:</td>
            <td><asp:TextBox ID="txtStok" Width="250px" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Fiyat:</td>
            <td><asp:TextBox ID="txtFiyat" Width="250px" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFiyat" ErrorMessage="Ürün fiyatı girilmedi."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>İndirim Oranı (%):</td>
            <td><asp:TextBox ID="txtOran" Width="250px" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Detay:</td>
            <td><asp:TextBox ID="txtDetay" TextMode="MultiLine" Width="250px" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Aktif:</td>
            <td>
                <asp:CheckBox ID="chkAktif" runat="server" /></td>
        </tr>
        <tr>
            <td>Vitrin:</td>
            <td><asp:CheckBox ID="chkVitrin" runat="server" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnEkle" runat="server" Text="EKLE" OnClick="btnEkle_Click" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </form>
</asp:Content>

