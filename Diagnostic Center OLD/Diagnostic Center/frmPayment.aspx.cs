using Diagnostic_Center.BLL;
using Diagnostic_Center.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diagnostic_Center
{

    public partial class frmPayment : System.Web.UI.Page
    {
        TestRequestManager aTestRequestManager = new TestRequestManager();
        PaymentManager aPaymentManager = new PaymentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtPayAmt.Text = "0";
                lblDue.Text = lblPaidAmount.Text = lblTolatFee.Text = "0.00";
                lblDue.Visible = lblPaidAmount.Visible = lblTolatFee.Visible =lblDate.Visible=txtPayAmt.Visible=btnPay.Visible=btnClear.Visible=btnPrint.Visible= false;
                label12.Visible = label3.Visible = label5.Visible = label22.Visible = label2.Visible = false;
                btnPay.Enabled = true;
                lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = DataTransfection.GetShowSingleValueInt("ID", "PatientID", "TestRequestMst", txtSearch.Text);
                if (ID != 0)
                {
                    hfID.Value = ID.ToString();
                    DataTable dtMst = aTestRequestManager.GetShowPatientTest(ID.ToString());
                    if (dtMst.Rows.Count > 0)
                    {
                        lblTolatFee.Text = dtMst.Rows[0]["Fee"].ToString();
                        lblPaidAmount.Text = dtMst.Rows[0]["PayAmount"].ToString();
                        lblDue.Text = dtMst.Rows[0]["Due"].ToString();
                        DataTable dt = aTestRequestManager.GetShowRequestPatientTestDetailsReport(ID.ToString());
                        dgTestHistory.DataSource = dt;
                        dgTestHistory.DataBind();
                        lblDue.Visible = lblPaidAmount.Visible = lblTolatFee.Visible = lblDate.Visible = txtPayAmt.Visible = btnPay.Visible = btnClear.Visible = btnPrint.Visible = true;
                        label12.Visible = label3.Visible = label5.Visible = label22.Visible = label2.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + ex.Message + "');", true);
            }
        }
        protected void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                PaymentInfo aPaymentInfo = new PaymentInfo();
                aPaymentInfo.ID = hfID.Value;
                aPaymentInfo.PaymentAmount = txtPayAmt.Text;
                string Alert = aPaymentManager.SavePaymentInformation(aPaymentInfo);
                btnPay.Enabled = false;
                ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + Alert + "');", true);
                PrintMoneyReceipt();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + ex.Message + "');", true);
            }
        }
        public void PrintMoneyReceipt()
        {
            try
            {
                Session.Remove("rptbyte");
                Response.Clear();
                Document document = new Document();
                float pheight = (float)(14.8 / 2.54) * 72;
                float pwidth = (float)(8.1 / 2.54) * 72;
                document = new Document(new iTextSharp.text.Rectangle(pwidth, pheight), 10f, 10f, 10f, 10f);
                MemoryStream ms = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();
                aPaymentManager.GetShowMoneyReceiptReport(document, hfID.Value, txtPayAmt.Text);
                document.Close();
                byte[] byt = ms.GetBuffer();
                if (Session["rptbyte"] != null) { byte[] rptbyt = (byte[])Session["rptbyte"]; rptbyt = byt; } else { Session["rptbyte"] = byt; }
                string strJS = ("<script type='text/javascript'>window.open('Default2.aspx','_blank');</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "strJSAlert", strJS);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + ex.Message + "');", true);
            }
        }        

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmPayment.aspx");
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintMoneyReceipt();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + ex.Message + "');", true);
            }
        }
    }
}