using System.Security.Claims;
using System.Threading.Tasks;
using XYZ.DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
namespace XYZ.Admins.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
   

    public class ApplicationDbContext : IdentityDbContext<Admin, RoleForAdmin, string, AdminLogin, AdminRole, AdminClaim>
    {
        public ApplicationDbContext()
            : base("XYZEntities")
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Needed to ensure subclasses share the same table
            var user = modelBuilder.Entity<Admin>()
                .ToTable("Admin");
            user.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserNameIndex") { IsUnique = true }));
            user.Property(u => u.Email)
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserEmailIndex") { IsUnique = true }));
            user.HasMany(u => u.Roles).WithRequired().HasForeignKey(ur => ur.UserId);
            user.HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
            user.HasMany(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId);

            modelBuilder.Entity<AdminRole>()
                .HasKey(r => new { r.UserId, r.RoleId })
                .ToTable("AdminRole");

            modelBuilder.Entity<AdminLogin>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
                .ToTable("AdminLogin");

            modelBuilder.Entity<AdminClaim>()
                .ToTable("AdminClaim");

            var role = modelBuilder.Entity<RoleForAdmin>()
                .ToTable("RoleForAdmin");
            role.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("RoleNameIndex") { IsUnique = true }));
            role.HasMany(r => r.Users).WithRequired().HasForeignKey(ur => ur.RoleId);



            var client = modelBuilder.Entity<User>()
    .ToTable("User");
            client.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserNameIndex") { IsUnique = true }));
            client.Property(u => u.Email)
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserEmailIndex") { IsUnique = true }));
            client.HasMany(u => u.Roles).WithRequired().HasForeignKey(ur => ur.UserId);
            client.HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
            client.HasMany(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId);

            modelBuilder.Entity<UserRole>()
                .HasKey(r => new { r.UserId, r.RoleId })
                .ToTable("UserRole");

            modelBuilder.Entity<UserLogin>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
                .ToTable("UserLogin");

            modelBuilder.Entity<UserClaim>()
                .ToTable("UserClaim");

            var roleclient = modelBuilder.Entity<RoleForUser>()
                .ToTable("RoleForUser");
            roleclient.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("RoleNameIndex") { IsUnique = true }));
            roleclient.HasMany(r => r.Users).WithRequired().HasForeignKey(ur => ur.RoleId);

        }
        
    }
}