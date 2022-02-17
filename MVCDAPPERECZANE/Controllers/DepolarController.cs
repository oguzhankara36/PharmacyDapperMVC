using MVCDAPPERECZANE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDAPPERECZANE.Models;
using Dapper;

namespace MVCDAPPERECZANE.Controllers
{
    public class DepolarController : Controller
    {
        // GET: Depolar
        public ActionResult Index()
        {
            return View(DP.ReturnList<DepolarModel>("depolistele"));
        }
        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@depono", id);
                return View(DP.ReturnList<DepolarModel>("deposirala", param).FirstOrDefault<DepolarModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(DepolarModel mus)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@depono", mus.depono);
            param.Add("@depoadi", mus.depoadi);
            param.Add("@depobolge", mus.depobolge);
            param.Add("@deposorumlusu", mus.deposorumlusu);
            DP.ExecuteWithoutReturn("depoey", param);
            return RedirectToAction("Index");
        }
        public ActionResult DELETE(int id = 0)
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("@depono", id);
            DP.ExecuteWithoutReturn("deposil", param);
            return RedirectToAction("Index");

        }
    }
}