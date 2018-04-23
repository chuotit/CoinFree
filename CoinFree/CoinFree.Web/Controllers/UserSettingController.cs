using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoinFree.Data;

namespace CoinFree.Web.Controllers
{
    public class UserSettingController : Controller
    {
        private CoinFreeDbContext _context;
        public UserSettingController()
        {
            _context = new CoinFreeDbContext();
        }

        // GET: UserSetting
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetPayout (string gameType, string coinAddress)
        {
            var payoutList = _context.UserSettings.Where(x=>x.GameType == gameType && x.CoinAddress ==coinAddress).Select(x=>x.Payout);
            return Json(new
            {
                payoutList
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSetting(string gameType, double payout, string coinAddress)
        {
            var userSetting = _context.UserSettings.Where(x => x.GameType == gameType && x.Payout == payout && x.CoinAddress == coinAddress);
            return Json(new
            {
                userSetting
            }, JsonRequestBehavior.AllowGet);
        }
    }
}