using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MyTravelWebsite.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyTravelWebsite.Startup))]
namespace MyTravelWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserAndRoles();
        }

        public void CreateUserAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Default admin
            if (!roleManager.RoleExists("SuperAdmin"))
            {
                //create admin role
                var role = new IdentityRole("SuperAdmin");
                roleManager.Create(role);

                //create default user Admin 
                var user = new ApplicationUser();
                user.UserName = "admin@mytravel.com";
                user.Email = "admin@mytravel.com";
                string pass = "Pass@2021";

                var newuser = userManager.Create(user, pass);
                if (newuser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "SuperAdmin");
                }
            }

            //Default travel organizer
            if (!roleManager.RoleExists("Travel Organizer"))
            {
                //create admin role
                var role = new IdentityRole("Travel Organizer");
                roleManager.Create(role);

                //create default user Admin 
                var user = new ApplicationUser();
                user.UserName = "travelorganizer@mytravel.com";
                user.Email = "travelorganizer@mytravel.com";
                string pass = "Organize@2021";

                var newuser = userManager.Create(user, pass);
                if (newuser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Travel Organizer");
                }
            }
        }
    }
}
