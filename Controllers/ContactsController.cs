using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using hrcloud_test.Models;
using System.Web.Mvc;

namespace hrcloud_test.Controllers
{
    public class ContactsController : Controller
    {
        private ContactListContext db = new ContactListContext();

        // GET: api/Contacts
        [HttpGet]
        [Route("api/Contacts")]
        public JsonResult GetContact()
        {
            var query = from c in db.Contact
                        select new SimpleContact
                        {
                            ContactId = c.ContactId,
                            Tag = c.Tag,
                            Name = c.Name,
                            Surname = c.Surname,
                            Address = c.Address,
                        };
            return this.Json(query, JsonRequestBehavior.AllowGet);
        }

        // GET: api/Contacts/5
        [HttpGet]
        [Route("api/Contacts/{id}")]
        public JsonResult GetContact(int id)
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
            return this.Json(query, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("api/Contacts/search/{target}")]
        public JsonResult GetByString(string target) {
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
            return this.Json(query, JsonRequestBehavior.AllowGet);
        }

        // PUT: api/Contacts/5
        [HttpPut]
        [Route("api/Contacts/{id}")]
        public HttpStatusCodeResult PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
            }

            if (id != contact.ContactId)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
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
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Not Found");
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.NoContent, "No Content");
        }

        // POST: api/Contacts
        [HttpPost]
        [Route("api/Contacts")]
        public HttpStatusCodeResult PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
            }

            db.Contact.Add(contact);
            db.SaveChanges();

            return new HttpStatusCodeResult(HttpStatusCode.OK, "OK");
        }

        // DELETE: api/Contacts/5
        [HttpDelete]
        [Route("api/Contacts/{id}")]
        public HttpStatusCodeResult DeleteContact(int id)
        {
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Not Found");
            }

            db.Contact.Remove(contact);
            db.SaveChanges();

            return new HttpStatusCodeResult(HttpStatusCode.OK, "OK");
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