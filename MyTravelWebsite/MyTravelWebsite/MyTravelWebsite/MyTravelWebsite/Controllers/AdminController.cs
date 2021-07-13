using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyTravelWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyTravelWebsite.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class AdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        //POST:Create User 
        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string UName = form["textEmail"];
            string FName = form["textName"];
            string email = form["textEmail"];
            string password = form["textPass"];
            //create the user added by admin
            var user = new ApplicationUser();
            user.UserName = UName;
            user.FullName = FName;
            user.Email = email;
            var newuser = userManager.Create(user, password);
            return View();
        }

        //GET: Create Role
        public ActionResult CreateRole()
        {
            return View();
        }

        //POST: Create new Role
        [HttpPost]
        public ActionResult CreateNewRole(FormCollection form)
        {
            string rolename = form["RoleName"];
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists(rolename))
            {
                //create role
                var role = new IdentityRole(rolename);
                roleManager.Create(role);
            }
            return View("Index");
        }

        //GET: Assign Roles
        public ActionResult AssignRoles()
        {
            //ViewBag.Users = context.Users.Select(r => new SelectListItem { Value = r.UserName, Text = r.UserName }).ToList();
            //ViewBag.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            ViewBag.Roles = new SelectList(context.Roles.ToList(), "Name", "Name");
            ViewBag.UserName = new SelectList(context.Users.ToList(), "UserName", "UserName");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AssignRolesAsync(FormCollection form)
        {
            string username = form["UserName"];
            string rol = form["RoleName"];
            if (context.Users.Any(x => x.UserName == username))
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                ApplicationUser us = context.Users.Where(u => u.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var user = await userManager.FindAsync(username, rol);
                if(user == null)
                {
                    _ = userManager.AddToRoleAsync(us.Id, rol);
                }

            }
            return View("Index");
        }

        public ActionResult ShowAllUsers()
        {
            var item = context.Users.ToList();
            return View(item);
        }

         public ActionResult UserView()
        {
            var usersWithRoles = (from user in context.Users
                                  from userRole in user.Roles
                                  join role in context.Roles on userRole.RoleId equals
                                  role.Id
                                  select new UserView()
                                  {
                                      Id = user.Id,
                                      Username = user.UserName,
                                      Role = role.Name
                                  }).ToList();
            return View(usersWithRoles);
        }
        
    }
}