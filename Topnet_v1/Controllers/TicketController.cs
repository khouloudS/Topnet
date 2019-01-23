using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;

namespace Topnet_v1.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        topnetDATAEntities db;
        public TicketController()
        {

            db = new topnetDATAEntities();
        }

        public ActionResult Index()
        {
            using (topnetDATAEntities db = new topnetDATAEntities())
            {
                var resultat = db.listeTicket().ToList();
                return View(resultat);

            }
        }
        public ActionResult Afficher(string d1, string d2)
        {
            var resultat =  new object();
            try
            {
                var sdtArray = d1.Split('/');
                var edtArray = d2.Split('/');
                DateTime sdt = new DateTime(Convert.ToInt32(sdtArray[0]), Convert.ToInt32(sdtArray[1]), Convert.ToInt32(sdtArray[2]));
                DateTime edt = new DateTime(Convert.ToInt32(edtArray[0]), Convert.ToInt32(edtArray[1]), Convert.ToInt32(edtArray[2]));
                 resultat = db.ticketdate(sdt, edt).ToList();
               
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message) + "')</script>");
            }
            return PartialView("Afficher", resultat);
        }

        public ActionResult Export()
        {


            GridView gv = new GridView();
            gv.DataSource = db.listeTicket().ToList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Ticketlist.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Index");
        }



    }
}