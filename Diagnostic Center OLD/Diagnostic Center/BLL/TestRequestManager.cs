using Diagnostic_Center.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Diagnostic_Center.BLL
{
    public class TestRequestManager
    {

        TestRequestGetaway aTestRequestGetaway = new TestRequestGetaway();
        internal DataTable GetTestReqestList(DropDownList ddlTest, TextBox txtFees, object TestList)
        {
            if(ddlTest.SelectedItem.Text=="")
            {
                throw new Exception("Select Test Name...!!!");
            }
            DataTable dt = (DataTable)TestList;         
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.AsEnumerable().SingleOrDefault(r => r.Field<string>("TestID") == ddlTest.SelectedValue);
                if (dr != null)
                {
                    throw new Exception("Alrady add this Test...!!");                    
                }
                else
                {
                    dt.NewRow();
                    dt.Rows.Add(dt.Rows.Count + 1, ddlTest.SelectedItem.Text, ddlTest.SelectedValue, txtFees.Text);                    
                }
            }
            else
            {
                dt.NewRow();
                dt.Rows.Add(dt.Rows.Count + 1, ddlTest.SelectedItem.Text, ddlTest.SelectedValue, txtFees.Text);                
            }
            return dt;
        }
        internal string SaveTestRequest(Models.TestRequest aTestRequest, DataTable dtList)
        {
            if(aTestRequest.PatientName=="")
            {
                throw new Exception("Enter Patient Name ...!!!!!");
            }
            if(aTestRequest.DateOfBirth=="")
            {
                throw new Exception("Enter Date Of Birth ...!!!!!");
            }
            if (aTestRequest.MobileNumber == "")
            {
                throw new Exception("Enter Mobile Number...!!!!!");
            }
            if (dtList.Rows.Count<=0)
            {
                throw new Exception("Empty Items List ...!!!!!");
            }
            return aTestRequestGetaway.SaveTestRequest(aTestRequest, dtList);
        }

        internal GridViewRow getShowTotal(DataTable DtList)
        {
            if (DtList.Rows.Count <= 0)
            {
                return null;
            }
            GridViewRow row=new GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Normal);           
            decimal sum = 0;
            foreach (DataRow dr in DtList.Rows)
            {
                sum += Convert.ToDecimal(dr["Fee"]);
            }
            TableCell cell;
            cell = new TableCell();
            cell.Text = "";
            row.Cells.Add(cell);           
            cell = new TableCell();
            cell.Text = "Total ";
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = sum.ToString("N2");
            row.Cells.Add(cell);
            return row;

        }

        internal DataTable GetShowRequestPatientTestDetailsReport(string ID)
        {
            
            DataTable dt = aTestRequestGetaway.GetShowRequestPatientTestDetailsReport(ID);
            if(dt.Rows.Count>0)
            {
                return dt;
            }
            throw new Exception("No Found Patient Test....!!!!!! ");
        }

        internal DataTable GetShowTestRequestMst(string ID)
        {
            DataTable dt = aTestRequestGetaway.GetShowTestRequestMst(ID);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            throw new Exception("No Found Patient Test....!!!!!! ");
        }
        internal DataTable GetShowPatientTest(string ID)
        {
            DataTable dt = aTestRequestGetaway.GetShowPatientTest(ID);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            throw new Exception("No Found Patient Test....!!!!!! ");
        }
    }
}