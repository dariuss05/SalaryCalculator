using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalaryCalculator
{
    public partial class Afisare_Angajati : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            DatabaseConfig dbHelper = new DatabaseConfig(connectionString);

            string query = "SELECT nr_crt AS 'Nr. Crt', nume AS 'Nume', prenume AS 'Prenume', functie AS 'Functie', salar_baza AS 'Salar Baza', spor AS 'Spor', premii_brute AS 'Premii Brute', total_brut AS 'Total Brut', brut_impozabil AS 'Brut Impozabil', impozit AS 'impozit', cas AS 'CAS', cass AS 'CASS', retineri AS 'Retineri', virat_card AS 'Virat Card' FROM salarycalculator.angajati WHERE taxa_id = 1";
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
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Style["padding"] = "10px";
                }
            }
        }
    }
}