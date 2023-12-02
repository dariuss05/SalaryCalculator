using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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


            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            DatabaseConfig dbHelper = new DatabaseConfig(connectionString);

            string query = "SELECT nr_crt AS 'Nr. Crt', nume AS 'Nume', prenume AS 'Prenume', functie AS 'Functie', salar_baza AS 'Salar Baza', spor AS 'Spor', premii_brute AS 'Premii Brute', total_brut AS 'Total Brut', brut_impozabil AS 'Brut Impozabil', impozit AS 'impozit', cas AS 'CAS', cass AS 'CASS', retineri AS 'Retineri', virat_card AS 'Virat Card' FROM salarycalculator.angajati WHERE taxa_id = 1";
            DataTable result = dbHelper.ExecuteQuery(query);
            GridView1.DataSource = result;
            GridView1.DataBind();

            lblInfoText.Visible = false;
            lblNumeSelectat.Visible = false;

        }

        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell actionCell = new TableCell();

                /* Edit Button */
                LinkButton editButton = new LinkButton();
                editButton.CssClass = "editIcon";
                editButton.CommandName = "Edit";
                editButton.ToolTip = "Edit";
                editButton.Text = "<i class='fas fa-pen-to-square'></i>";
                editButton.Click += EditButton_Click;
                actionCell.Controls.Add(editButton);

                /* Spatiul dintre butoane */
                actionCell.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));

                /* Delete Button */
                LinkButton deleteButton = new LinkButton();
                deleteButton.CssClass = "deleteIcon";
                deleteButton.CommandName = "Delete";
                deleteButton.ToolTip = "Delete";
                deleteButton.Text = "<i class='fas fa-trash'></i>";
                deleteButton.Click += DeleteButton_Click;
                actionCell.Controls.Add(deleteButton);

                e.Row.Cells.Add(actionCell);

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Style["padding"] = "10px";
                }
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                TableCell actionCell = new TableCell();
                actionCell.Text = "<b> Actiuni </b>";
                e.Row.Cells.Add(actionCell);

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Style["padding"] = "10px";

                }
            }
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                int selectedRowIndex = this.GridView1.SelectedIndex;

                string query = $"SELECT nume, prenume FROM salarycalculator.angajati WHERE nr_crt = {selectedRowIndex + 1}";
                string nume, prenume;

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nume = reader.GetString("nume");
                            prenume = reader.GetString("prenume");
                            lblNumeSelectat.Text = $"{nume} {prenume}";
                        }
                    }
                }
            }

            lblInfoText.Visible = true;
            lblNumeSelectat.ForeColor = System.Drawing.Color.LightGreen;
            lblNumeSelectat.Visible = true;
        }
    }
}