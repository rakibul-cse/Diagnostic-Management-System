using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diagnostic_Center
{
    public partial class frmTestTypeSetup : System.Web.UI.Page
    {
        TestTypeSetupManager aTestTypeSetupManager = new TestTypeSetupManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                RefreshAll();
            }
        }
        private void RefreshAll()
        {
            txtTypeName.Text = hfID.Value = "";
            DataTable dt = aTestTypeSetupManager.GetShowItemsDetails();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            txtTypeName.Focus();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TestTypeSetup aTestTypeSetup = new TestTypeSetup();
                aTestTypeSetup.ID = hfID.Value;
                aTestTypeSetup.Name = txtTypeName.Text;
                string Alert = aTestTypeSetupManager.SaveTestTypeInformation(aTestTypeSetup);
                ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + Alert + "');", true);
                RefreshAll();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + ex.Message + "');", true);
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTypeName.Text = GridView1.SelectedRow.Cells[2].Text;
            hfID.Value = GridView1.SelectedRow.Cells[1].Text;
            txtTypeName.Focus();
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            hfID.Value = GridView1.SelectedRow.Cells[3].Text;
            txtTypeName.Text = GridView1.SelectedRow.Cells[2].Text;
        }      

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow | e.Row.RowType == DataControlRowType.Header | e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[3].Attributes.Add("style", "display:none");
            }
        }
    }
}