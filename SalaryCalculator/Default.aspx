<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SalaryCalculator._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="logo-container">
            <asp:Image runat="server" ID="logoImage" ImageUrl="~/logo/cheque.png" AlternateText="Your Logo" CssClass="logo" />
        </div>

        <br />
        
        <div id="clockContainer" class="container-fluid displayFlex">
            <p> <%: DateTime.Now.ToShortDateString() %> </p>
            &nbsp;
            <div id="clock">

            </div>
        </div>

        <script type="text/javascript">
        function updateClock() {
            var now = new Date();
            var hours = now.getHours();
            var minutes = now.getMinutes();
            var seconds = now.getSeconds();

            // Ensure two digits for hours, minutes, and seconds
            hours = hours < 10 ? '0' + hours : hours;
            minutes = minutes < 10 ? '0' + minutes : minutes;
            seconds = seconds < 10 ? '0' + seconds : seconds;

            var timeString = hours + ':' + minutes + ':' + seconds;
            document.getElementById('clock').innerHTML = timeString;
        }

            // Update the clock every second
            setInterval(updateClock, 1000);

            // Initial update
            updateClock();
        </script>

</asp:Content>
