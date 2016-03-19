using JobsInABA.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobsInABA.Web.Controllers
{
    public class MainController : Controller
    {
        /// <summary>
        /// This maps to the Main/Index.cshtml file.  This file is the main view for the application.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ActivateAccount(string UserName)
        {
            UserAccountRepo _user = new UserAccountRepo();

            var users = _user.GetUserAccount();

            var user = users.FirstOrDefault(p => p.UserName == UserName);

            user.IsActive = true;
            _user.UpdateUserAccount(user);

            return Redirect(@"http://localhost:64872/#/login");
        }
    }
}