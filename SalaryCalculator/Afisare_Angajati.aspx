<%@ Page Title="Afisare Angajati" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Afisare_Angajati.aspx.cs" Inherits="SalaryCalculator.Afisare_Angajati" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p class="titleFont">Afisare angajati</p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True" BorderColor="Black" BorderWidth="1px" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound" />

    <br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Exporta Stat de Plata PDF" Font-Bold="true" OnClick="btnSubmit_Click" />
</asp:Content>
