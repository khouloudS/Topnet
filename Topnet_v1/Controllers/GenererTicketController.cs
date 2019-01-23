using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Topnet_v1.Controllers
{
    [Authorize]
    public class GenererTicketController : Controller
    {
        topnetDATAEntities db;
        public GenererTicketController()
        {

            db = new topnetDATAEntities();
        }

        // GET: GenererTicket
        public ActionResult Index()
        {


            using (topnetDATAEntities db = new topnetDATAEntities())
            {

                var r = db.ticketGeneres.ToList();

                return View(r);

            }
        }
        public ActionResult Afficher(String statut)
        {
            var act = db.test().ToList();
            var desc = db.testdes().ToList();
            var pas = db.notexistes.ToList();
            if (statut == "En cours")
            {

                return PartialView("Afficher1", act);
            }
            else if (statut == "Clôturer")
            {

                return PartialView("Afficher2", desc);
            }
            else
                return PartialView("Afficher3", pas);


        }


        public ActionResult Add(int Id, string User)
        {
            ViewBag.motif = new SelectList(db.motifs, "idMotif", "nomMotif");
            ViewBag.numseq = Id;
            ViewBag.usernam = User;




            if (db.cherche(Id).Count() == 1)
            {

                return PartialView("Exist");
            }
            else
            {

                return PartialView("Add");
            }


        }

        public ActionResult Create(int numseq, string description, int motif)
        {

            var myData = db.createTicket(numseq, motif, description);

            return RedirectToAction("Index");


        }


        public ActionResult Cloturer(int numseq, string description)
        {

            var myData = db.modifTicket(numseq, description);

            return RedirectToAction("Index");

        }

    }
}