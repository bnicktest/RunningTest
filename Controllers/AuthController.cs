using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog.ViewModels;

namespace SimpleBlog.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View(new AuthLogin
            {
            });
        }

        [HttpPost] //only when post request is sent method is initiated
        public ActionResult Login(AuthLogin form) //parameters come from authlogin viewmodel. 
        {
            if(!ModelState.IsValid)
                return View(form);

            return Content("The form is valid");
        }
    }
}