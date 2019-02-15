using Diagnostic_Center.Getaway;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TestTypeSetupManager
/// </summary>
public class TestTypeSetupManager
{
    TestTypeSetupGetaway aTestTypeSetupGetaway = new TestTypeSetupGetaway();
	public TestTypeSetupManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}   
    internal DataTable GetShowItemsDetails()
    {
        return aTestTypeSetupGetaway.GetShowTestTypeSetupDetails();
    }

    internal string SaveTestTypeInformation(TestTypeSetup aTestTypeSetup)
    {
        if(aTestTypeSetup.Name=="")
        {
            throw new Exception("Enter Test Type Name......!!!!");
        }
         int Count = DataTransfection.GetShowSingleValueInt("COUNT(*)", "ID", "TestTypeSetup", aTestTypeSetup.ID);
         if (Count > 0)
         {
             return aTestTypeSetupGetaway.GetUpdateTestSetupInfo(aTestTypeSetup);
         }
        return aTestTypeSetupGetaway.GetSaveTestSetupInfo(aTestTypeSetup);
    }    
}