using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoinFree.Data;


namespace CoinFree.Web.Controllers
{
    public class HomeController : Controller
    {
        private CoinFreeDbContext _context;
        public HomeController()
        {
            _context = new CoinFreeDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public JsonResult GetUser()
        {
            var model = _context.Users.OrderByDescending(x=>x.UpdateDate);
            int totalRow = _context.Users.Count();
            return Json(new
            {
                data = model,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}