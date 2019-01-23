using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Topnet_v1.Controllers
{
    public class dashboardParkController : Controller
    {
        private topnetDATAEntities db = new topnetDATAEntities();
        // GET: dashboardPark
        public ActionResult Index()
        {
            //var lstUsers = new List<dailyParameter>();
            //lstUsers = db.dailyParameters.ToList();
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
          // var abc = GetData("Tunis", "2018/02/14", "2018/02/27");
            return View();
        }

        public JsonResult GetData(string gouvernerat, string d1, string d2)
        {
            var sdtArray = d1.Split('/');
            var edtArray = d2.Split('/');
            DateTime sdt = new DateTime(Convert.ToInt32(sdtArray[0]), Convert.ToInt32(sdtArray[1]), Convert.ToInt32(sdtArray[2]));
            DateTime edt = new DateTime(Convert.ToInt32(edtArray[0]), Convert.ToInt32(edtArray[1]), Convert.ToInt32(edtArray[2]));
            var myDurationData = (from d in db.dailyParameters

                                  select new
                                  {
                                      d.gouvernerat,
                                      d.date,
                                      d.dureeConnexionParJour,
                                      d.dureeDeconnexionParJour

                                  }).Where(x => x.gouvernerat == gouvernerat && x.date >= sdt && x.date <= edt)
                     .ToList();

            dynamic obj = new ExpandoObject();
            obj.dur = myDurationData;

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}