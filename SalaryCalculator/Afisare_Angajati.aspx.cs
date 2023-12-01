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

            // Example query
            string query = "SELECT * FROM angajati";
            DataTable result = dbHelper.ExecuteQuery(query);
            GridView1.DataSource = result;
            GridView1.DataBind();
        }
    }
}