using Dapper;
using MVCDAPPERECZANE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDAPPERECZANE.Controllers
{
    public class mumessilController : Controller
    {
        // GET: mumessil
        public ActionResult Index()
        {
            return View(DP.ReturnList<mumessilModel>("mumessillistele"));
        }
        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@mno", id);
                return View(DP.ReturnList<mumessilModel>("mumessilsirala", param).FirstOrDefault<mumessilModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(mumessilModel mus)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@mno", mus.mno);
            param.Add("@adsoyad", mus.adsoyad);
            param.Add("@hedefsatis", mus.hedefsatis);
            param.Add("@bolge", mus.bolge);
            param.Add("@mudur", mus.mudur);
            DP.ExecuteWithoutReturn("mumessiley", param);
            return RedirectToAction("Index");
        }
        public ActionResult DELETE(int id = 0)
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("@mno", id);
            DP.ExecuteWithoutReturn("mumessilsil", param);
            return RedirectToAction("Index");

        }
    }
}