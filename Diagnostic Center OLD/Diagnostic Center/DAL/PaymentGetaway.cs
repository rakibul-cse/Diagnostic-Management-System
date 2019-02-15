using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diagnostic_Center.DAL
{
    public class PaymentGetaway
    {
        internal string SavePaymentInformation(Models.PaymentInfo aPaymentInfo)
        {
            string Query = @"INSERT INTO [Payment]
           ([PatientID],[PayAmount])
     VALUES
           ('" + aPaymentInfo.ID + "','" + aPaymentInfo.PaymentAmount.Replace("'","") + "')";
            int rowEffect = DataTransfection.ExecuteNonQuery(Query);
            if (rowEffect > 0)
            {
                return "Record is/are Saved Sucessfully....!!";
            }
            else
                throw new Exception("Record Save Failed....!!! ");
        }   

        internal DataTable GetShowTestWiseReportDetails(string FromDate, string ToDate)
        {
            string ShowQuery = @"SELECT ROW_NUMBER() OVER(ORDER BY (SELECT t1.[TestID])) AS SL, t2.TestName AS [Test Name],COUNT(t1.[TestID])AS [Total Test]
      ,sum(t1.[Fee])  AS [Total Amount] 
  FROM [TestRequestDtls] t1 inner join TestSetup t2 on t2.ID=t1.TestID inner join TestRequestMst t3 on t3.ID=t1.MstID where convert(date,t3.AddDate,103) between convert(date,'" + FromDate + "',103) and convert(date,'" + ToDate + "',103) group by t2.TestName, TestID ";
            DataTable dt = DataTransfection.GetShowDataTable(ShowQuery, "TestRequestDtls");
            return dt;
        }
    }
}