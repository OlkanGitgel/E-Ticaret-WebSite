<%@ Page Title="" Language="C#" MasterPageFile="~/MNG/MNG.master" AutoEventWireup="true" CodeFile="Kategori.aspx.cs" Inherits="MNG_Kategori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <form id="form1" runat="server">

    <table class="nav-justified">
        <tr>
            <td style="width: 211px">Kategori</td>
            <td>
                <asp:TextBox ID="txtKategori" runat="server" Width="346px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 211px">&nbsp;</td>
            <td>
                <asp:Button ID="btnEkle" runat="server" Text="EKLE" OnClick="btnEkle_Click" />
            </td>
        </tr>
    </table>

    </form>

</asp:Content>

