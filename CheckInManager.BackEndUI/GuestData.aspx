<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="GuestData.aspx.cs" Inherits="CheckInManager.BackEndUI.GuestData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormData" runat="server">
    <div class="header">
        <h3>Insert Guest Data</h3>
    </div>
    <div class="form-group">
            <asp:Label ID="Label5" runat="server" Text="Event Date: "></asp:Label>
            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar><br /><br />
    </div>
    <div class="form-group">
           <asp:Label ID="Label1" runat="server" Text="Gender: "></asp:Label>
           <asp:Button ID="btnMale" runat="server" Text="Male" CssClass="btn btn-primary btn-md" OnClick="btnMale_Click" />
           <asp:Button ID="btnFemale" runat="server" Text="Female" CssClass="btn btn-primary btn-md" OnClick="btnFemale_Click" />
           <br />
    </div>

    <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Age: "></asp:Label>
            <asp:Button ID="btnAdult" runat="server" Text="Adult" CssClass="btn btn-primary btn-md" OnClick="btnAdult_Click" />
            <asp:Button ID="btnSenior" runat="server" Text="Senior" CssClass="btn btn-primary btn-md" OnClick="btnSenior_Click" />
            <asp:Button ID="btnChild" runat="server" Text="Child" CssClass="btn btn-primary btn-md" OnClick="btnChild_Click" /><br />
    </div>

    <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="Ethnicity: "></asp:Label>
            <asp:Button ID="btnWhite" runat="server" Text="Caucasian" CssClass="btn btn-primary btn-md" OnClick="btnWhite_Click" />
            <asp:Button ID="btnAfAmer" runat="server" Text="African American" CssClass="btn btn-primary btn-md" OnClick="btnAfAmer_Click" />
            <asp:Button ID="btnAsAmer" runat="server" Text="Asian" CssClass="btn btn-primary btn-md" OnClick="btnAsAmer_Click" />
            <asp:Button ID="btnHisp" runat="server" Text="Hispanic" CssClass="btn btn-primary btn-md" OnClick="btnHisp_Click" />
            <asp:Button ID="btnNative" runat="server" Text="Native American" CssClass="btn btn-primary btn-md" OnClick="btnNative_Click" />
        <br />
    </div>
    <div class="form-group">
            <asp:Label ID="Label4" runat="server" Text="City: "></asp:Label>
            <asp:Button ID="btnAppleton" runat="server" Text="Appleton" CssClass="btn btn-primary btn-md" OnClick="btnAppleton_Click" />
            <asp:Button ID="btnMenasha" runat="server" Text="Menasha" CssClass="btn btn-primary btn-md" OnClick="btnMenasha_Click" />
            <asp:Button ID="btnKimberly" runat="server" Text="Kimberly" CssClass="btn btn-primary btn-md" OnClick="btnKimberly_Click" />
            <asp:Button ID="btnKaukauna" runat="server" Text="Kaukauna" CssClass="btn btn-primary btn-md" OnClick="btnKaukauna_Click" />
            <asp:Button ID="btnLtChute" runat="server" Text="LtChute" CssClass="btn btn-primary btn-md" OnClick="btnLtChute_Click" />
            <asp:Button ID="btnNeenah" runat="server" Text="Neenah" CssClass="btn btn-primary btn-md" OnClick="btnNeenah_Click" />
        <br />
    </div>
    
    <div class="form-group">
        <asp:Button ID="btnInsert" runat="server" Text="Insert" CssClass="btn btn-primary btn-md" OnClick="btnInsert_Click"/>
    </div>
</asp:Content>
