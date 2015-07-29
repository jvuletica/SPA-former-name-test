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
    public class TelNumsController : Controller
    {
        private ContactListContext db = new ContactListContext();

        public class Tel
        {
            public int Number { get; set; }
            public int Id { get; set; }
        }
        // GET: api/TelNums/5
        [HttpGet]
        [Route("api/TelNums/{id}")]
        public JsonResult GetTelNum(int id)
        {
            var query = from t in db.TelNum
                        where t.ContactId == id
                        select new Tel
                        {
                            Number = t.Number,
                            Id = t.TelNumId
                        };
            return this.Json(query, JsonRequestBehavior.AllowGet);
        }

        // POST: api/TelNums
        [HttpPost]
        [Route("api/TelNums/{id}")]
        public HttpStatusCodeResult PostTelNum(TelNum telNum)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
            }

            db.TelNum.Add(telNum);
            db.SaveChanges();

            return new HttpStatusCodeResult(HttpStatusCode.OK, "OK");
        }

        // DELETE: api/TelNums/5
        [HttpDelete]
        [Route("api/TelNums/{id}")]
        public HttpStatusCodeResult DeleteTelNum(int id)
        {
            TelNum telNum = db.TelNum.Find(id);
            if (telNum == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Not Found");
            }

            db.TelNum.Remove(telNum);
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

        private bool TelNumExists(int id)
        {
            return db.TelNum.Count(e => e.TelNumId == id) > 0;
        }
    }
}