using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMFLMS.Controllers;
using CMFLMS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CMFLMS.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        public UsersController isadmin = new UsersController();
        ApplicationDbContext cont;

        public RoleController()
        {
            cont = new ApplicationDbContext();
        }
        // GET: Role
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!IsAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
            var Roles = cont.Roles.ToList();
            return View(Roles);
        }
        public Boolean IsAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext cont = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(cont));
                var s = UserManager.GetRoles(user.GetUserId());
                if ((s[0].ToString() == "SuperAdmin") && (s[0].ToString() == "MainAdmin"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!IsAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            var Role = new IdentityRole();
            return View(Role);
        }
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!IsAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            cont.Roles.Add(Role);
            cont.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}