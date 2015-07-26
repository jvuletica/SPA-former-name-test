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
    public class EmailAddrsController : ApiController
    {
        private ContactListContext db = new ContactListContext();

        public class Email
        {
            public string Address { get; set; }
            public int Id { get; set; }
        }

        // GET: api/EmailAddrs/5
        [ResponseType(typeof(List<Email>))]
        public List<Email> GetEmailAddr(int id)
        {
            var query = from e in db.EmailAddr
                        where e.ContactId == id
                        select new Email
                        {
                            Address = e.Address,
                            Id = e.EmailAddrId
                        };
            return query.ToList();
        }

        // POST: api/EmailAddrs
        [ResponseType(typeof(EmailAddr))]
        public IHttpActionResult PostEmailAddr(EmailAddr emailAddr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmailAddr.Add(emailAddr);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = emailAddr.EmailAddrId }, emailAddr);
        }

        // DELETE: api/EmailAddrs/5
        [ResponseType(typeof(EmailAddr))]
        public IHttpActionResult DeleteEmailAddr(int id)
        {
            EmailAddr emailAddr = db.EmailAddr.Find(id);
            if (emailAddr == null)
            {
                return NotFound();
            }

            db.EmailAddr.Remove(emailAddr);
            db.SaveChanges();

            return Ok(emailAddr);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmailAddrExists(int id)
        {
            return db.EmailAddr.Count(e => e.EmailAddrId == id) > 0;
        }
    }
}