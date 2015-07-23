using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hrcloud_test.Models;

namespace hrcloud_test.Controllers
{
    public class HomeController : Controller
    {
        private ContactListContext db = new ContactListContext();
        public JsonResult Index()
        {
            var query = from c in db.Contact
                        join id in db.EmailAddr
                        on c.ContactId equals id.ContactId
                        select new
                        {
                            Name = c.Name,
                            Surname = c.Surname,
                            Address = c.Address,
                            EmailAddress = id.Address
                        };
            return Json(query, JsonRequestBehavior.AllowGet);
        }
    }
}