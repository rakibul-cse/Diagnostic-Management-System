using Diagnostic_Center.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diagnostic_Center
{
    public partial class frmTestSetup : System.Web.UI.Page
    {
        TestTypeSetupManager aTestTypeSetupManager = new TestTypeSetupManager();
        TestSetupManager aTestSetupManager=new TestSetupManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                RefreshAll();
            }
        }
        private void RefreshAll()
        {
            txtFee.Text = "0";
            ddlTestType.SelectedIndex = -1;
            txtName.Text = "";
            DataTable dt = aTestTypeSetupManager.GetShowItemsDetails();
            ddlTestType.DataSource = dt;
            ddlTestType.DataValueField = "ID";
            ddlTestType.DataTextField = "TypeName";
            ddlTestType.DataBind();
            ddlTestType.Items.Insert(0, "");
            DataTable dt1 = aTestSetupManager.GetShowTestSetupDetais();
            dgTestHistory.DataSource = dt1;
            dgTestHistory.DataBind();
            txtName.Focus();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TestSetup aTestSetup = new TestSetup();
                aTestSetup.ID = hfID.Value;
                aTestSetup.TestName = txtName.Text;
                aTestSetup.Fee = txtFee.Text;
                aTestSetup.TestTypeID = ddlTestType.SelectedValue;
                string Alert = aTestSetupManager.SaveTestSetupInformation(aTestSetup);
                ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + Alert + "');", true);
                RefreshAll();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + ex.Message + "');", true);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }

       

        protected void dgTestHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow | e.Row.RowType == DataControlRowType.Header | e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Attributes.Add("style", "display:none");
            }
        }

        protected void dgTestHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfID.Value = dgTestHistory.SelectedRow.Cells[1].Text;
            TestSetup aTestSetup = aTestSetupManager.GetTestSetup(hfID.Value);
            if (aTestSetup != null)
            {
                txtName.Text = aTestSetup.TestName;
                txtFee.Text = aTestSetup.Fee;
                ddlTestType.SelectedValue = aTestSetup.TestTypeID;
            }
        }
    }
}