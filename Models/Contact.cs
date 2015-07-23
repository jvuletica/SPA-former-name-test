using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hrcloud_test.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public virtual ICollection<EmailAddr> EmailAddr { get; set; }
        public virtual ICollection<TelNum> TelNum { get; set; }
    }
}