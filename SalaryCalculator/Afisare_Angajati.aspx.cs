using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using System.Xml.Linq;
using System.IO;
using MySql.Data.MySqlClient;

namespace SalaryCalculator
{
    public partial class Afisare_Angajati : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            DatabaseConfig dbHelper = new DatabaseConfig(connectionString);

            int suma_totala = 0;

            string query = "SELECT nr_crt, nume, prenume, functie, salar_baza, spor, premii_brute, total_brut, brut_impozabil, impozit, cas, cass, retineri, virat_card FROM salarycalculator.angajati WHERE taxa_id = 1";
            string suma_totalaQuery = "SELECT SUM(virat_card) AS 'suma_totala' from salarycalculator.angajati WHERE taxa_id = 1";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(suma_totalaQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            suma_totala = reader.GetInt32("suma_totala");
                        }
                    }
                }
            }

            lblInfoText.Text = "Suma totala neta a salariilor din tabel: " + suma_totala.ToString();
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


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(GridView1.HeaderRow.Cells.Count);

            foreach (TableCell headerCell in GridView1.HeaderRow.Cells)
            {
                PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text, new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD)));

                pdfTable.AddCell(pdfCell);

            }


            foreach (GridViewRow row in GridView1.Rows)
            {
                foreach (TableCell tableCell in row.Cells)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(tableCell.Text));

                    

                    pdfTable.AddCell(pdfCell);

                }
            }

            Document pdfDocument = new Document(PageSize.A2, 20f, 20f, 20f, 20f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();

            Paragraph title = new Paragraph("Stat de plata angajati", new Font(Font.FontFamily.HELVETICA, 16f, Font.BOLD));
            pdfDocument.Add(title);
            pdfDocument.Add(new Paragraph("\n"));
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=stat_de_plata_angajati_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GeneratePDF(rowIndex);
            }
        }

        private void GeneratePDF(int rowIndex)
        {

            if (rowIndex >= 0 && rowIndex < GridView1.Rows.Count)
            {
                GridViewRow selectedRow = GridView1.Rows[rowIndex];

                PdfPTable pdfTable = new PdfPTable(selectedRow.Cells.Count);

                foreach (TableCell headerCell in GridView1.HeaderRow.Cells)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text, new Font(Font.FontFamily.HELVETICA, 10f, Font.BOLD)));
                    pdfTable.AddCell(pdfCell);
                }

                foreach (TableCell tableCell in selectedRow.Cells)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(tableCell.Text));
                    pdfTable.AddCell(pdfCell);
                }

                Document pdfDocument = new Document(PageSize.A3, 20f, 20f, 20f, 20f);
                MemoryStream memoryStream = new MemoryStream();

                PdfWriter.GetInstance(pdfDocument, memoryStream);


                pdfDocument.Open();
                Paragraph title = new Paragraph("Fluturas de plata angajat", new Font(Font.FontFamily.HELVETICA, 16f, Font.BOLD));

                pdfDocument.Add(title);
                pdfDocument.Add(new Paragraph("\n"));
                pdfDocument.Add(pdfTable);
                pdfDocument.Close();

                Response.ContentType = "application/pdf";
                Response.AppendHeader("content-disposition", "attachment;filename=fluturas_angajat_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".pdf");
                Response.OutputStream.Write(memoryStream.GetBuffer(), 0, memoryStream.GetBuffer().Length);
                Response.OutputStream.Flush();
                Response.OutputStream.Close();
                Response.End();
            }
            else
            {
                lblInfoText.ForeColor = System.Drawing.Color.Red;
                lblInfoText.Text = "Nu s-a putut descarca fluturasul!";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchColumn = ddlSearch.SelectedValue;
            string searchText = txtSearch.Text;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            string query = $"SELECT nr_crt, nume, prenume, functie, salar_baza, spor, premii_brute, total_brut, brut_impozabil, impozit, cas, cass, retineri, virat_card FROM salarycalculator.angajati WHERE taxa_id = 1 AND {searchColumn} = @SearchResult";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchResult", searchText);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        GridView1.DataSource = reader;
                        GridView1.DataBind();
                    }
                }
            }

        }
    }
}