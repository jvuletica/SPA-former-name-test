using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hrcloud_test.Models
{
    public class SimpleContact
    {
        public int ContactId { get; set; }
        public string Tag { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
    }
}