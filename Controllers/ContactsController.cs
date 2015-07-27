using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using hrcloud_test.Models;

namespace hrcloud_test.Controllers
{
    public class ContactsController : ApiController
    {
        private ContactListContext db = new ContactListContext();

        public class SimpleContact
        {
            public int ContactId { get; set; }
            public string Tag { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Address { get; set; }
        }

        // GET: api/Contacts
        [Route("api/Contacts")]
        public List<Contact> GetContact()
        {
            return db.Contact.ToList();
        }

        // GET: api/Contacts/5
        [Route("api/Contacts/{id}")]
        [ResponseType(typeof(Contact))]
        public IHttpActionResult GetContact(int id)
        {
            var query = from c in db.Contact
                        where c.ContactId == id
                        select new SimpleContact
                        {
                            ContactId = c.ContactId,
                            Tag = c.Tag,
                            Name = c.Name,
                            Surname = c.Surname,
                            Address = c.Address,
                        };
            return Ok(query.ToList());
        }

        [Route("api/Contacts/search/{target}")]
        public List<SimpleContact> GetByString(string target) {
            var query = from c in db.Contact
                        where (c.Tag.Contains(target))
                        ||(c.Name.Contains(target))
                        || (c.Surname.Contains(target))
                        select new SimpleContact
                        {
                            ContactId = c.ContactId,
                            Tag = c.Tag,
                            Name = c.Name,
                            Surname = c.Surname,
                            Address = c.Address,
                        };
                return query.ToList();
        }

        // PUT: api/Contacts/5
        [Route("api/Contacts/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.ContactId)
            {
                return BadRequest();
            }

            db.Entry(contact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Contacts
        [Route("api/Contacts")]
        [ResponseType(typeof(Contact))]
        public IHttpActionResult PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contact.Add(contact);
            db.SaveChanges();

            return Ok(contact);
        }

        // DELETE: api/Contacts/5
        [Route("api/Contacts/{id}")]
        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            db.Contact.Remove(contact);
            db.SaveChanges();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return db.Contact.Count(e => e.ContactId == id) > 0;
        }
    }
}