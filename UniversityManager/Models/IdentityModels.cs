using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UniversityManager.Models.EF;

namespace UniversityManager.Models
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
        public virtual UserAdditionalInfo UserAdditionalInfo { get; set; }
        public virtual TeacherAdditionalInfo TeacherAdditionalInfo { get; set; }
        public virtual StudentGroup StudentGroup { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<News> News { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupRequest> GroupRequests  { get; set; }
        public DbSet<UserAdditionalInfo> userAdditionalInfos { get; set; }
        public DbSet<TeacherAdditionalInfo> TeacherAdditionalInfos { get; set; }
        public DbSet<StudentGroup> studentGroups { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}