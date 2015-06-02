using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using NHibernate.Linq;
using SimpleBlog.Models;
using SimpleBlog.ViewModels;

namespace SimpleBlog.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("home");
        }
        public ActionResult Login()
        {
            return View(new AuthLogin());
        }

        [HttpPost] //only when post request is sent method is initiated
        public ActionResult Login(AuthLogin form, string returnUrl) //parameters come from authlogin viewmodel. 
        {
            var user = Database.Session.Query<User>().FirstOrDefault(u => u.Username == form.Username);
            if(user == null)
                Models.User.FakeHash();
            if(user == null || !user.CheckPassword(form.Password))
                ModelState.AddModelError("Username","Username or password is incorrect");

            if (!ModelState.IsValid)
                return View(form);

            FormsAuthentication.SetAuthCookie(user.Username, true);

            if(!string.IsNullOrWhiteSpace(returnUrl))
                return Redirect(returnUrl);

            return RedirectToRoute("home");
        }
    }
}