using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace Topnet_v1.Controllers
{
    [Authorize]
    public class referenceController : Controller
    {
        topnetDATAEntities db = new topnetDATAEntities();
        // GET: reference
        public ActionResult Index()
        {
            var lst = db.references.ToList();
            return View(lst);
        }



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


            // var abc = insertData("0000006@topnet.tn","Durée moyenne de connexion", new DateTime(2018, 02, 14), new DateTime(2018, 02, 27));
            return View();
        }

        public JsonResult insertData(string nomKPI, int bornDeb, int bornMoy, int bornFin)
        {

            var myData = db.insertReference(bornDeb, bornFin, bornMoy, nomKPI);

            dynamic obj = new ExpandoObject();
            obj.dur = myData;

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditReference(int? id, string nomkp)
        {

            DateTime date = DateTime.Today;
            ViewBag.namekpi = nomkp;
            ViewBag.date = date;
            try
            {
                
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var referenceToUpdate = db.references.Find(id);
                if (TryUpdateModel(referenceToUpdate, "",
                   new string[] { "borneDebut", "borneFin", "borneMoyenne", "dateReference", "nomReference" }))
                {
                    try
                    {
                        db.SaveChanges();

                        // return RedirectToAction("Index");
                    }
                    catch (DataException /* dex */)
                    {

                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return View();
        }

        public ActionResult Detail(int id, DateTime dateReference)
        {
            ViewBag.date = dateReference;
            reference references = db.references.Find(id);

            ViewBag.DataPoints = JsonConvert.SerializeObject(db.DetailBarreReference(id), _jsonSetting);
            ViewBag.DataPointsNBdeconnexion = JsonConvert.SerializeObject(db.DetailBarreReferenceNbDeconnexion(id), _jsonSetting);
            return View();


        }
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        };



        public ActionResult DeleteConfirmed(int id)
        {
            reference references = db.references.Find(id);
            db.references.Remove(references);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MinSessionUser(string username)
        {
            ViewBag.usernam = username;
            return View();

        }


    }
}


 