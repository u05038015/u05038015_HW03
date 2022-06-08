using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u05038015_HW03.Controllers
{
    public class HomeController : Controller
    {
        //Return Index view
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string radioButtonInput)
        {
            //Nested if to test the different radio buttons
            //Checks if a radio button is selected to make share the file being uploaded is going to correct place as selected
            if (radioButtonInput == "Image")
            {            
                string name = Path.GetFileName(file.FileName);
                string path = "~/Media/Images/" + name;
                file.SaveAs(Server.MapPath(path));
                //string extraMessage ="Uploaded! Check it out in the Images page!";
                ViewBag.Message = path; //+ "  " + extraMessage;
            }
            else if (radioButtonInput == "Video")
            {
                string name = Path.GetFileName(file.FileName);
                string path = "~/Media/Videos/" + name;
                file.SaveAs(Server.MapPath(path));
                //string extraMessage = "Uploaded! Check it out in the Videos page!";
                ViewBag.Message = path; //+ "  " + extraMessage;
            }
            else if (radioButtonInput == "Document")
            {
                string name = Path.GetFileName(file.FileName);
                string path = "~/Media/Documents/" + name;
                file.SaveAs(Server.MapPath(path));
                //string extraMessage = "Uploaded! Check it out in the Files page!";
                ViewBag.Message = path; //+ "  " + extraMessage;

            }
            else
            {
                //If no radiobutton is checked
                ViewBag.Message = "Select a file type!";
            }

            return View();
        }

        //About view
        public ActionResult About()
        {
            return View();
        }

    }
}
