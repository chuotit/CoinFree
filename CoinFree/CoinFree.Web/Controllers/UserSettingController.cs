using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CoinFree.Data;
using CoinFree.Data.Models;

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
            var payoutList = _context.UserSettings.Where(x=>x.GameType == gameType && x.CoinAddress == coinAddress);
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

        [HttpPost]
        public JsonResult SaveUserSetting(string strUserSetting)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            UserSetting userSetting = serializer.Deserialize<UserSetting>(strUserSetting);
            userSetting.Payout = Convert.ToDouble(userSetting.Payout);
            bool status = false;
            var message = string.Empty;
            if(userSetting.Id == 0)
            {
                _context.UserSettings.Add(userSetting);
                try
                {
                    _context.SaveChanges();
                    status = true;
                }
                catch (Exception ex)
                {
                    status = false;
                    message = ex.Message;
                }
            } else
            {
                var entiry = _context.UserSettings.Find(userSetting.Id);
                entiry.BetMode = userSetting.BetMode;
                entiry.BtcBetBase = userSetting.BtcBetBase;
                entiry.BetTarget = userSetting.BetTarget;
                entiry.BetSpeed = userSetting.BetSpeed;
                entiry.BetProbe = userSetting.BetProbe;
                entiry.BtcPlus = userSetting.BtcPlus;
                try
                {
                    _context.SaveChanges();
                    status = true;
                } catch(Exception ex)
                {
                    status = false;
                    message = ex.Message;
                }
            }
            return Json(
                new
                {
                    status = status,
                    message = message
                });
        }

        public JsonResult DeleteUserSetting(int id)
        {
            var entity = _context.UserSettings.Find(id);
            _context.UserSettings.Remove(entity);
            try
            {
                _context.SaveChanges();
                return Json(new
                {
                    status = true,
                    message = "OK"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    message = ex.Message
                });
            }
        }
    }
}