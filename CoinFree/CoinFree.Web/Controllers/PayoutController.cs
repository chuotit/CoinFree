using CoinFree.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoinFree.Web.Controllers
{
    public class PayoutController : Controller
    {
        private CoinFreeDbContext _context;
        public PayoutController()
        {
            _context = new CoinFreeDbContext();
        }

        [HttpGet]
        public JsonResult GetPayout(string address)
        {
            var model = _context.Payouts.OrderBy(x=>x.Order);
            return Json( new {
                items = model,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}