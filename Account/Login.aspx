<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--    <form id ="frm" runat="server">--%>
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Default.aspx"></asp:Login>
<%--    </form>--%>
</asp:Content>

