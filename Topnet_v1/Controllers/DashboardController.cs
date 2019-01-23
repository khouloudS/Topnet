using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using Topnet_v1.Models;
using System.Collections;
using System.Threading.Tasks;
using System.Dynamic;
using Newtonsoft.Json;
using System.Globalization;

namespace Topnet_v1.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private topnetDATAEntities db = new topnetDATAEntities();
        // GET: dashborad
        public ActionResult Index(string username)
        {
            var lstUsers = new List<ligneADSL>();
            lstUsers = db.ligneADSLs.ToList();
            List<SelectListItem> lstItems = new List<SelectListItem>();
            foreach (var user in lstUsers)
            {
                lstItems.Add(new SelectListItem { Value = user.userName, Text = user.userName });
            }

            ViewBag.users = lstItems;

            DateTime dateSemainefin = new DateTime(2018, 03, 31);
            DateTime dateSemainedeb = new DateTime(2018, 03, 31).AddDays(-7);
            ViewBag.dateSemainefin = dateSemainefin.ToString("D", CultureInfo.CreateSpecificCulture("fr-FR"));
            ViewBag.dateSemainedeb = dateSemainedeb.ToString("D", CultureInfo.CreateSpecificCulture("fr-FR"));

            ViewBag.DataPoints = JsonConvert.SerializeObject(db.DetailBarreReferenceAvecDate("Durée moyenne de connexion"), _jsonSetting);
            ViewBag.DataPointsMax = JsonConvert.SerializeObject(db.referenceKPIDureeMaximale("Durée maximale de connexion"), _jsonSetting);
            ViewBag.DataPointsnB = JsonConvert.SerializeObject(db.referenceKPINbDeconnexion("Nombre de déconnexion"), _jsonSetting);
            ViewBag.DataPointsMin = JsonConvert.SerializeObject(db.referenceKPIDureeMinimale("Durée minimale de connexion"), _jsonSetting);

            return View();
        }

        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        };


        public ActionResult sessionHistorique(string username)
        {
            var lstUsers = new List<ligneADSL>();
            lstUsers = db.ligneADSLs.ToList();
            List<SelectListItem> lstItems = new List<SelectListItem>();
            foreach (var user in lstUsers)
            {
                lstItems.Add(new SelectListItem { Value = user.userName, Text = user.userName });
            }

            ViewBag.users = lstItems;
            DateTime dateSemainefin = new DateTime(2018, 03, 31);
            DateTime dateSemainedeb = new DateTime(2018, 03, 31).AddDays(-7);



            ViewBag.dateSemainefin = dateSemainefin.ToString("D", CultureInfo.CreateSpecificCulture("fr-FR"));
            ViewBag.dateSemainedeb = dateSemainedeb.ToString("D", CultureInfo.CreateSpecificCulture("fr-FR"));
            ViewBag.DataPoints = JsonConvert.SerializeObject(db.historiqueConnexion(username,dateSemainedeb,dateSemainefin), _jsonSetting);
            return View();
        }

        public ActionResult Icon(string username)
        {
           
            string moy;
            string max;
            string min;
            string nb;
            // string dateSemaine;
            var l = db.moyDureeConnexionSemaineUser(username).AsQueryable().First().ToString();
            var lmax = db.maxDureeConnexionSemaineUser(username).AsQueryable().First().ToString();
            var lmin = db.minDureeConnexionSemaineUser(username).AsQueryable().First().ToString();
            var lnb = db.moyNBdeonnexionSemaineUser(username).AsQueryable().First().ToString();
            //   var ldt = db.moyNBdeonnexionSemaineUser(username).AsQueryable().First().ToString();

            DateTime edt = new DateTime(2018, 03, 31);
            DateTime sdt = new DateTime(2018, 03, 31).AddDays(-7);
            

            moy = l;
            max = lmax;
            min = lmin;
            nb = lnb;
            //   dateSemaine = ldt;
            ViewBag.moySession = moy;
            ViewBag.maxSession = max;
            ViewBag.minSession = min;
            ViewBag.nbDeconnexion = nb;
            //    ViewBag.dateSemaine = dateSemaine;
            ViewBag.referenceKPIMoySession = JsonConvert.SerializeObject(db.referenceDureeMoyenneConnexion(sdt, edt, username), _jsonSetting);

            return PartialView("Icon");
        }


        public JsonResult GetData(string username )
        {
            //string d1 = "";
            //string d2 = "";
           
            DateTime edt = new DateTime(2018, 03, 31);
            DateTime sdt = new DateTime(2018, 03, 31).AddDays(-7);
            var myDurationData = (from d in db.dailyParameters

                                  select new
                                  {
                                      d.numSequence,
                                      d.userName,
                                      d.gouvernerat,
                                      d.date,
                                      d.dureeConnexionParJour,
                                      d.dureeDeconnexionParJour,


                                  }).Where(x => x.userName == username && x.date >= sdt && x.date <= edt)
                     .ToList();

            var myNumberData = (from d in db.dailyParameters
                                select new
                                {
                                    d.numSequence,
                                    d.userName,
                                    d.gouvernerat,
                                    d.date,
                                    d.nbDeconnexionParJour

                                }).Where(x => x.userName == username && x.date >= sdt && x.date <= edt)
                     .ToList();


            var mySessionData = (from s in db.historiqueSessions
                                 join l in db.ligneADSLs on s.numSequence equals l.numSequence
                                 select new
                                 {
                                     l.userName,
                                     s.numSequence,
                                     s.dateDebutSession,
                                     s.dateFinSession,


                                 }).Where(x => x.userName == username).ToList();

            //  var mySessionData = db.sessionTime(username);

            var myDwSNR = (from s in db.attenuations
                           join l in db.ligneADSLs on s.numSequence equals l.numSequence
                           select new
                           {
                               l.userName,
                               s.numSequence,
                               s.DWSNR,
                               s.UPSNR,
                               s.DATE_SCAN
                           }).Where(x => x.userName == username).ToList().OrderBy(x => x.DATE_SCAN);


            var myUPATT = (from s in db.attenuations
                           join l in db.ligneADSLs on s.numSequence equals l.numSequence
                           select new
                           {
                               l.userName,
                               s.numSequence,
                               s.UPATTEN,
                               s.DWATTEN,
                               s.DATE_SCAN
                           }).Where(x => x.userName == username).ToList().OrderBy(x => x.DATE_SCAN);

            var referenceKPI = db.referenceDureeMoyenneConnexion(sdt, edt, username);
            var referenceKPIMin = db.referenceDureeMinimalConnexion(sdt, edt, username);
            var referenceKPIMax = db.referenceDureeMaximalConnexion(sdt, edt, username);
            var referenceKPInbDex = db.referenceNbDeconnexionConnexion(sdt, edt, username);
            
          //  ViewBag.DataPoints = JsonConvert.SerializeObject(db.historiqueConnexion(username, sdt, edt), _jsonSetting);

            dynamic obj = new ExpandoObject();
            obj.dur = myDurationData;
            obj.num = myNumberData;
            obj.ses = mySessionData;
            obj.dwsnr = myDwSNR;
            obj.upatt = myUPATT;
            obj.referenceKpi = referenceKPI;
            obj.referenceKpiMin = referenceKPIMin;
            obj.referenceKpiMax = referenceKPIMax;
            obj.referenceKpinbDex = referenceKPInbDex;
          
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDataSession(string username, string d1, string d2)
        {

            string[] sdtArray = d1.Split(new Char[] { '/', ':', ' ' });
            string[] edtArray = d2.Split(new Char[] { '/', ':', ' ' });


            DateTime stt = new DateTime(Convert.ToInt32(sdtArray[0]), Convert.ToInt32(sdtArray[1]), Convert.ToInt32(sdtArray[2])
                , Convert.ToInt32(sdtArray[3]), Convert.ToInt32(sdtArray[4]), Convert.ToInt32(sdtArray[5]));

            DateTime et = new DateTime(Convert.ToInt32(edtArray[0]), Convert.ToInt32(edtArray[1]), Convert.ToInt32(edtArray[2])
                , Convert.ToInt32(edtArray[3]), Convert.ToInt32(edtArray[4]), Convert.ToInt32(edtArray[5]));

            //var sdtArray = d1.Split('/');
            //var edtArray = d2.Split('/');
            //DateTime st = new DateTime(Convert.ToInt32(sdtArray[0]), Convert.ToInt32(sdtArray[1]), Convert.ToInt32(sdtArray[2]));
            //DateTime et = new DateTime(Convert.ToInt32(edtArray[0]), Convert.ToInt32(edtArray[1]), Convert.ToInt32(edtArray[2]));


            var sessionChart = db.historiqueConnexion(username, stt, et);
            //  var sessionChart = db.historiqueConnexion(username, st, et);

            dynamic obj = new ExpandoObject();
            obj.sessionchart = sessionChart;
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}



