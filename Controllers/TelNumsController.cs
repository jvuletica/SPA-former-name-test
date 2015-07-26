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
    public class TelNumsController : ApiController
    {
        private ContactListContext db = new ContactListContext();

        public class Tel
        {
            public int Number { get; set; }
            public int Id { get; set; }
        }
        // GET: api/TelNums/5
        [ResponseType(typeof(Tel))]
        public List<Tel> GetTelNum(int id)
        {
            var query = from t in db.TelNum
                        where t.ContactId == id
                        select new Tel
                        {
                            Number = t.Number,
                            Id = t.TelNumId
                        };
            return query.ToList();
        }

        // POST: api/TelNums
        [ResponseType(typeof(TelNum))]
        public IHttpActionResult PostTelNum(TelNum telNum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TelNum.Add(telNum);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = telNum.TelNumId }, telNum);
        }

        // DELETE: api/TelNums/5
        [ResponseType(typeof(TelNum))]
        public IHttpActionResult DeleteTelNum(int id)
        {
            TelNum telNum = db.TelNum.Find(id);
            if (telNum == null)
            {
                return NotFound();
            }

            db.TelNum.Remove(telNum);
            db.SaveChanges();

            return Ok(telNum);
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