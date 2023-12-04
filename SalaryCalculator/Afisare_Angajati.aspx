<%@ Page Title="Afisare Angajati" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Afisare_Angajati.aspx.cs" Inherits="SalaryCalculator.Afisare_Angajati" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p class="titleFont">Afisare angajati</p>
    
    <br />

   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" BorderColor="Black" BorderWidth="1px" DataKeyNames="nr_crt" OnRowCommand="GridView1_RowCommand">
    <Columns>
        <asp:BoundField DataField="nr_crt" HeaderText="Nr. Crt" ReadOnly="true" />

        <asp:BoundField DataField="nume" HeaderText="Nume" ReadOnly="true" />

        <asp:BoundField DataField="prenume" HeaderText="Prenume" ReadOnly="true" />

        <asp:BoundField DataField="functie" HeaderText="Functie" ReadOnly="true" />

        <asp:BoundField DataField="salar_baza" HeaderText="Salar Baza" ReadOnly="true" />

        <asp:BoundField DataField="spor" HeaderText="Spor" ReadOnly="true" />

        <asp:BoundField DataField="premii_brute" HeaderText="Premii Brute" ReadOnly="true" />

        <asp:BoundField DataField="total_brut" HeaderText="Total Brut" ReadOnly="true" />

        <asp:BoundField DataField="brut_impozabil" HeaderText="Brut Impozabil" ReadOnly="true" />

        <asp:BoundField DataField="impozit" HeaderText="Impozit" ReadOnly="true" />

        <asp:BoundField DataField="cas" HeaderText="CAS" ReadOnly="true" />

        <asp:BoundField DataField="cass" HeaderText="CASS" ReadOnly="true" />

        <asp:BoundField DataField="retineri" HeaderText="Retineri" ReadOnly="true" />

        <asp:BoundField DataField="virat_card" HeaderText="Virat Card" ReadOnly="true" />

        <asp:CommandField HeaderText="Exporta Fluturas PDF" ButtonType="Link" ShowEditButton="True" EditText="<i class='fas fa-file-pdf' style='font-size: 20px; color: darkgray;'></i>" />
    </Columns>
    </asp:GridView>

    <br />
    <br />
    
    <asp:Label ID="lblInfoText" runat="server" />
    
    <br />
    <br />

    <asp:Button ID="btnSubmit" runat="server" Text="Exporta Stat de Plata PDF" Font-Bold="true" OnClick="btnSubmit_Click" />
</asp:Content>
