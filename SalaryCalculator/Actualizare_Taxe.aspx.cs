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

            decimal txtImpozit = Convert.ToDecimal(txtUpdateImpozit.Text);
            decimal txtCAS = Convert.ToDecimal(txtUpdateCAS.Text);
            decimal txtCASS = Convert.ToDecimal(txtUpdateCASS.Text);

            int idValue = GetTaxaID();



            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand("UpdateTaxeProcedure", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_param", idValue);
                    command.Parameters.AddWithValue("@impozit_param", txtImpozit);
                    command.Parameters.AddWithValue("@cas_param", txtCAS);
                    command.Parameters.AddWithValue("@cass_param", txtCASS);

                    command.ExecuteNonQuery();
                    lblInfoText.ForeColor = System.Drawing.Color.LightGreen;
                    lblInfoText.Text = "Taxe actualizate cu succes!";
                }
            }
        }
    }
}