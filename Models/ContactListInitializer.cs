using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hrcloud_test.Models
{
    //create db on first run or model change
    public class ContactListInitializer : System.Data.Entity.
        DropCreateDatabaseIfModelChanges<ContactListContext>
    {
        //initialize data in tables
        protected override void Seed(ContactListContext context)
        {
            var contacts = new List<Contact>
            {
                new Contact{ContactId=1, Name="Mate", Surname="Matic", Address="Zrinsko Frankopanska 22"},
                new Contact{ContactId=2, Name="Ante", Surname="Antic", Address="Vukovarska 112"},
                new Contact{ContactId=3, Name="Ivo", Surname="Ivic", Address="Dalmatinska 13"}
            };
            contacts.ForEach(c => context.Contact.Add(c));
            context.SaveChanges();

            var telnum = new List<TelNum>
            {
                new TelNum{Number=111222, ContactId=1},
                new TelNum{Number=222333, ContactId=1},
                new TelNum{Number=333444, ContactId=1},
                new TelNum{Number=444555, ContactId=2},
                new TelNum{Number=555666, ContactId=3}
            };
            telnum.ForEach(t => context.TelNum.Add(t));
            context.SaveChanges();

            var email = new List<EmailAddr>
            {
                new EmailAddr{Address="mate@gmail.com", ContactId=1},
                new EmailAddr{Address="ante@gmail.com", ContactId=2},
                new EmailAddr{Address="ivo@gmail.com", ContactId=3},
                new EmailAddr{Address="ivodva@gmail.com", ContactId=3}
            };
            email.ForEach(e => context.EmailAddr.Add(e));
            context.SaveChanges();
        }
    }
}