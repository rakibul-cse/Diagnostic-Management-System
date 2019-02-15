using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagnostic_Center.Models
{
    public class TestRequest
    {
        CheckCon aCheckCon=new CheckCon();
        public string PatientName { get; set; }

        public string DateOfBirth { get; set; }

        public string MobileNumber { get; set; }
    }
}