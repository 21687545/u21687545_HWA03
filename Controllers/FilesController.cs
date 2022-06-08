using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21687545_HWA03.Models;

namespace u21687545_HWA03.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            //Fect all the files in the Folder(Directory)
            //StackOverFlow
            string[] filesPaths = System.IO.Directory.GetFiles(Server.MapPath("~/Gallery/Documents/"));

            //Copy File names to Model collection
            List<FileModel> files = new List<FileModel>();
            foreach (string filesPath in filesPaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filesPath) });
            }
            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {
            string path = Server.MapPath("~/Gallery/Documents/") + fileName;

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
            string path = Server.MapPath("~/Gallery/Documents/") + fileName;

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}