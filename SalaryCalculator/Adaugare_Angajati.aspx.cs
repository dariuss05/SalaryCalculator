using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalaryCalculator
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblInfoText.Text = "Valorile pentru: TOTAL_BRUT, BRUT_IMPOZABIL, IMPOZIT, CAS, CASS, VIRAT_CARD sunt calculate automat";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string nume = txtNume.Text;
            string prenume = txtPrenume.Text;
            string functie = txtFunctie.Text;

            try
            {
                int salarBaza = int.Parse(txtSalarBaza.Text);
                int spor = int.Parse(txtSpor.Text);
                int premiiBrute = int.Parse(txtPremiiBrute.Text);
                int retineri = int.Parse(txtRetineri.Text);

                /* Calculul celorlate textBox-uri 
                 Total Brut
                 */
                int totalBrut = salarBaza * (1 + (spor / 100)) + premiiBrute;
                txtTotalBrut.Text = totalBrut.ToString();

                float impozit, cas, cass;

                /* Accesam valorile din baza de date */
                using (var taxeDBValues = new DatabaseConfig())
                {
                    // Primul si unicul rand din tabelul `taxe`;
                    var taxeValues = taxeDBValues.taxe.FirstOrDefault();

                    if (taxeValues != null)
                    {
                        impozit = taxeValues.impozit;
                        cas = taxeValues.cas;
                        cass = taxeValues.cass;
                    } else
                    {
                        lblErrorMessage.Text = "Valorile taxelor n-au fost regasite in baza de date";
                        return;
                    }
                }

                /* CAS */
                int valCAS = totalBrut * Convert.ToInt32(cas);
                txtCAS.Text = valCAS.ToString();

                /* CASS */
                int valCASS = totalBrut * Convert.ToInt32(cass);
                txtCASS.Text = valCASS.ToString();

                /* Brut impozabil */
                int brutImpozabil = totalBrut - valCAS - valCASS;
                txtBrutImpozabil.Text = brutImpozabil.ToString();

                /* Impozit */
                int valImpozit = brutImpozabil * Convert.ToInt32(impozit);
                txtImpozit.Text = valImpozit.ToString();

                /* Virat Card */
                int viratCard = totalBrut - brutImpozabil - valCAS - valCASS - retineri;



            } catch (FormatException exception)
            {
                lblErrorMessage.Text = "Te rog verifica inca o data valorile introduse, ai grija sa nu introduci litere!";
            }


        }
    }
}