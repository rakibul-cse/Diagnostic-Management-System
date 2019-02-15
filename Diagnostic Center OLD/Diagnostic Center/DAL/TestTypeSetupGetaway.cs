using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diagnostic_Center.Getaway
{
    public class TestTypeSetupGetaway
    {
        internal string GetSaveTestSetupInfo(TestTypeSetup aTestTypeSetup)
        {
            string Query = @"INSERT INTO [TestTypeSetup]
           ([TypeName])
     VALUES ('" + aTestTypeSetup.Name + "')";
            int rowEffect = DataTransfection.ExecuteNonQuery(Query);
            if (rowEffect > 0)
            {
                return "Record is/are Saved Sucessfully....!!";
            }
            else
                throw new Exception("Record Save Failed....!!! ");
        }

        internal string GetUpdateTestSetupInfo(TestTypeSetup aTestTypeSetup)
        {
            string Query = @"UPDATE [TestTypeSetup]  SET [TypeName] ='" + aTestTypeSetup.Name + "' WHERE ID='" + aTestTypeSetup.ID + "'";
            int rowEffect = DataTransfection.ExecuteNonQuery(Query);
            if (rowEffect > 0)
            {
                return "Record is/are Update Sucessfully....!!";
            }
            else
                throw new Exception("Record Update Failed....!!! ");
        }

        internal DataTable GetShowTestTypeSetupDetails()
        {
            string Query = @"SELECT [ID],row_number() over (order by ID) as Serial ,[TypeName],[AddBy] FROM [TestTypeSetup]";
            DataTable dt = DataTransfection.GetShowDataTable(Query, "TestTypeSetup");
            return dt;
        }
    }
}