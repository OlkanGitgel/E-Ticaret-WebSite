<%@ Page Title="" Language="C#" MasterPageFile="~/MNG/MNG.master" AutoEventWireup="true" CodeFile="UrunListesi.aspx.cs" Inherits="MNG_UrunListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="FRM" runat="server">
        <table class="nav-justified">
            <asp:DataList ID="dlUrun" runat="server" Width="100%">
                <ItemTemplate>
                    <tr>
                        <td width="40%"><%#Eval("UrunAdi") %></td>
                        <td width="40%"><%#Eval("MarkaAdi") %></td>
                        <td width="20%" align="rigth">
                            <a href="ResimEkle.aspx?id=<%#Eval("UrunID") %>"><img src="add_pic.png" /></a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:DataList>
        </table>
    </form>
</asp:Content>

