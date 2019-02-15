using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TestSetupManager
/// </summary>
public class TestSetupGetaway
{
    public TestSetupGetaway()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    internal string SaveTestSetupInformation(TestSetup aTestSetup)
    {
        string Query = @"INSERT INTO [TestSetup]
           ([TestName],[Fee],[TestTypeID])
     VALUES
           ('" + aTestSetup.TestName + "'," + aTestSetup.Fee + ",'" + aTestSetup.TestTypeID + "')";
        int rowEffect = DataTransfection.ExecuteNonQuery(Query);
        if (rowEffect > 0)
        {
            return "Record is/are Saved Sucessfully....!!";
        }
        else
            throw new Exception("Record Save Failed....!!! ");
    }

    public string UpdateTestSetupInformation(TestSetup aTestSetup)
    {
        string Query = @"UPDATE [TestSetup] SET [TestName] ='" + aTestSetup.TestName + "'  ,[Fee] = " + aTestSetup.Fee + " ,[TestTypeID] = '" + aTestSetup.TestTypeID + "'  WHERE  ID='" + aTestSetup.ID + "'";
        int rowEffect = DataTransfection.ExecuteNonQuery(Query);
        if (rowEffect > 0)
        {
            return "Record is/are Update Sucessfully....!!";
        }
        else
            throw new Exception("Record Update Failed....!!! ");
    }   

    public  DataTable GetShowTestSetupDetais()
    {
        string Query = @"SELECT t1.[ID],t1.[TestName],t1.[Fee],t2.TypeName FROM [TestSetup] t1 inner join TestTypeSetup t2 on t2.ID=t1.TestTypeID";
        DataTable dt = DataTransfection.GetShowDataTable(Query, "TestType");
        return dt;
    }

    internal TestSetup GetTestSetup(string ID)
    {
        string Query = @"SELECT [ID],[TestName],[Fee],[TestTypeID] FROM [TestSetup] WHERE [ID]='" + ID + "'";
        DataTable dt = DataTransfection.GetShowDataTable(Query, "TestType");
        if (dt.Rows.Count == 0)
        {
            return null;
        }
        return new TestSetup(dt.Rows[0]);
    }
}