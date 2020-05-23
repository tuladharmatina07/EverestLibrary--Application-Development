using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace VideoLibraryV1.Models
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
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<MemberCategory> MemberCategories { get; set; }
        public DbSet<MemberDetail> MemberDetails { get; set; }
        public DbSet<LoanType> LoanTypes { get; set; }
        public DbSet<CastDetail> CastDetails { get; set; }
        public DbSet<CastMember> CastMembers { get; set; }
        public DbSet<ProducerDetail> ProducerDetails { get; set; }
        public DbSet<ProducerMember> ProducerMembers { get; set; }
        public DbSet<DVDDetail> DVDDetails{ get; set; }
        public DbSet<Loan> Loans{ get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}