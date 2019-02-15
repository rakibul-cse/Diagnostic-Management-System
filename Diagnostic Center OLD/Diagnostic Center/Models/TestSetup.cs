using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TestSetup
/// </summary>
public class TestSetup
{
  //  public string ID, TestName, Fee, TestTypeID;
	public TestSetup()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    

    public string ID { get; set; }

    public string TestName { get; set; }

    public string Fee { get; set; }

    public string TestTypeID { get; set; }
    public TestSetup(DataRow dr)
    {
        if (dr["ID"].ToString() != string.Empty)
        {
            this.ID = dr["ID"].ToString();
        }
        if (dr["TestName"].ToString() != string.Empty)
        {
            this.TestName = dr["TestName"].ToString();
        }
        if (dr["Fee"].ToString() != string.Empty)
        {
            this.Fee = dr["Fee"].ToString();
        }
        if (dr["TestTypeID"].ToString() != string.Empty)
        {
            this.TestTypeID = dr["TestTypeID"].ToString();
        }
    }
}