using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diagnostic_Center.DAL
{
    public class TestRequestGetaway
    {
        int PatientCode = 1;
        SqlTransaction transaction;
        SqlConnection connection = new SqlConnection(DBConnector.ConnString());
        internal string SaveTestRequest(Models.TestRequest aTestRequest, DataTable dtList)
        {
            try
            {
                connection.Open();

                transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.Transaction = transaction;              

                command.CommandText = @"SELECT COUNT(*) FROM [TestRequestMst]";
                PatientCode += Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = @"INSERT INTO [TestRequestMst]
           ([PatientID],[PatientName],[DOB],[Mobile],AddDate)
     VALUES ('P-00" + PatientCode + "','" + aTestRequest.PatientName + "',convert(date,'" + aTestRequest.DateOfBirth + "',103),'" + aTestRequest.MobileNumber + "',GETDATE())";
                command.ExecuteNonQuery();
                command.CommandText = @"SELECT top(1)ID FROM [TestRequestMst] order by ID desc";
                int MstID = Convert.ToInt32(command.ExecuteScalar());
                foreach (DataRow dr in dtList.Rows)
                {
                    command.CommandText = @"INSERT INTO [TestRequestDtls]
                  ([MstID],[TestID],[Fee])
                VALUES ('" + MstID + "','" + dr["TestID"].ToString() + "','" + dr["Fee"].ToString() + "')";
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
                return "Record is/are Save Sucessfully....!!";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        internal DataTable GetShowRequestPatientTestDetailsReport(string ID)
        {
            string Query = @"SELECT ROW_NUMBER() OVER(ORDER BY (SELECT t1.ID)) AS ID ,t2.TestName ,t1.[Fee] FROM [TestRequestDtls] t1 inner join  TestSetup t2 on t2.ID=t1.TestID WHERE MstID='"+ID+"'";
            DataTable dt = DataTransfection.GetShowDataTable(Query, "TestRequestDtls");
            return dt;
        }

        internal DataTable GetShowTestRequestMst(string ID)
        {
            string Query = @"SELECT [PatientID],[PatientName],CONVERT(NVARCHAR,[DOB],103) AS DOB ,[Mobile]  FROM [TestRequestMst] WHERE ID='"+ID+"'";
            DataTable dt = DataTransfection.GetShowDataTable(Query, "TestRequestMst");
            return dt;
        }

        internal DataTable GetShowPatientTest(string ID)
        {
            string Query = @"  with tot AS (SELECT t1.[PatientID],t1.[PatientName],convert(nvarchar,t1.[DOB])DOB,t1.Mobile,ISNULL(sum(t3.Fee),0) AS Fee,t2.PayAmount AS PayAmount FROM [TestRequestMst] t1 inner join TestRequestDtls t3 on t3.MstID=t1.ID left join (select tt.PatientID,SUM(tt.PayAmount)PayAmount from Payment tt group by tt.PatientID) t2 on t2.PatientID=t1.ID  where t1.ID='"+ID+"'  group by t1.[PatientID],t1.[PatientName],t1.[DOB] ,t1.Mobile,t2.PayAmount)  select tot.PatientID,tot.PatientName,tot.DOB,tot.Mobile,tot.Fee,tot.PayAmount,(tot.Fee-tot.PayAmount) AS Due from tot";
            DataTable dt = DataTransfection.GetShowDataTable(Query, "TestRequestMst");
            return dt;
        }
    }
}