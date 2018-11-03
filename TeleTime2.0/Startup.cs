using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TeleTime.Models;

[assembly: OwinStartupAttribute(typeof(TeleTime.Startup))]
namespace TeleTime
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        // Admin och olika roller  
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // Vid start skapa första admin rollen och en deafult admin användare   
            if (!roleManager.RoleExists("Admin"))
            {

                // Skapa en Admin roll
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                // Skapa en user          

                var user = new ApplicationUser();
                user.UserName = "admin@admin.com";
                user.Email = "admin@gadmin.com";
              
                string userPWD = "AdminAdmin1234!";

                var chkUser = UserManager.Create(user, userPWD);

                // Lägg till usern till Admin rollen  
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // Skapa en Developer roll som ska ha tillgång till alla views
            if (!roleManager.RoleExists("Developer"))
            {
                var role = new IdentityRole();
                role.Name = "Developer";
                roleManager.Create(role);

                // Skapa en user
                var user = new ApplicationUser();
                user.UserName = "developer@developer.com";
                user.Email = "developer@developer.com";

                string userPWD = "Developer1234!";

                var chkUser = UserManager.Create(user, userPWD);

                // Lägg till usern till Developer  
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Developer");

                }

            }

            // Skapa en vanlig användar roll    
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

            }
        }

    }
}
