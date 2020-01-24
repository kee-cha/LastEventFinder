using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EventFinder_GC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<CustomerEvent> CustomerEvents{ get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<EventFinder_GC.Models.Address> Addresses { get; set; }

        public System.Data.Entity.DbSet<EventFinder_GC.Models.Customer> Customers { get; set; }

        //public System.Data.Entity.DbSet<EventFinder_GC.Models.ApplicationUser> ApplicationUsers { get; set; }

        public System.Data.Entity.DbSet<EventFinder_GC.Models.Event> Events { get; set; }

        public System.Data.Entity.DbSet<EventFinder_GC.Models.Host> Hosts { get; set; }
    }
}