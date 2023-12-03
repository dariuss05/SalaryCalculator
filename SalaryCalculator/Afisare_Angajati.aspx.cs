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

namespace SalaryCalculator
{
    public partial class Afisare_Angajati : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            DatabaseConfig dbHelper = new DatabaseConfig(connectionString);

            string query = "SELECT nr_crt AS 'Nr. Crt', nume AS 'Nume', prenume AS 'Prenume', functie AS 'Functie', salar_baza AS 'Salar Baza', spor AS 'Spor', premii_brute AS 'Premii Brute', total_brut AS 'Total Brut', brut_impozabil AS 'Brut Impozabil', impozit AS 'Impozit', cas AS 'CAS', cass AS 'CASS', retineri AS 'Retineri', virat_card AS 'Virat Card' FROM salarycalculator.angajati WHERE taxa_id = 1";
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
    }
}