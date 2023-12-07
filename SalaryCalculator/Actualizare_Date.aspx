<%@ Page Title="Actualizare Date" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Actualizare_Date.aspx.cs" Inherits="SalaryCalculator.Actualizare_Date" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p class="titleFont">Actualizare Date</p>
    <br />
    <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" BorderColor="Black" BorderWidth="1px" OnRowEditing="GridView1_RowEditing" DataKeyNames="nr_crt" OnRowDeleting="GridView1_RowDeleting">
    <Columns>

        <asp:BoundField DataField="nr_crt" HeaderText="Nr. Crt" ReadOnly="true" />

        <asp:TemplateField HeaderText="Nume">

            <ItemTemplate>
                <asp:Label ID="lblNume" runat="server" Text='<%# Eval("nume") %>'></asp:Label>
            </ItemTemplate>

            <EditItemTemplate>
                <asp:TextBox ID="txtNume" runat="server" Text='<%# Bind("nume") %>'></asp:TextBox>
            </EditItemTemplate>

        </asp:TemplateField>

        <asp:BoundField DataField="prenume" HeaderText="Prenume" ReadOnly="true" />

        <asp:TemplateField HeaderText="Functie">

            <ItemTemplate>
                <asp:Label ID="lblFunctie" runat="server" Text='<%# Eval("functie") %>'></asp:Label>
            </ItemTemplate>

            <EditItemTemplate>
                <asp:TextBox ID="txtFunctie" runat="server" Text='<%# Bind("functie") %>'></asp:TextBox>
            </EditItemTemplate>

        </asp:TemplateField>

        <asp:TemplateField HeaderText="Salar Baza">

            <ItemTemplate>
                <asp:Label ID="lblSalarBaza" runat="server" Text='<%# Eval("salar_baza") %>'></asp:Label>
            </ItemTemplate>

            <EditItemTemplate>
                <asp:TextBox ID="txtSalarBaza" runat="server" Text='<%# Bind("salar_baza") %>'></asp:TextBox>
            </EditItemTemplate>

        </asp:TemplateField>


        <asp:TemplateField HeaderText="Spor">

            <ItemTemplate>
                <asp:Label ID="lblSpor" runat="server" Text='<%# Eval("spor") %>'></asp:Label>
            </ItemTemplate>

            <EditItemTemplate>
                <asp:TextBox ID="txtSpor" runat="server" Text='<%# Bind("spor") %>'></asp:TextBox>
            </EditItemTemplate>

        </asp:TemplateField>

        <asp:TemplateField HeaderText="Premii Brute">

            <ItemTemplate>
                <asp:Label ID="lblPremiiBrute" runat="server" Text='<%# Eval("premii_brute") %>'></asp:Label>
            </ItemTemplate>

            <EditItemTemplate>
                <asp:TextBox ID="txtPremiiBrute" runat="server" Text='<%# Bind("premii_brute") %>'></asp:TextBox>
            </EditItemTemplate>

        </asp:TemplateField>

        <asp:BoundField DataField="total_brut" HeaderText="Total Brut" ReadOnly="true" />

        <asp:BoundField DataField="brut_impozabil" HeaderText="Brut Impozabil" ReadOnly="true" />

        <asp:BoundField DataField="impozit" HeaderText="Impozit" ReadOnly="true" />

        <asp:BoundField DataField="cas" HeaderText="CAS" ReadOnly="true" />

        <asp:BoundField DataField="cass" HeaderText="CASS" ReadOnly="true" />

        <asp:TemplateField HeaderText="Retineri">

            <ItemTemplate>
                <asp:Label ID="lblRetineri" runat="server" Text='<%# Eval("retineri") %>'></asp:Label>
            </ItemTemplate>

            <EditItemTemplate>
                <asp:TextBox ID="txtRetineri" runat="server" Text='<%# Bind("retineri") %>'></asp:TextBox>
            </EditItemTemplate>

        </asp:TemplateField>

        <asp:BoundField DataField="virat_card" HeaderText="Virat Card" ReadOnly="true" />

        <asp:CommandField HeaderText="Actiuni" ButtonType="Link" ShowEditButton="True" ShowDeleteButton="True" EditText="<i class='fas fa-pen-to-square editIcon'></i>&nbsp;" DeleteText="<i class='fas fa-trash deleteIcon'></i>" />


    </Columns>
    </asp:GridView>

    <br />
    <br />


    <div>

        <asp:Label ID="lblInfoText" runat="server" Text="Modificati urmatoarele valori pentru angajatul selectat: " />
        <asp:Label ID="lblNumeSelectat" runat="server" />

        <br />
        <br />

        <asp:Label ID="lblNumeEdit" runat="server" Text="Nume: " AssociatedControlID="txtNumeEdit" CssClass="labelSpacing"  />
        <asp:TextBox ID="txtNumeEdit" runat="server" CssClass="textBoxSpacing" OnTextChanged="txtNumeEdit_TextChanged" />

        <br />

        <asp:Label ID="lblFunctieEdit" runat="server" Text="Functie: " AssociatedControlID="txtFunctieEdit" CssClass="labelSpacing" />
        <asp:TextBox ID="txtFunctieEdit" runat="server" CssClass="textBoxSpacing" OnTextChanged="txtFunctieEdit_TextChanged" />

        <br />

        <asp:Label ID="lblSalarBazaEdit" runat="server" Text="Salar Baza: " AssociatedControlID="txtSalarBazaEdit" CssClass="labelSpacing" />
        <asp:TextBox ID="txtSalarBazaEdit" runat="server" CssClass="textBoxSpacing" OnTextChanged="txtSalarBazaEdit_TextChanged" />

        <br />

        <asp:Label ID="lblSporEdit" runat="server" Text="Spor: " AssociatedControlID="txtSporEdit" CssClass="labelSpacing" />
        <asp:TextBox ID="txtSporEdit" runat="server" CssClass="textBoxSpacing" OnTextChanged="txtSporEdit_TextChanged" />

        <br />

        <asp:Label ID="lblPremiiBruteEdit" runat="server" Text="Premii Brute: " AssociatedControlID="txtPremiiBruteEdit" CssClass="labelSpacing" />
        <asp:TextBox ID="txtPremiiBruteEdit" runat="server" CssClass="textBoxSpacing" OnTextChanged="txtPremiiBruteEdit_TextChanged" />

        <br />

        <asp:Label ID="lblRetineriEdit" runat="server" Text="Retineri: " AssociatedControlID="txtRetineriEdit" CssClass="labelSpacing" />
        <asp:TextBox ID="txtRetineriEdit" runat="server" CssClass="textBoxSpacing" OnTextChanged="txtRetineriEdit_TextChanged" />

        <br />
        <br />

        <asp:Label ID="lblErrorMessage" runat="server" CssClass="labelSpacing" />

        <asp:Button ID="btnSubmit" runat="server" Text="Actualizeaza angajat" Font-Bold="true" OnClick="btnSubmit_Click" />

  
    </div>
</asp:Content>

