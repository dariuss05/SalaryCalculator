<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SalaryCalculator._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="logo-container">
            <asp:Image runat="server" ID="logoImage" ImageUrl="~/logo/cheque.png" AlternateText="Logo" CssClass="logo" />
        </div>

        <br />
        
        <div id="clockContainer" class="container-fluid displayFlex">
            <p> <%: DateTime.Now.ToShortDateString() %> </p>
            &nbsp;
            <div id="clock">

            </div>
        </div>

        <br />
        <br />


        <div id="paragraphMainPage">

            <p class="paragraphMainText">

                Aplicatie de calculator al salariului avand o baza de date de angajati, unde puteti adauga un angajat, modifica un angajat, modifica taxa in functie de situatie.

                <br />
                Ce contine aceasta aplicatie:
                </p>
                 <ul>
                    <li>
                        <b>Pagina principala: </b> <p class="subParagraphMainText"> Pagina principala contine toate detaliile despre aplicatie cat si un ceas unde puteti vizualiza ora curenta </p>
                    </li>

                     <li>
                         <b>Pagina de 'Adaugare Angajati': </b> <p class="subParagraphMainText"> In aceasta pagina puteti adauga un angajat nou in baza de date. </p>
                     </li>

                     <li>
                         <b>Pagina de 'Afisare Angajati': </b> <p class="subParagraphMainText"> In aceasta pagina puteti vizualiza angajatii adaugati in baza de date, puteti exporta fluturas in format PDF pentru un anumit angajat. In acelasi timp, puteti exporta in format PDF statul de plata pentru toti angajatii existenti. De asemenea, puteti vizualiza suma totala a tuturor angajatiilor in baza de date. </p>
                     </li>

                     <li>
                         <b> Pagina de 'Actualizare Date': </b> <p class="subParagraphMainText"> In aceasta pagina puteti actualiza salariul, premiile brute, sporul cat si retinerile unui angajat existent in baza de date. De asemenea, puteti sterge un angajat definitiv din baza de date. </p>
                     </li>

                     <li>
                         <b> Pagina de 'Actualizare Taxe': </b> <p class="subParagraphMainText"> In aceasta pagina puteti actualiza valorile taxelor unde vor fi realizate calculele pentru taxele curente ale angajatilor. </p>
                     </li>
                 </ul>


        </div>

        <script type="text/javascript">
        function updateClock() {
            var now = new Date();
            var hours = now.getHours();
            var minutes = now.getMinutes();
            var seconds = now.getSeconds();

            hours = hours < 10 ? '0' + hours : hours;
            minutes = minutes < 10 ? '0' + minutes : minutes;
            seconds = seconds < 10 ? '0' + seconds : seconds;

            var timeString = hours + ':' + minutes + ':' + seconds;
            document.getElementById('clock').innerHTML = timeString;
        }

            setInterval(updateClock, 1000);

            updateClock();
        </script>

</asp:Content>
