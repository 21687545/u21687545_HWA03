using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u21687545_HWA03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string btnSelection, HttpPostedFileBase file)
        {
            ViewBag.Status = btnSelection;
            if(btnSelection== "Image")
            {
                string picID = System.IO.Path.GetFileName(file.FileName);
                string pathToImage = System.IO.Path.Combine(Server.MapPath("~/Gallery/Images"), picID);
                file.SaveAs(pathToImage);
            }
            if (btnSelection == "Video")
            {
                string picID = System.IO.Path.GetFileName(file.FileName);
                string pathToImage = System.IO.Path.Combine(Server.MapPath("~/Gallery/Videos"), picID);
                file.SaveAs(pathToImage);
            }
            if (btnSelection == "Document")
            {
                string picID = System.IO.Path.GetFileName(file.FileName);
                string pathToImage = System.IO.Path.Combine(Server.MapPath("~/Gallery/Documents"), picID);
                file.SaveAs(pathToImage);
            }
            ViewBag.Status = btnSelection + " was uploaded successfully";
            return View();
        }


       
    }
}