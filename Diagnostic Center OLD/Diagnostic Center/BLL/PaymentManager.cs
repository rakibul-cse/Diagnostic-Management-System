using Diagnostic_Center.DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Diagnostic_Center.BLL
{
    public class PaymentManager
    {
        TestRequestManager aTestRequestManager = new TestRequestManager();
        PaymentGetaway aPaymentGetaway = new PaymentGetaway();
        internal string  SavePaymentInformation(Models.PaymentInfo aPaymentInfo)
        {
            if (aPaymentInfo.PaymentAmount == "")
            {
                throw new Exception("Need payment First then save....!!!!");
            }
            if (Convert.ToDouble(aPaymentInfo.PaymentAmount) > 0)
            {
                return aPaymentGetaway.SavePaymentInformation(aPaymentInfo);
            }
            throw new Exception("Need payment First then save....!!!!");
        }

        internal void GetShowMoneyReceiptReport(iTextSharp.text.Document document,string ID,string PayAmt)
        {
            DataTable dtMst = aTestRequestManager.GetShowPatientTest(ID);
            if (dtMst.Rows.Count > 0)
            {
                

                PdfPCell cell;
                float[] titwidth = new float[1] { 100 };
                PdfPTable dth = new PdfPTable(titwidth);
                dth.WidthPercentage = 100;

                cell = new PdfPCell(FormatHeader("Money Receipt"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                dth.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("  "));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                dth.AddCell(cell);
                document.Add(dth);

                float[] width1 = new float[4] { 40, 5, 35, 20 };
                PdfPTable pdftbl = new PdfPTable(width1);
                pdftbl.WidthPercentage = 100;

                cell = new PdfPCell(FormatHeaderPhrase("Patient ID"));
                cell.HorizontalAlignment = 0;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);

                cell = new PdfPCell(FormatHeaderPhrase(":"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);

                cell = new PdfPCell(FormatHeaderPhrase(dtMst.Rows[0]["PatientID"].ToString()));
                cell.HorizontalAlignment = 0;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                cell.Colspan = 2;
                pdftbl.AddCell(cell);

                cell = new PdfPCell(FormatHeaderPhrase("Patient Name"));
                cell.HorizontalAlignment = 0;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase(":"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase(dtMst.Rows[0]["PatientName"].ToString()));
                cell.HorizontalAlignment = 0;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                cell.Colspan = 2;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("Mobile Number"));
                cell.HorizontalAlignment = 0;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase(":"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase(dtMst.Rows[0]["Mobile"].ToString()));
                cell.HorizontalAlignment = 0;
                cell.VerticalAlignment = 1;
                cell.Colspan = 2;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);

                cell = new PdfPCell(FormatHeaderPhrase("Date Of Birth "));
                cell.HorizontalAlignment = 0;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase(":"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase(dtMst.Rows[0]["DOB"].ToString()));
                cell.HorizontalAlignment = 0;
                cell.VerticalAlignment = 1;
                cell.Colspan = 2;
                cell.BorderWidth = 0f;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase(""));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                cell.FixedHeight = 10f;
                cell.Colspan = 4;
                pdftbl.AddCell(cell);

                cell = new PdfPCell(FormatHeaderPhrase("ID"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("Test Name"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.Colspan = 2;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("Fee"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);
                DataTable dddt = aTestRequestManager.GetShowRequestPatientTestDetailsReport(ID);
                foreach (DataRow dr in dddt.Rows)
                {
                    cell = new PdfPCell(FormatHeaderPhrase(dr["ID"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                    cell = new PdfPCell(FormatHeaderPhrase(dr["TestName"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;
                    cell.Colspan = 2;
                    pdftbl.AddCell(cell);
                    cell = new PdfPCell(FormatHeaderPhrase(dr["Fee"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                }
                cell = new PdfPCell(FormatHeaderPhrase("Total Fee : " + dtMst.Rows[0]["Fee"].ToString()));
                cell.HorizontalAlignment = 2;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                cell.Colspan = 4;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("Paid Amount : " + dtMst.Rows[0]["PayAmount"].ToString()));
                cell.HorizontalAlignment = 2;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                cell.Colspan = 4;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("Due Amount : " + dtMst.Rows[0]["Due"].ToString()));
                cell.HorizontalAlignment = 2;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                cell.Colspan = 4;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("Now Pay Amount : " + PayAmt));
                cell.HorizontalAlignment = 2;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                cell.Colspan = 4;
                pdftbl.AddCell(cell);

                document.Add(pdftbl);
            }
            else
            {
                throw new Exception("Not Found.......!!!!!!!!");
            }
        }
        private static Phrase FormatHeaderPhrase(string value)
        {
            return new Phrase(value, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL));
        }
        private static Phrase FormatHeader(string value)
        {
            return new Phrase(value, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, iTextSharp.text.Font.BOLD));
        }
        internal DataTable GetShowTestWiseReportDetails(string FromDate, string ToDate)
        {
            DataTable dt= aPaymentGetaway.GetShowTestWiseReportDetails(FromDate, ToDate);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            throw new Exception("No Test Search in this Date.........!!!!");

        }
        internal GridViewRow getShowTotal(double total)
        {
            if (total > 0)
            {
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal);                
                TableCell cell;
                cell = new TableCell();
                cell.Text = "";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = "";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = "Total ";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = total.ToString("N2");
                row.Cells.Add(cell);
                return row;
            }
            return null;
        }

        internal void GetShowTestWiseReportDetailsReport(Document document, string FromDate, string ToDate)
        {
            DataTable dt = aPaymentGetaway.GetShowTestWiseReportDetails(FromDate, ToDate);
            if (dt.Rows.Count > 0)
            {
                PdfPCell cell;
                float[] titwidth = new float[1] { 100 };
                PdfPTable dth = new PdfPTable(titwidth);
                dth.WidthPercentage = 100;

                cell = new PdfPCell(FormatHeader("Test Wise Report Date ( " + FromDate + " TO " + ToDate + " )"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                dth.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("  "));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                cell.BorderWidth = 0f;
                dth.AddCell(cell);
                document.Add(dth);

                float[] width1 = new float[4] { 10, 30, 15, 15 };
                PdfPTable pdftbl = new PdfPTable(width1);
                pdftbl.WidthPercentage = 100;               

                cell = new PdfPCell(FormatHeaderPhrase("SL"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("Test Name"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;               
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("Total Test"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase("Total Amount"));
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = 1;
                pdftbl.AddCell(cell);
                decimal tot = decimal.Zero;
                foreach (DataRow dr in dt.Rows)
                {
                    cell = new PdfPCell(FormatHeaderPhrase(dr["SL"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                    cell = new PdfPCell(FormatHeaderPhrase(dr["Test Name"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;                    
                    pdftbl.AddCell(cell);
                    cell = new PdfPCell(FormatHeaderPhrase(dr["Total Test"].ToString()));
                    cell.HorizontalAlignment = 1;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                    cell = new PdfPCell(FormatHeaderPhrase(dr["Total Amount"].ToString()));
                    cell.HorizontalAlignment = 2;
                    cell.VerticalAlignment = 1;
                    pdftbl.AddCell(cell);
                    tot += Convert.ToDecimal(dr["Total Amount"]);
                }
                cell = new PdfPCell(FormatHeaderPhrase("Total"));
                cell.HorizontalAlignment = 2;
                cell.VerticalAlignment = 1;
                cell.Colspan = 3;
                pdftbl.AddCell(cell);
                cell = new PdfPCell(FormatHeaderPhrase(tot.ToString("N2")));
                cell.HorizontalAlignment = 2;
                cell.VerticalAlignment = 1;
                cell.Colspan = 3;
                pdftbl.AddCell(cell);
                document.Add(pdftbl);
            }
            else
            {
                throw new Exception("Not Found.......!!!!!!!!");
            }
        }
    }
}