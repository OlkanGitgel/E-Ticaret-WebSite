<%@ Page Title="" Language="C#" MasterPageFile="~/MNG/MNG.master" AutoEventWireup="true" CodeFile="ResimEkle.aspx.cs" Inherits="MNG_ResimEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="frm" runat="server">
        <table style="width: 100%; border: 1px solid #000000">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblUrun" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 248px">Resim Sayısı:</td>
                <td>
                    <asp:Label ID="lblSayi" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 248px">Uyarı:</td>
                <td>
                    <asp:Label ID="lblVitrin" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 248px">Resim:</td>
                <td>
                    <asp:FileUpload ID="fu" runat="server" /></td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 248px">Vitrin Resmi:</td>
                <td>
                    <asp:CheckBox ID="chkVitrin" runat="server" /></td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 248px"></td>
                <td>
                    <asp:Button ID="btnEkle" runat="server" Text="EKLE" OnClick="btnEkle_Click" /></td>
            </tr>
        </table>
    </form>
</asp:Content>

