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
    public class EmailAddrsController : Controller
    {
        private ContactListContext db = new ContactListContext();

        public class Email
        {
            public string Address { get; set; }
            public int Id { get; set; }
        }

        // GET: api/EmailAddrs/5
        [HttpGet]
        [Route("api/EmailAddrs/{id}")]
        public JsonResult GetEmailAddr(int id)
        {
            var query = from e in db.EmailAddr
                        where e.ContactId == id
                        select new Email
                        {
                            Address = e.Address,
                            Id = e.EmailAddrId
                        };
            return this.Json(query, JsonRequestBehavior.AllowGet);
        }

        // POST: api/EmailAddrs
        [HttpPost]
        [Route("api/EmailAddrs/{id}")]
        public HttpStatusCodeResult PostEmailAddr(EmailAddr emailAddr)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
            }

            db.EmailAddr.Add(emailAddr);
            db.SaveChanges();

            return new HttpStatusCodeResult(HttpStatusCode.OK, "OK");
        }

        // DELETE: api/EmailAddrs/5
        [HttpDelete]
        [Route("api/EmailAddrs/{id}")]
        public HttpStatusCodeResult DeleteEmailAddr(int id)
        {
            EmailAddr emailAddr = db.EmailAddr.Find(id);
            if (emailAddr == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Not Found");
            }

            db.EmailAddr.Remove(emailAddr);
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

        private bool EmailAddrExists(int id)
        {
            return db.EmailAddr.Count(e => e.EmailAddrId == id) > 0;
        }
    }
}