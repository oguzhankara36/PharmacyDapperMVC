using Dapper;
using MVCDAPPERECZANE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDAPPERECZANE.Controllers
{
    public class ilaclarController : Controller
    {
        // GET: ilaclar
        public ActionResult Index()
        {
            return View(DP.ReturnList<ilaclarModel>("ilaclistele"));
        }
        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ilacNo", id);
                return View(DP.ReturnList<ilaclarModel>("ilacsirala", param).FirstOrDefault<ilaclarModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(ilaclarModel mus)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ilacNo", mus.ilacNo);
            param.Add("@ilacadi", mus.ilacadi);
            param.Add("@ilacfiyat", mus.ilacfiyat);
            param.Add("@ilacadet", mus.ilacadet);
            DP.ExecuteWithoutReturn("ilacey", param);
            return RedirectToAction("Index");
        }
        public ActionResult DELETE(int id = 0)
        {

            DynamicParameters param = new DynamicParameters();
            param.Add("@ilacNo", id);
            DP.ExecuteWithoutReturn("ilacsil", param);
            return RedirectToAction("Index");

        }
    }
}