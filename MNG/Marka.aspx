<%@ Page Title="" Language="C#" MasterPageFile="~/MNG/MNG.master" AutoEventWireup="true" CodeFile="Marka.aspx.cs" Inherits="MNG_Marka" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">

    <table class="nav-justified">
        <tr>
            <td style="width: 211px">Marka</td>
            <td>
                <asp:TextBox ID="txtMarka" runat="server" Width="346px"></asp:TextBox></td>
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

