<%@ Page Title="Actualizare Taxe" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Actualizare_Taxe.aspx.cs" Inherits="SalaryCalculator.Actualizare_Taxe" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p class="titleFont">Actualizare Taxe Angajati</p>
    
    <br />
    <br />

    <asp:Label ID="lblInfoText" runat="server" />

    <br />
    <br />

    <div class="displayFlex">

        <div style="margin-right: 10px;">

            <asp:Label ID="lblUpdateCAS" runat="server" Text="CAS: " AssociatedControlID="txtUpdateCAS" />
            <asp:TextBox ID="txtUpdateCAS" runat="server" CssClass="roundedTextBox textBoxSpacing"></asp:TextBox>

            <asp:Label ID="lblUpdateCASS" runat="server" Text="CASS: " AssociatedControlID="txtUpdateCASS" />
            <asp:TextBox ID="txtUpdateCASS" runat="server" CssClass="roundedTextBox textBoxSpacing"></asp:TextBox>

            <asp:Label ID="lblUpdateImpozit" runat="server" Text="Impozit: " AssociatedControlID="txtUpdateImpozit" />
            <asp:TextBox ID="txtUpdateImpozit" runat="server" CssClass="roundedTextBox textBoxSpacing"></asp:TextBox>

            <asp:Button ID="Button1" runat="server" Text="Actualizeaza" OnClick="btnUpdateTaxe_Click" CssClass="roundButton" />
        </div>

    </div>
</asp:Content>
