using System;
using System.Web.Mvc;

namespace JobsInABA.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ResetPassword(string token)
        {
            var username= token.Split('_')[0];
            var time = token.Split('_')[1];
            if (Convert.ToDateTime(time) < DateTime.Now)
                return View();
            else
                return View();
        }
    }
}
