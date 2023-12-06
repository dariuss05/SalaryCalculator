using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalaryCalculator
{
    public partial class Actualizare_Taxe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                                    txtUpdateImpozit.Text = impozit.ToString();

                                    float cas = reader.GetFloat("cas");
                                    txtUpdateCAS.Text = cas.ToString();

                                    float cass = reader.GetFloat("cass");
                                    txtUpdateCASS.Text = cass.ToString();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblInfoText.Text = "Nu am putut incarca taxele din baza de date";
                }
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

        protected void btnUpdateTaxe_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            float txtImpozit = float.Parse(txtUpdateImpozit.Text);
            float txtCAS = float.Parse(txtUpdateCAS.Text);
            float txtCASS = float.Parse(txtUpdateCASS.Text);

            int idValue = GetTaxaID();

            string updateTaxeQuery = "UPDATE salarycalculator.taxe SET impozit=@Impozit, cas=@CAS, cass=@CASS WHERE id=@ID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        using (MySqlCommand updateTaxeCommand = new MySqlCommand(updateTaxeQuery, connection))
                        {
                            updateTaxeCommand.Parameters.AddWithValue("@Impozit", txtImpozit);
                            updateTaxeCommand.Parameters.AddWithValue("@CAS", txtCAS);
                            updateTaxeCommand.Parameters.AddWithValue("@CASS", txtCASS);
                            updateTaxeCommand.Parameters.AddWithValue("@ID", idValue);

                            updateTaxeCommand.ExecuteNonQuery();
                            lblInfoText.ForeColor = System.Drawing.Color.LightGreen;
                            lblInfoText.Text = "Taxe actualizate cu succes!";
                        }
                        transaction.Commit();
                    }
                } catch (Exception ex)
                {
                    lblInfoText.ForeColor = System.Drawing.Color.Red;
                    lblInfoText.Text = ex.ToString();
                }
            }
        }
    }
}