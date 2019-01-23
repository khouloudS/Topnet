using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Topnet_v1.Controllers
{
    [Authorize]
    public class MoreInfoMoyDureController : Controller
    {
        private topnetDATAEntities db = new topnetDATAEntities();
        // GET: MoreInfo
        public ActionResult Index(string username)
        {

            ViewBag.DataPoints = JsonConvert.SerializeObject(db.DetailBarreReferenceAvecDate("Durée moyenne de connexion"), _jsonSetting);

            ViewBag.usernam = username;
            return View();


        }
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        };



        public JsonResult GetData(string username, string d1, string d2)
        {
            dynamic obj = new ExpandoObject();
            try
            {
                var sdtArray = d1.Split('/');
                var edtArray = d2.Split('/');
                DateTime sdt = new DateTime(Convert.ToInt32(sdtArray[0]), Convert.ToInt32(sdtArray[1]), Convert.ToInt32(sdtArray[2]));
                DateTime edt = new DateTime(Convert.ToInt32(edtArray[0]), Convert.ToInt32(edtArray[1]), Convert.ToInt32(edtArray[2]));

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
                var referenceKPI = db.referenceDureeMoyenneConnexion(sdt, edt, username);

                obj.dur = myDurationData;
                obj.referenceKpi = referenceKPI;
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
          
            return Json(obj, JsonRequestBehavior.AllowGet);


        }
    }
}