﻿<%@ Page Title="Adaugare angajati" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Adaugare_Angajati.aspx.cs" Inherits="SalaryCalculator.Adaugare_Angajati" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <p class="titleFont">Adaugare angajati</p>
    <br />
    <br />

    <asp:Label ID="lblInfoText" runat="server" />
    
    <br />
    <br />

    <asp:Label ID="lblNume" runat="server" Text="Nume: " AssociatedControlID="txtNume" CssClass="labelSpacing" />
    <asp:TextBox ID="txtNume" runat="server" AutoPostBack="true" OnTextChanged="txtNume_TextChanged" CssClass="textBoxSpacing" />

    <br />

    <asp:Label ID="lblPrenume" runat="server" Text="Prenume: " AssociatedControlID="txtPrenume" CssClass="labelSpacing" />
    <asp:TextBox ID="txtPrenume" runat="server" AutoPostBack="true" OnTextChanged="txtPrenume_TextChanged" CssClass="textBoxSpacing" />

    <br />

    <asp:Label ID="lblFunctie" runat="server" Text="Functie: " AssociatedControlID="txtFunctie" CssClass="labelSpacing" />
    <asp:TextBox ID="txtFunctie" runat="server" AutoPostBack="true" OnTextChanged="txtFunctie_TextChanged" CssClass="textBoxSpacing" />

    <br />

    <asp:Label ID="lblSalarBaza" runat="server" Text="Salar Baza: " AssociatedControlID="txtSalarBaza" CssClass="labelSpacing" />
    <asp:TextBox ID="txtSalarBaza" runat="server" AutoPostBack="true" OnTextChanged="txtSalarBaza_TextChanged" CssClass="textBoxSpacing" />

    <br />

    <asp:Label ID="lblSpor" runat="server" Text="Spor: " AssociatedControlID="txtSpor" CssClass="labelSpacing" />
    <asp:TextBox ID="txtSpor" runat="server" AutoPostBack="true" OnTextChanged="txtSpor_TextChanged" CssClass="textBoxSpacing" />

    <br />

    <asp:Label ID="lblPremiiBrute" runat="server" Text="Premii brute: " AssociatedControlID="txtPremiiBrute" CssClass="labelSpacing" />
    <asp:TextBox ID="txtPremiiBrute" runat="server" AutoPostBack="true" OnTextChanged="txtPremiiBrute_TextChanged" CssClass="textBoxSpacing" />

    <br />

    <!--
    <asp:Label ID="lblTotalBrut" runat="server" Text="Total brut: " AssociatedControlID="txtTotalBrut" />
    <asp:TextBox ID="txtTotalBrut" runat="server" />

    <br />

    <asp:Label ID="lblBrutImpozabil" runat="server" Text="Brut impozabil: " AssociatedControlID="txtBrutImpozabil" />
    <asp:TextBox ID="txtBrutImpozabil" runat="server" />

    <br />

    -->
    <asp:Label ID="lblImpozit" runat="server" Text="Impozit (10%): " AssociatedControlID="txtImpozit" CssClass="labelSpacing" />
    <asp:TextBox ID="txtImpozit" runat="server" ReadOnly="true" CssClass="textBoxSpacing" />

    <br />

    <asp:Label ID="lblCAS" runat="server" Text="CAS (25%): " AssociatedControlID="txtCAS" CssClass="labelSpacing" />
    <asp:TextBox ID="txtCAS" runat="server" ReadOnly="true" CssClass="textBoxSpacing" />

    <br />

    <asp:Label ID="lblCASS" runat="server" Text="CASS (10%): " AssociatedControlID="txtCASS" CssClass="labelSpacing" />
    <asp:TextBox ID="txtCASS" runat="server" ReadOnly="true" CssClass="textBoxSpacing" />

    <br />

    <asp:Label ID="lblRetineri" runat="server" Text="Retineri: " AssociatedControlID="txtRetineri" CssClass="labelSpacing" />
    <asp:TextBox ID="txtRetineri" runat="server" AutoPostBack="true" OnTextChanged="txtRetineri_TextChanged" CssClass="textBoxSpacing" />

    <br />

    <!--
    <asp:Label ID="lblViratCard" runat="server" Text="Virat Card: " AssociatedControlID="txtViratCard" />
    <asp:TextBox ID="txtViratCard" runat="server" />
    -->


    <br />

    <asp:Button ID="btnSubmit" runat="server" Text="Adauga angajat" Font-Bold="true" OnClick="btnSubmit_Click" />

    <br />
    <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Font-Bold="true" CssClass="infoMsg" />







</asp:Content>
