using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CSDHRProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        //Custom User attributes
        public bool manager { get; set; }
        public bool admin { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //Insert DbSet variables (Table Names!) here in the following format:
        // public DbSet<%MODEL_NAME%> %TABLE_NAME% { get; set; }
        //Example:
        // public DbSet<Benefits> Benefits { get; set; }

        //Once added here, you can update the database by opening the NuGet console
        // (Tools > NuGet Package Manager > Package Manager Console)
        //then running the following command: 
        // Update-Database
        //This will create or modify all tables in the database

        //If you insert a table, decide you do not want it anymore,
        //and want to delete it, remove it from here and run:
        // Update-Database -Force
        //This will DELETE the table and ALL DATA within it.
    }
}