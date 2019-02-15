using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagnostic_Center.Models
{
    public class PaymentInfo : TestRequest
    {

        public string ID { get; set; }

        public string PaymentAmount { get; set; }
    }
}