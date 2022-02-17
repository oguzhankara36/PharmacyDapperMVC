using Dapper;
using MVCDAPPERECZANE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDAPPERECZANE.Controllers
{
    public class FirmalarController : Controller
    {
        // GET: Firmalar
        public ActionResult Index()
        {
            return View(DP.ReturnList<FirmalarModel>("firmalistele"));
        }
        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@firmaNo", id);
                return View(DP.ReturnList<FirmalarModel>("firmasirala", param).FirstOrDefault<FirmalarModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(FirmalarModel mus)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@firmaNo", mus.firmaNo);
            param.Add("@firmaadi", mus.firmaadi);
            param.Add("@firmaciro", mus.firmaciro);
            param.Add("@firmaadres", mus.firmaadres);
            param.Add("@firmatelefon", mus.firmatelefon);
            param.Add("@firmafaks", mus.firmafaks);
            DP.ExecuteWithoutReturn("firmaey", param);
            return RedirectToAction("Index");
        }
        public ActionResult DELETE(int id = 0)
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("@firmaNo", id);
            DP.ExecuteWithoutReturn("firmasil", param);
            return RedirectToAction("Index");

        }
    }
}