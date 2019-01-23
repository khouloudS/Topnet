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

namespace Topnet_v1.Controllers
{
    [Authorize]
    public class MoreInfoController : Controller
    {
        private topnetDATAEntities db = new topnetDATAEntities();
   

        // GET: MoreInfo
        public ActionResult Index(string username)
        {

            ViewBag.usernam = username;
            ViewBag.DataPointsnB = JsonConvert.SerializeObject(db.referenceKPINbDeconnexion("Nombre de déconnexion"), _jsonSetting);

            return View();
        }
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        /*  public JsonResult GetData(string d1, string d2)
          {
              var sdtArray = d1.Split('/');
              var edtArray = d2.Split('/');
              DateTime sdt = new DateTime(Convert.ToInt32(sdtArray[0]), Convert.ToInt32(sdtArray[1]), Convert.ToInt32(sdtArray[2]));
              DateTime edt = new DateTime(Convert.ToInt32(edtArray[0]), Convert.ToInt32(edtArray[1]), Convert.ToInt32(edtArray[2]));

              var myNumberData = (from d in db.dailyParameters
                                  select new
                                  {
                                      d.numSequence,
                                      d.userName,
                                      d.gouvernerat,
                                      d.date,
                                      d.nbDeconnexionParJour

                                  }).Where(x => x.date >= sdt && x.date <= edt)
                       .ToList();

              dynamic obj = new ExpandoObject();

              obj.num = myNumberData;

              return Json(obj, JsonRequestBehavior.AllowGet);

          }*/




        public JsonResult GetData(string username, string d1 ,string d2)
         {
            dynamic obj = new ExpandoObject();
            try
            {
                var sdtArray = d1.Split('/');
                var edtArray = d2.Split('/');
                DateTime sdt = new DateTime(Convert.ToInt32(sdtArray[0]), Convert.ToInt32(sdtArray[1]), Convert.ToInt32(sdtArray[2]));
                DateTime edt = new DateTime(Convert.ToInt32(edtArray[0]), Convert.ToInt32(edtArray[1]), Convert.ToInt32(edtArray[2]));

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
                var referenceKPInbDex = db.referenceNbDeconnexionConnexion(sdt, edt, username);


                obj.num = myNumberData;
                obj.referenceKpinbDex = referenceKPInbDex;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return Json(obj, JsonRequestBehavior.AllowGet);

           }
        }
    }
