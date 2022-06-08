using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Adding model
using u05038015_HW03.Models;

namespace u05038015_HW03.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            //File from folder Media > Documents
            string[] files = Directory.GetFiles(Server.MapPath("~/Media/Documents"));

            //List for files to display in the view
            List<FileModel> FileModels = new List<FileModel>();

            for (int i = 0; i < files.Length; i++)
            {
                FileModel file = new FileModel();
                //Document name
                file.FileName = Path.GetFileName(files[i]);
                FileModels.Add(file);
            }
            return View(FileModels);
        }

        public ActionResult Download(string name)
        {
            //File path
            string fullName = Server.MapPath("~/Media/Documents/" + name);

            byte[] fileBytes = GetFile(fullName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, name);
        }

        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }

        // GET: Files/Delete/
        public ActionResult Delete(string name)
        {
            string fullPath = Request.MapPath("~/Media/Documents/" + name);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            return RedirectToAction("Index");
        }
    }
}
