<%@ Page Title="Adaugare angajati" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Adaugare_Angajati.aspx.cs" Inherits="SalaryCalculator.Adaugare_Angajati" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     
    <asp:Label ID="lblInfoText" runat="server" />
    
    <br />

    <asp:Label ID="lblNume" runat="server" Text="Nume: " AssociatedControlID="txtNume" />
    <asp:TextBox ID="txtNume" runat="server" />

    <br />

    <asp:Label ID="lblPrenume" runat="server" Text="Prenume: " AssociatedControlID="txtPrenume" />
    <asp:TextBox ID="txtPrenume" runat="server" />

    <br />

    <asp:Label ID="lblFunctie" runat="server" Text="Functie: " AssociatedControlID="txtFunctie" />
    <asp:TextBox ID="txtFunctie" runat="server" />

    <br />

    <asp:Label ID="lblSalarBaza" runat="server" Text="Salar Baza: " AssociatedControlID="txtSalarBaza" />
    <asp:TextBox ID="txtSalarBaza" runat="server" />

    <br />

    <asp:Label ID="lblSpor" runat="server" Text="Spor: " AssociatedControlID="txtSpor" />
    <asp:TextBox ID="txtSpor" runat="server" />

    <br />

    <asp:Label ID="lblPremiiBrute" runat="server" Text="Premii brute: " AssociatedControlID="txtPremiiBrute" />
    <asp:TextBox ID="txtPremiiBrute" runat="server" />

    <br />

    <asp:Label ID="lblTotalBrut" runat="server" Text="Total brut: " AssociatedControlID="txtTotalBrut" />
    <asp:TextBox ID="txtTotalBrut" runat="server" />

    <br />

    <asp:Label ID="lblBrutImpozabil" runat="server" Text="Brut impozabil: " AssociatedControlID="txtBrutImpozabil" />
    <asp:TextBox ID="txtBrutImpozabil" runat="server" />

    <br />

    <asp:Label ID="lblImpozit" runat="server" Text="Impozit (10%): " AssociatedControlID="txtImpozit" />
    <asp:TextBox ID="txtImpozit" runat="server" />

    <br />

    <asp:Label ID="lblCAS" runat="server" Text="CAS (25%): " AssociatedControlID="txtCAS" />
    <asp:TextBox ID="txtCAS" runat="server" />

    <br />

    <asp:Label ID="lblCASS" runat="server" Text="CASS (10%): " AssociatedControlID="txtCASS" />
    <asp:TextBox ID="txtCASS" runat="server" />

    <br />

    <asp:Label ID="lblRetineri" runat="server" Text="Retineri: " AssociatedControlID="txtRetineri" />
    <asp:TextBox ID="txtRetineri" runat="server" />

    <br />

    <asp:Label ID="lblViratCard" runat="server" Text="Virat Card: " AssociatedControlID="txtViratCard" />
    <asp:TextBox ID="txtViratCard" runat="server" />

    <br />

    <asp:Button ID="btnSubmit" runat="server" Text="Adauga angajat" Font-Bold="true" OnClick="btnSubmit_Click" />

    <br />
    <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Font-Bold="true" />





</asp:Content>
