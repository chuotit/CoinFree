using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoinFree.Data;

namespace CoinFree.Web.Controllers
{
    public class UserController : Controller
    {
        private CoinFreeDbContext _context;
        public UserController()
        {
            _context = new CoinFreeDbContext();
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetUser()
        {
            var model = _context.Users.OrderByDescending(x => x.UpdateDate);
            int totalRow = _context.Users.Count();
            return Json(new
            {
                data = model,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUserInfo(string userId)
        {
            var user = _context.Users.Where(x => x.UserID == userId);
            return Json(new
            {
                user
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CheckUserByEmail(string email)
        {
            var status = false;
            if (_context.Users.Where(x => x.Email == email).Count() == 1)
            {
                status = true;
            } else
            {
                status = false;
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CheckUserByCoinAddress(string address)
        {
            var status = false;
            if (_context.Users.Where(x => x.CoinAddress == address).Count() == 1)
            {
                status = true;
            }
            else
            {
                status = false;
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}