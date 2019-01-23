using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Topnet_v1.Models;

namespace Topnet_v1.Controllers
{
    [Authorize]
    public class DailyParameterController : Controller
    {
        private topnetDATAEntities db = new topnetDATAEntities();



       
        // GET: dailyParameter

        public ActionResult Index(string userName)
        {
            //  return View(db.dailyParameters.ToList());
            var userNames = db.dailyParameters.Where(c => c.userName.StartsWith(userName));
            // var userNames = db.dailyParameters.Find(userName);
            return View(userNames);
        }

        public ActionResult NbDeconnexion()
        {
            List<SelectListItem> lstItems = new List<SelectListItem>();
            var l = (from d in db.dailyParameters
                     select new
                     {
                         d.gouvernerat
                     }).Distinct().ToList();

            foreach (var user in l)
            {
                lstItems.Add(new SelectListItem { Value = user.gouvernerat, Text = user.gouvernerat });
            }
            ViewBag.gouvernerat = lstItems;


            var abc = GetData("2018/02/27", "2018/03/06", null);
            string d1 = "2018/02/27"; string d2 = "2018/03/06";
            var sdtArray = d1.Split('/');
            var edtArray = d2.Split('/');
            DateTime sdt = new DateTime(Convert.ToInt32(sdtArray[0]), Convert.ToInt32(sdtArray[1]), Convert.ToInt32(sdtArray[2]));
            DateTime edt = new DateTime(Convert.ToInt32(edtArray[0]), Convert.ToInt32(edtArray[1]), Convert.ToInt32(edtArray[2]));
            //  var myDurationData = db.moyNBdeonnexionSemaineDynamicDate(sdt, edt);

            ViewBag.DataPoints = JsonConvert.SerializeObject(db.moyNBdeonnexionSemaineDynamicDate(sdt, edt, ""), _jsonSetting);

            return View();
        }






        public ActionResult DureeConnexion()
        {
            List<SelectListItem> lstItems = new List<SelectListItem>();
            var l = (from d in db.dailyParameters
                     select new
                     {
                         d.gouvernerat
                     }).Distinct().ToList();

            foreach (var user in l)
            {
                lstItems.Add(new SelectListItem { Value = user.gouvernerat, Text = user.gouvernerat });
            }
            ViewBag.gouvernerat = lstItems;


            var abc = GetData("2018/02/27", "2018/03/06", null);
            string d1 = "2018/02/27"; string d2 = "2018/03/06";
            var sdtArray = d1.Split('/');
            var edtArray = d2.Split('/');
            DateTime sdt = new DateTime(Convert.ToInt32(sdtArray[0]), Convert.ToInt32(sdtArray[1]), Convert.ToInt32(sdtArray[2]));
            DateTime edt = new DateTime(Convert.ToInt32(edtArray[0]), Convert.ToInt32(edtArray[1]), Convert.ToInt32(edtArray[2]));
            //  var myDurationData = db.moyNBdeonnexionSemaineDynamicDate(sdt, edt);

            ViewBag.DataPoints = JsonConvert.SerializeObject(db.moyDureeConnexionSemaineDynamicDate(sdt, edt, ""), _jsonSetting);

            return View();
        }



        public ActionResult DureeMax()
        {
            List<SelectListItem> lstItems = new List<SelectListItem>();
            var l = (from d in db.dailyParameters
                     select new
                     {
                         d.gouvernerat
                     }).Distinct().ToList();

            foreach (var user in l)
            {
                lstItems.Add(new SelectListItem { Value = user.gouvernerat, Text = user.gouvernerat });
            }
            ViewBag.gouvernerat = lstItems;


            var abc = GetData("2018/02/27", "2018/03/06", null);
            string d1 = "2018/02/27"; string d2 = "2018/03/06";
            var sdtArray = d1.Split('/');
            var edtArray = d2.Split('/');
            DateTime sdt = new DateTime(Convert.ToInt32(sdtArray[0]), Convert.ToInt32(sdtArray[1]), Convert.ToInt32(sdtArray[2]));
            DateTime edt = new DateTime(Convert.ToInt32(edtArray[0]), Convert.ToInt32(edtArray[1]), Convert.ToInt32(edtArray[2]));
            //  var myDurationData = db.moyNBdeonnexionSemaineDynamicDate(sdt, edt);

            ViewBag.DataPoints = JsonConvert.SerializeObject(db.maxConnexionSemaineDynamicDate(sdt, edt, ""), _jsonSetting);

            return View();
        }


        public ActionResult DureeMin()
        {
            List<SelectListItem> lstItems = new List<SelectListItem>();
            var l = (from d in db.dailyParameters
                     select new
                     {
                         d.gouvernerat
                     }).Distinct().ToList();

            foreach (var user in l)
            {
                lstItems.Add(new SelectListItem { Value = user.gouvernerat, Text = user.gouvernerat });
            }
            ViewBag.gouvernerat = lstItems;


            var abc = GetData("2018/02/27", "2018/03/06", null);
            string d1 = "2018/02/27"; string d2 = "2018/03/06";
            var sdtArray = d1.Split('/');
            var edtArray = d2.Split('/');
            DateTime sdt = new DateTime(Convert.ToInt32(sdtArray[0]), Convert.ToInt32(sdtArray[1]), Convert.ToInt32(sdtArray[2]));
            DateTime edt = new DateTime(Convert.ToInt32(edtArray[0]), Convert.ToInt32(edtArray[1]), Convert.ToInt32(edtArray[2]));
            //  var myDurationData = db.moyNBdeonnexionSemaineDynamicDate(sdt, edt);

            ViewBag.DataPoints = JsonConvert.SerializeObject(db.minConnexionSemaineDynamicDate(sdt, edt, ""), _jsonSetting);

            return View();
        }




        public JsonResult GetData(string d1, string d2, string gouvernerat)
        {
            dynamic obj = new ExpandoObject();
            try
            {
                var sdtArray = d1.Split('/');
                var edtArray = d2.Split('/');
                DateTime sdt = new DateTime(Convert.ToInt32(sdtArray[0]), Convert.ToInt32(sdtArray[1]), Convert.ToInt32(sdtArray[2]));
                DateTime edt = new DateTime(Convert.ToInt32(edtArray[0]), Convert.ToInt32(edtArray[1]), Convert.ToInt32(edtArray[2]));
                var myDurationData = db.moyNBdeonnexionSemaineDynamicDate(sdt, edt, gouvernerat);
                var mySessionData = db.moyDureeConnexionSemaineDynamicDate(sdt, edt, gouvernerat);
                var myMaxData = db.maxConnexionSemaineDynamicDate(sdt, edt, gouvernerat);
                var myMinData = db.minConnexionSemaineDynamicDate(sdt, edt, gouvernerat);

              
                obj.dur = myDurationData;
                obj.dur1 = mySessionData;
                obj.dur2 = myMaxData;
                obj.dur3 = myMinData;
              

            }
            catch (Exception ex) {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }

            return Json(obj, JsonRequestBehavior.AllowGet);
            //      var gouvAVGnbTotal = db.moyNBdeonnexionSemaineDynamicGouvernerat(sdt, edt);


        }


        public ActionResult Dashboard()
        {
            string moy;
            string max;
            string min;
            string nb;

            string dateSemaineDeb;
            var l = db.moyDureeConnexionSemaine().AsQueryable().First().ToString();
            var lmax = db.maxDureeConnexionSemaine().AsQueryable().First().ToString();
            var lmin = db.minDureeConnexionSemaine().AsQueryable().First().ToString();
            var lnb = db.moyNBdeonnexionSemaine().AsQueryable().First().ToString();


            moy = l;
            max = lmax;
            min = lmin;
            nb = lnb;

            dateSemaineDeb =
            ViewBag.moySession = moy;
            ViewBag.maxSession = max;
            ViewBag.minSession = min;
            ViewBag.nbDeconnexion = nb;

            DateTime dateSemainefin = new DateTime(2018, 03, 31);
            DateTime dateSemainedeb = new DateTime(2018, 03, 31).AddDays(-7);

            // DateTime edt = new DateTime(Convert.ToInt32(edtArray[0]), Convert.ToInt32(edtArray[1]), Convert.ToInt32(edtArray[2]));


            ViewBag.dateSemainefin = dateSemainefin.ToString("D", CultureInfo.CreateSpecificCulture("fr-FR"));
            ViewBag.dateSemainedeb = dateSemainedeb.ToString("D", CultureInfo.CreateSpecificCulture("fr-FR"));
            // ViewBag.dateSemaineDeb = dateSemaineDeb;
            // var myNBSemaineGouv = db.moyNbDeconnexionSemaineParGouvernerat();
            ViewBag.DataPoints = JsonConvert.SerializeObject(db.moyNbDeconnexionSemaineParGouvernerat(), _jsonSetting);

            ViewBag.DataPointsDureeSession = JsonConvert.SerializeObject(db.moyDureeConnexionParJourParGouvernerat(), _jsonSetting);


            ViewBag.DataPointsGeoCarte = JsonConvert.SerializeObject(db.carteGeoChartMoyConnexionNbPersonne(), _jsonSetting);


            return View();
        }
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        //public JsonResult GetDataDashboard()
        //{

        //    var myNBSemaineGouv = db.moyNbDeconnexionSemaineParGouvernerat();

        //    dynamic obj = new ExpandoObject();
        //    obj.dur = myNBSemaineGouv;

        //    return Json(obj, JsonRequestBehavior.AllowGet);
        //}
    }
}