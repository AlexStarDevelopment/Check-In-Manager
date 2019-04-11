<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CheckInManager.BackEndUI.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormData" runat="server">
    <div>
    Welcome
    <asp:LoginName ID="LoginName1" runat="server" Font-Bold = "true" />
    <br />
    <br />
    <asp:LoginStatus ID="LoginStatus1" runat="server" />
</div>
</asp:Content>
