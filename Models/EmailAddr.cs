using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hrcloud_test.Models
{
    public class EmailAddr
    {
        public int EmailAddrId { get; set; }
        public string Address { get; set; }
        public virtual Contact Contact { get; set; }
        public int ContactId { get; set; }
    }
}