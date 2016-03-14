using catchaCreationInMVC.Models;
using catchaCreationInMVC.Services;
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
                obj.GenerateImage(200,50,6);
            }
        }
        public CaptchaResult ShowCaptchaImage(int width, int height,int totalCharacters)
        {
            return new CaptchaResult(width,  height,  totalCharacters);
        }

        public ActionResult Approach1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Approach1(AppViewModel model)
        {
            if (model.Text == Session[InfraCons.CaptchaSessionKey].ToString() && (!string.IsNullOrWhiteSpace(Session[InfraCons.CaptchaSessionKey].ToString())))
            {
                return RedirectToAction("Success");
            }
            ViewBag.ErrorMessage = "Sorry, Wrong Captcha";
            return View(model);
        }

    }

}