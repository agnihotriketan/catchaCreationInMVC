using catchaCreationInMVC.Models;
using catchaCreationInMVC.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Web;
using System.Web.Mvc;

namespace catchaCreationInMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AppViewModel model)
        {
            if (model.Text == Session[InfraCons.CaptchaSessionKey].ToString() && (!string.IsNullOrWhiteSpace(Session[InfraCons.CaptchaSessionKey].ToString())))
            {
                return RedirectToAction("Success");
            }
            ViewBag.ErrorMessage = "Sorry, Wrong Captcha";
            return View(model);
        }

        public ActionResult Success()
        {
            ViewBag.Message = "Correct Captcha.";
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public void GetCaptchaImage()
        {
            using (var obj = new CaptchaHandler())
            {
                obj.GenerateImage();
            }
        }

    }
}