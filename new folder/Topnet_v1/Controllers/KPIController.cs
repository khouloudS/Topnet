using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Topnet_v1.Models;

namespace Topnet_v1.Controllers
{
    public class KPIController : Controller
    {
        // GET: KPI

       private topnetBDEntities _topnet = new topnetBDEntities();
        public KPIController()
        {
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
                return View(_topnet.KPI.ToList());
            

        }

        public ActionResult Create()
        {
            ViewBag.panne = new SelectList(_topnet.Panne.ToList(), "valeurPanne", "valeurPanne");
            return View();
        }

    }
}