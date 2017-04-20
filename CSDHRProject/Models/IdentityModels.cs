using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

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

        public bool role { get; set; }

        [Display(Name = "First Name")]

        public bool admin { get; set; }

        public string firstname { get; set; }

        [Display(Name = "Last Name")]
        public string lastname { get; set; }

        [Display(Name = "Sin")]
        public string Sin { get; set; }

        [Display(Name = "Bank Depost Account Number")]
        public string BenefitNumber { get; set; }

        [Display(Name = "Rate of Pay")]
        public double RateOfPay { get; set; }

        [Display(Name = "Vacation Days")]
        public int VacationDays { get; set; }

        [Display(Name = "Sick Days")]
        public int SickDays { get; set; }

        [Display(Name = "Benefit Certificate File")]
        public string BenefitCertificateFileName { get; set; }

        [Display(Name = "Training Certificate File")]
        public string TrainingCertificateFileName { get; set; }
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

        public System.Data.Entity.DbSet<CSDHRProject.Models.RegisterViewModel> NewHireModels { get; set; }
        
        public System.Data.Entity.DbSet<CSDHRProject.Models.JobPosting> JobPostings { get; set; }

        public System.Data.Entity.DbSet<CSDHRProject.Models.JobApplication> JobApplications { get; set; }

        public System.Data.Entity.DbSet<CSDHRProject.Models.Project> Projects { get; set; }
        public System.Data.Entity.DbSet<CSDHRProject.Models.ProjectUser> ProjectUsers { get; set; }

        public System.Data.Entity.DbSet<CSDHRProject.Models.PayrollModels> PayrollModels { get; set; }

        public System.Data.Entity.DbSet<CSDHRProject.Models.BenefitRegistration> BenefitRegistrations { get; set; }

        public System.Data.Entity.DbSet<CSDHRProject.Models.EmployeeClaim> EmployeeClaims { get; set; }

        public System.Data.Entity.DbSet<CSDHRProject.Models.Address> Addresses { get; set; }


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
