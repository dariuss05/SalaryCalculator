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
    public partial class Actualizare_Date : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayGridView();

            lblInfoText.Visible = false;
            lblNumeSelectat.Visible = false;

            lblNumeEdit.Visible = false;
            txtNumeEdit.Visible = false;

            lblFunctieEdit.Visible = false;
            txtFunctieEdit.Visible = false;

            lblSalarBazaEdit.Visible = false;
            txtSalarBazaEdit.Visible = false;

            lblSporEdit.Visible = false;
            txtSporEdit.Visible = false;

            lblPremiiBruteEdit.Visible = false;
            txtPremiiBruteEdit.Visible = false;

            lblRetineriEdit.Visible = false;
            txtRetineriEdit.Visible = false;

            btnSubmit.Visible = false;

        }

        private void DisplayGridView()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            DatabaseConfig dbHelper = new DatabaseConfig(connectionString);

            string query = "SELECT nr_crt, nume, prenume, functie, salar_baza, spor, premii_brute, total_brut, brut_impozabil, impozit, cas, cass, retineri, virat_card FROM salarycalculator.angajati WHERE taxa_id = 1";
            DataTable result = dbHelper.ExecuteQuery(query);
            GridView1.DataSource = result;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Style["padding"] = "10px";
                }
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Style["padding"] = "10px";

                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

            int nr_crt = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
            string prenume = GridView1.Rows[e.NewEditIndex].Cells[2].Text;

            lblNumeSelectat.ForeColor = System.Drawing.Color.LightGreen;
            lblNumeSelectat.Text = nr_crt.ToString() + ", " + prenume;

            lblInfoText.Visible = true;
            lblNumeSelectat.Visible = true;

            lblInfoText.Visible = true;
            lblNumeSelectat.Visible = true;

            lblNumeEdit.Visible = true;
            txtNumeEdit.Visible = true;

            lblFunctieEdit.Visible = true;
            txtFunctieEdit.Visible = true;

            lblSalarBazaEdit.Visible = true;
            txtSalarBazaEdit.Visible = true;

            lblSporEdit.Visible = true;
            txtSporEdit.Visible = true;

            lblPremiiBruteEdit.Visible = true;
            txtPremiiBruteEdit.Visible = true;

            lblRetineriEdit.Visible = true;
            txtRetineriEdit.Visible = true;

            btnSubmit.Visible = true;

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT nume, functie, salar_baza, spor, premii_brute, retineri FROM salarycalculator.angajati WHERE taxa_id = 1";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nume = reader.GetString("nume");
                                txtNumeEdit.Text = nume;

                                string functie = reader.GetString("functie");
                                txtFunctieEdit.Text = functie;

                                int salarBaza = reader.GetInt32("salar_baza");
                                txtSalarBazaEdit.Text = salarBaza.ToString();

                                int spor = reader.GetInt32("spor");
                                txtSporEdit.Text = spor.ToString();

                                int premiiBrute = reader.GetInt32("premii_brute");
                                txtPremiiBruteEdit.Text = premiiBrute.ToString();

                                int retineri = reader.GetInt32("retineri");
                                txtRetineriEdit.Text = retineri.ToString();

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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            float dbImpozit = 0, dbCAS = 0, dbCASS = 0;
            int nr_crtIndex = GridView1.EditIndex;

            int nr_crt = Convert.ToInt32(GridView1.DataKeys[nr_crtIndex].Value);

            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            try
            {
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
                                dbImpozit = reader.GetFloat("impozit");
                                dbCAS = reader.GetFloat("cas");
                                dbCASS = reader.GetFloat("cass");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblInfoText.Text = "Nu am putut incarca taxele din baza de date";
            }


            int salarBaza = int.Parse(txtSalarBazaEdit.Text);
            int spor = int.Parse(txtSporEdit.Text);
            int premiiBrute = int.Parse(txtPremiiBruteEdit.Text);
            int retineri = int.Parse(txtRetineriEdit.Text);
            int totalBrut = salarBaza * (1 + (spor / 100)) + premiiBrute;
            float newCAS_value = (int)(totalBrut * dbCAS);
            float newCASS_value = (int)(totalBrut * dbCASS);
            int brutImpozabil = (int)(totalBrut - newCAS_value - newCASS_value);
            float newImpozit_value = (int)(brutImpozabil * dbImpozit);
            int viratCard = (int)(totalBrut - newImpozit_value - newCAS_value - newCASS_value - retineri);



            string updateQuery = "UPDATE salarycalculator.angajati SET nume='" + txtNumeEdit.Text
                + "', functie='" + txtFunctieEdit.Text
                + "', salar_baza='" + salarBaza
                + "', spor='" + spor
                + "', premii_brute='" + premiiBrute
                + "', total_brut='" + totalBrut
                + "', brut_impozabil='" + brutImpozabil
                + "', impozit='" + newImpozit_value
                + "', cas='" + newCAS_value
                + "', cass='" + newCASS_value
                + "', retineri='" + retineri
                + "', virat_card='" + viratCard 
                + "' WHERE nr_crt='" + nr_crt 
                + "' AND taxa_id='1'";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                
                connection.Open();
                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                {
                    updateCommand.ExecuteNonQuery();
                }

                lblInfoText.Visible = false;
                lblNumeSelectat.Visible = false;

                lblNumeEdit.Visible = false;
                txtNumeEdit.Visible = false;

                lblFunctieEdit.Visible = false;
                txtFunctieEdit.Visible = false;

                lblSalarBazaEdit.Visible = false;
                txtSalarBazaEdit.Visible = false;

                lblSporEdit.Visible = false;
                txtSporEdit.Visible = false;

                lblPremiiBruteEdit.Visible = false;
                txtPremiiBruteEdit.Visible = false;

                lblRetineriEdit.Visible = false;
                txtRetineriEdit.Visible = false;

                btnSubmit.Visible = false;

                Response.Redirect(Request.RawUrl, false);
                Context.ApplicationInstance.CompleteRequest();
                DisplayGridView();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int nr_crt = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string deleteQuery = "DELETE FROM salarycalculator.angajati WHERE nr_crt='" + nr_crt + "' AND taxa_id='1'";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                connection.Open();
                using (MySqlCommand updateCommand = new MySqlCommand(deleteQuery, connection))
                {
                    updateCommand.ExecuteNonQuery();
                }
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "RedirectScript", "setTimeout(function(){ window.location = '" + Request.RawUrl + "'; }, 300);", true);
        }


    }
}