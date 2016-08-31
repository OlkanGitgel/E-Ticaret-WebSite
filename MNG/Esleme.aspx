<%@ Page Title="" Language="C#" MasterPageFile="~/MNG/MNG.master" AutoEventWireup="true" CodeFile="Esleme.aspx.cs" Inherits="MNG_Esleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="frm" runat="server">
        <table class="nav-justified">
            <tr>
                <td>
                    <asp:DropDownList ID="ddlKategori" runat="server" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ddlKategori_SelectedIndexChanged"></asp:DropDownList></td>
                <td>
                    <asp:DropDownList ID="ddlMarka" runat="server" Width="250px"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnEslestir" runat="server" Text="EŞLE" OnClick="btnEslestir_Click" /></td>
            </tr>
        </table>
    </form>
</asp:Content>

