using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Topnet_v1.Models;


namespace Topnet_v1.Controllers
{
    public class HistoryController : Controller
    {
        // GET: aaa
        historiqueConnexion db;

        public HistoryController()
        {

            db = new historiqueConnexion() ;
        }


        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            using (topnetBDEntities db = new topnetBDEntities()) 
            {
                return View(db.historiqueConnexion.ToList());
            }
         
            // return View();
        }
    }
}