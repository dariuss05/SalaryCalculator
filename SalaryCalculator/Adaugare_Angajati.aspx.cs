using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SalaryCalculator
{
    public partial class Adaugare_Angajati : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblInfoText.Text = "Valorile pentru: TOTAL_BRUT, BRUT_IMPOZABIL, IMPOZIT, CAS, CASS, VIRAT_CARD sunt calculate automat";
            
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string taxeQuery = "SELECT impozit, cas, cass FROM salarycalculator.taxe WHERE taxe.id = 1";

                    using (MySqlCommand command = new MySqlCommand(taxeQuery, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                float impozit = reader.GetFloat("impozit");
                                txtImpozit.Text = impozit.ToString();

                                float cas = reader.GetFloat("cas");
                                txtCAS.Text = cas.ToString();

                                float cass = reader.GetFloat("cass");
                                txtCASS.Text = cass.ToString();


                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                lblInfoText.Text = "Nu am putut incarca taxele din baza de date";
            }

        }

        protected int GetTaxaID()
        {
            int taxaID = 0;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string taxeQuery = "SELECT id FROM salarycalculator.taxe";

                    using (MySqlCommand command = new MySqlCommand(taxeQuery, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                taxaID = reader.GetInt32("id");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblInfoText.Text = "Nu am putut incarca taxele din baza de date";
            }
            return taxaID;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO salarycalculator.angajati (nume, prenume, functie, salar_baza, spor, premii_brute, total_brut, brut_impozabil, impozit, cas, cass, retineri, virat_card, taxa_id) VALUES (@nume, @prenume, @functie, @salarBaza, @spor, @premiiBrute, @totalBrut, @brutImpozabil, @impozit, @cas, @cass, @retineri, @viratCard, @taxaID)";
                    
                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@nume", txtNume.Text);
                        insertCommand.Parameters.AddWithValue("@prenume", txtPrenume.Text);
                        insertCommand.Parameters.AddWithValue("@functie", txtFunctie.Text);
                        
                        try
                        {
                            int valCAS = 0;
                            int valCASS = 0;
                            int valImpozit = 0;

                            int salarBaza = int.Parse(txtSalarBaza.Text);
                            insertCommand.Parameters.AddWithValue("@salarBaza", salarBaza);

                            int spor = int.Parse(txtSpor.Text);
                            insertCommand.Parameters.AddWithValue("@spor", spor);

                            //int premiiBrute = int.Parse(txtPremiiBrute.Text);
                            //insertCommand.Parameters.AddWithValue("@premiiBrute", premiiBrute);

                            int premiiBrute = int.Parse(txtPremiiBrute.Text);
                            if (int.TryParse(txtPremiiBrute.Text, out premiiBrute))
                            {
                                insertCommand.Parameters.AddWithValue("@premiiBrute", premiiBrute);
                            }

                            int retineri = int.Parse(txtRetineri.Text);
                            insertCommand.Parameters.AddWithValue("@retineri", retineri);

                            int totalBrut = salarBaza * (1 + (spor / 100)) + premiiBrute;
                            insertCommand.Parameters.AddWithValue("@totalBrut", totalBrut);

                            if (float.TryParse(txtCAS.Text, out float dbCAS))
                            {
                                valCAS = (int)(totalBrut * dbCAS);
                                insertCommand.Parameters.AddWithValue("@cas", valCAS);
                            }
                            else
                            {
                                lblErrorMessage.Text = "Nu putem adauga CAS";
                            }

                            if (float.TryParse(txtCASS.Text, out float dbCASS))
                            {
                                valCASS = (int)(totalBrut * dbCASS);
                                insertCommand.Parameters.AddWithValue("@cass", valCASS);
                            }
                            else
                            {
                                lblErrorMessage.Text = "Nu putem adauga CASS";
                            }

                            int brutImpozabil = (totalBrut - valCASS - valCAS);
                            insertCommand.Parameters.AddWithValue("@brutImpozabil", brutImpozabil);

                            if (float.TryParse(txtImpozit.Text, out float dbImpozit))
                            {
                                valImpozit = (int)(brutImpozabil * dbImpozit);
                                insertCommand.Parameters.AddWithValue("@impozit", valImpozit);
                            }
                            else
                            {
                                lblErrorMessage.Text = "Nu putem adauga impozit";
                            }

                            int viratCard = (totalBrut - valImpozit - valCAS - valCASS - retineri);
                            insertCommand.Parameters.AddWithValue("@viratCard", viratCard);

                            int taxaID = GetTaxaID();
                            insertCommand.Parameters.AddWithValue("taxaID", taxaID);

                            insertCommand.ExecuteNonQuery();

                            lblErrorMessage.ForeColor = System.Drawing.Color.LightGreen;
                            lblErrorMessage.Text = "Angajat adaugat cu succes";
                        } catch (Exception exception)
                        {
                            lblErrorMessage.Text = exception.ToString();
                        }

                    }
                }
            }
            catch (Exception exception)
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                lblErrorMessage.Text = "Eroare la adaugarea angajatului, verifica te rog formularul";
            }
        }
        
        private void validateStringTextBoxes(TextBox textBox)
        {

            string value = textBox.Text.Trim();

            if (containsNumbers(value))
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                lblErrorMessage.Text = "Verifica te rog textul introdus, nu trebuie sa contina numere!";
            }

        }

        private void validateDecimalTextBoxes(TextBox textBox)
        {
            string value = textBox.Text.Trim();

            if (!decimal.TryParse(value, out decimal numericValue) || numericValue < 0) {
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                lblErrorMessage.Text = "Verifica te rog textul introdus, nu trebuie sa contina litere iar valoarea trebuie sa fie mai mare ca 0!";
            }
        }

        private bool containsNumbers(string text)
        {
            return text.Any(char.IsDigit);
        }

        private bool containsLetters(string text)
        {
            return text.Any(char.IsLetter);
        }

        protected void txtNume_TextChanged(object sender, EventArgs e)
        {
            validateStringTextBoxes(txtNume);
        }

        protected void txtPrenume_TextChanged(object sender, EventArgs e)
        {
            validateStringTextBoxes(txtPrenume);
        }

        protected void txtFunctie_TextChanged(object sender, EventArgs e)
        {
            validateStringTextBoxes(txtFunctie);
        }

        protected void txtSalarBaza_TextChanged(object sender, EventArgs e)
        {
            validateDecimalTextBoxes(txtSalarBaza);
        }

        protected void txtSpor_TextChanged(object sender, EventArgs e)
        {
            validateDecimalTextBoxes(txtSpor);
        }

        protected void txtPremiiBrute_TextChanged(object sender, EventArgs e)
        {
            validateDecimalTextBoxes(txtPremiiBrute);
        }

        protected void txtRetineri_TextChanged(object sender, EventArgs e)
        {
            validateDecimalTextBoxes(txtRetineri);
        }
    }
}