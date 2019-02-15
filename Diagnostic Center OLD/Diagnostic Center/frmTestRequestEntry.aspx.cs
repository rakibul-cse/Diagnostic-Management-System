using Diagnostic_Center.BLL;
using Diagnostic_Center.Models;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diagnostic_Center
{
    public partial class frmTestRequestEntry : System.Web.UI.Page
    {
        TestSetupManager aTestSetupManager = new TestSetupManager();
        TestRequestManager aTestRequestManager = new TestRequestManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshAll();
            }

        }

        private void RefreshAll()
        {
            ViewState["TableList"] = null;
            ddlTest.DataSource = aTestSetupManager.GetShowTestSetupDetais();
            ddlTest.DataTextField = "TestName";
            ddlTest.DataValueField = "ID";
            ddlTest.DataBind();
            ddlTest.Items.Insert(0, "");
            txtPatientName.Text = txtDBO.Text = txtMobileNo.Text = "";
            DataTable dt = new DataTable();
            dt.Columns.Add("SL");
            dt.Columns.Add("Test");
            dt.Columns.Add("TestID");
            dt.Columns.Add("Fee");
            ViewState["TableList"] = dt;
            btnSave.Visible = false;
            btnSave.Enabled = true;
            dgAddItems.DataSource = dt;
            dgAddItems.DataBind();
            txtPatientName.Focus();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DtList = aTestRequestManager.GetTestReqestList(ddlTest, txtFees, ViewState["TableList"]);
                dgAddItems.DataSource = DtList;
                ViewState["TableList"] = DtList;
                dgAddItems.DataBind();
                btnSave.Visible = true;
                TotalBill();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + ex.Message + "');", true);
            }
        }

        private void TotalBill()
        {
            DataTable dt = (DataTable)ViewState["TableList"];
            GridViewRow row = aTestRequestManager.getShowTotal(dt);
            if (row != null)
            { dgAddItems.Controls[0].Controls.Add(row); }
        }

        protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            TestSetup aTestSetup = aTestSetupManager.GetTestSetup(ddlTest.SelectedValue);
            if (aTestSetup != null)
            {
                txtFees.Text = aTestSetup.Fee;
                TotalBill();
            }

        }

        protected void dgAddItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow | e.Row.RowType == DataControlRowType.Header | e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Attributes.Add("style", "display:none");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmTestRequestEntry");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TestRequest aTestRequest = new TestRequest();
                aTestRequest.PatientName = txtPatientName.Text;
                aTestRequest.DateOfBirth = txtDBO.Text;
                aTestRequest.MobileNumber = txtMobileNo.Text;
                DataTable dtList = (DataTable)ViewState["TableList"];
                string Alert = aTestRequestManager.SaveTestRequest(aTestRequest, dtList);
                ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + Alert + "');", true);                
                hfMstID.Value = DataTransfection.GetShowSingleValueInt("TOP(1)ID", "TestRequestMst order by ID desc").ToString();
                TestReport();
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + ex.Message + "');", true);
            }
        }     

        private void TestReport()
        {
            DataTable dtt = aTestRequestManager.GetShowTestRequestMst(hfMstID.Value);

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringBuilder sb = new StringBuilder();

                    //Generate Invoice (Bill) Header.
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append("<tr><td align='center' style='background-color: green;' colspan = '2'><b>Test Request </b></td></tr>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td><b>Patient Code : </b>");
                    sb.Append(dtt.Rows[0]["PatientID"].ToString());
                    sb.Append("</td><td align = 'right'><b>Date Of Dirth : </b>");
                    sb.Append(dtt.Rows[0]["DOB"].ToString());
                    sb.Append(" </td></tr>");
                    sb.Append("<tr><td><b>Patient Name : </b>");
                    sb.Append(dtt.Rows[0]["PatientName"].ToString());

                    sb.Append("</td><td align = 'right'><b>Mobile No. : </b>");
                    sb.Append(dtt.Rows[0]["Mobile"].ToString());

                    sb.Append("</td></tr>");
                    sb.Append("</table>");
                    sb.Append("<br />");

                    //Generate Invoice (Bill) Items Grid.
                    sb.Append("<table border = '1'>");
                    sb.Append("<tr>");
                    DataTable dt = aTestRequestManager.GetShowRequestPatientTestDetailsReport(hfMstID.Value);
                    //foreach (DataColumn column in dt.Columns)
                    //{
                    sb.Append("<th align = 'Center' Width='10%' style = 'background-color: red;color:#000000;'>");
                    // sb.Append(column.ColumnName);
                    sb.Append("<b>ID</b> </th>");
                    sb.Append("<th align = 'Center'  width='70%' style = 'background-color: red;color:#000000;'>");
                    // sb.Append(column.ColumnName);
                    sb.Append("<b>Test Name</b> </th>");
                    sb.Append("<th align = 'Center'  width='20%' style = 'background-color: red;color:#000000;'>");
                    // sb.Append(column.ColumnName);
                    sb.Append("<b>Fee Name</b> </th>");
                    //}
                    sb.Append("</tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td align = 'Center' width='10%' style = 'background-color: red;color:#000000;'>");
                        //sb.Append(row[column]);
                        sb.Append(row["ID"] + "</td>");
                        sb.Append("<td align = 'Left' width='70%' style = 'background-color: red;color:#000000;'>");
                        //sb.Append(row[column]);
                        sb.Append(row["TestName"] + "</td>");
                        sb.Append("<td align = 'Right' width='20%' style = 'background-color: red;color:#000000;'>");
                        //sb.Append(row[column]);
                        sb.Append(row["Fee"] + "</td>");
                        sb.Append("</tr>");
                    }
                    sb.Append("<tr><td align = 'right' colspan = '2'");
                    //sb.Append(dt.Columns.Count - 1);
                    sb.Append("'>Total</td>");
                    //sb.Append("<td></td><td></td><td></td>");
                    sb.Append("<td align = 'right'>");
                    sb.Append(dt.Compute("sum(Fee)", ""));
                    sb.Append("</td>");
                    sb.Append("</tr></table>");

                    //Export HTML String as PDF.
                    StringReader sr = new StringReader(sb.ToString());
                    Document pdfDoc = new Document(PageSize.A4);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename='PatientInfo'.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }

            }
        }

    }

}