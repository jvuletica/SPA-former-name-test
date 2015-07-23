using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hrcloud_test.Models
{
    public class TelNum
    {
        public int TelNumId { get; set; }
        public int Number { get; set; }
        public virtual Contact Contact { get; set; }
        public int ContactId { get; set; }
    }
}