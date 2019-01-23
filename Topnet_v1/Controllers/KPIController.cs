using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Topnet_v1.Models;

namespace Topnet_v1.Controllers
{
    public class KPIController : Controller
    {
        // GET: KPI
        topnetDATAEntities db = new topnetDATAEntities();
      
        public KPIController()
        {
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View();

        }
        //public ActionResult Create()
        //{
           
        //    return View();
        //}


    

        public ActionResult Create()
        {
            var lstKPI = new List<KPI>();
            lstKPI = db.KPIs.ToList();
            List<SelectListItem> lstItems = new List<SelectListItem>();
            foreach (var kpi in lstKPI)
            {
                lstItems.Add(new SelectListItem { Value = kpi.nomKPI, Text = kpi.nomKPI });
            }

            ViewBag.nomKPIs = lstItems;

            var lstUsers = new List<ligneADSL>();
            lstUsers = db.ligneADSLs.ToList();
            List<SelectListItem> lstItemsk = new List<SelectListItem>();
            foreach (var user in lstUsers)
            {
                lstItemsk.Add(new SelectListItem { Value = user.userName, Text = user.userName });
            }

            ViewBag.users = lstItemsk;
           // var abc = insertData("0000006@topnet.tn","Durée moyenne de connexion", new DateTime(2018, 02, 14), new DateTime(2018, 02, 27));
            return View();
        }





        public JsonResult insertData(string username,string nomKPI, string d1, string d2)
        {
            var sdtArray = d1.Split('/');
            var edtArray = d2.Split('/');
            DateTime sdt = new DateTime(Convert.ToInt32(sdtArray[0]), Convert.ToInt32(sdtArray[1]), Convert.ToInt32(sdtArray[2]));
            DateTime edt = new DateTime(Convert.ToInt32(edtArray[0]), Convert.ToInt32(edtArray[1]), Convert.ToInt32(edtArray[2]));

            var myData = db.USERkpi(username,nomKPI, sdt, edt);

            var mydataMax = (from l in db.ligneADSLs
                             join h in db.historiqueKPIs on l.numSequence equals h.numSequence
                             join k in db.KPIs on h.idKPI equals k.idKPI
                             select new
                             {
                                 l.userName,
                                 l.gouvernerat,
                                 h.idKPI,
                                 k.nomKPI,
                                 h.valeurKPI,
                                 h.dateHistoriqueKPI
                             }).Distinct().Where(x => x.nomKPI == nomKPI && x.userName == username && x.dateHistoriqueKPI >= sdt && x.dateHistoriqueKPI <= edt)
                     .ToList();


            dynamic obj = new ExpandoObject();
            obj.dur = myData;
            obj.max = mydataMax;

            return Json(obj, JsonRequestBehavior.AllowGet);
        }



    }



}