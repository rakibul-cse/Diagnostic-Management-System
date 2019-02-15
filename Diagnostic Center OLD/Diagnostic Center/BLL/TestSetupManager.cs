using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diagnostic_Center.BLL
{
    public class TestSetupManager
    {
        TestSetupGetaway aTestSetupGetaway = new TestSetupGetaway();
        internal string SaveTestSetupInformation(TestSetup aTestSetup)
        {
            if (aTestSetup.TestName=="")
            {
                throw new Exception("Enter Test name ....!!!!!");
            }
            if (aTestSetup.TestTypeID == "")
            {
                throw new Exception("Select Test....!!!!!");
            }
            TestSetup aTest = aTestSetupGetaway.GetTestSetup(aTestSetup.ID);
            if (aTest!=null)
            {
                return aTestSetupGetaway.UpdateTestSetupInformation(aTestSetup);
            }
            return aTestSetupGetaway.SaveTestSetupInformation(aTestSetup);
        }
        internal DataTable GetShowTestSetupDetais()
        {
            return aTestSetupGetaway.GetShowTestSetupDetais();
        }

        internal TestSetup GetTestSetup(string ID)
        {
           return aTestSetupGetaway.GetTestSetup(ID);
        }
    }
}