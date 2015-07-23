using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace hrcloud_test.Models
{
    public class ContactListContext : DbContext
    {
        //constructor with connection string
        public ContactListContext() : base("ContactListContext") { }

        //create tables with corresponding columns
        public DbSet<Contact> Contact { get; set; }
        public DbSet<EmailAddr> EmailAddr { get; set; }
        public DbSet<TelNum> TelNum { get; set; }
    }
}