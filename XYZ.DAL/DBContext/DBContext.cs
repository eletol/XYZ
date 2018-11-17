using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using XYZ.DAL.Models;

namespace XYZ.DAL.DBContext
{
    public partial class DBContext : DbContext, IDbContext
    {
        public DBContext()
            : base("name=XYZEntities")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
        

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AdminRole> AdminRoles { get; set; }
        public virtual DbSet<AdminLogin> AdminLogins { get; set; }
        public virtual DbSet<AdminClaim> AdminClaims { get; set; }
        public virtual DbSet<RoleForAdmin> RoleForAdminList { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<UserClaim> UserClaims { get; set; }
        public virtual DbSet<RoleForUser> RoleForUserList { get; set; }
        public virtual DbSet<TagStatus> TagStatuses { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagLog> TagLogs { get; set; }
        public virtual DbSet<UserFriend> UserFriends { get; set; }
        public virtual DbSet<UserFriendBlock> UserFriendsBlocks { get; set; }

        public virtual DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            // Needed to ensure subclasses share the same table
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


            //modelBuilder.Entity<Badge>()
            //   .HasMany(e => e.Achievements)
            //   .WithOptional(e => e.Badge)
            //   .HasForeignKey(e => e.AchivedBadge);

            //modelBuilder.Entity<Badge>()
            //    .HasMany(e => e.BadgeIcons)
            //    .WithRequired(e => e.Badge)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Challenge>()
            //    .HasMany(e => e.Achievements)
            //    .WithOptional(e => e.Challenge)
            //    .HasForeignKey(e => e.AchivedChallenge);



            //modelBuilder.Entity<Icon>()
            //    .HasMany(e => e.BadgeIcons)
            //    .WithRequired(e => e.Icon)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Icon>()
            //    .HasMany(e => e.LevelIcons)
            //    .WithRequired(e => e.Icon)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<IconType>()
            //    .HasMany(e => e.Icons)
            //    .WithRequired(e => e.IconType1)
            //    .HasForeignKey(e => e.IconType)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Level>()
            //    .HasMany(e => e.Achievements)
            //    .WithOptional(e => e.Level)
            //    .HasForeignKey(e => e.AchivedLevel);

            //modelBuilder.Entity<Level>()
            //    .HasMany(e => e.Achievements)
            //    .WithOptional(e => e.Level)
            //    .HasForeignKey(e => e.AchivedLevel);
            //        modelBuilder.Entity<Achievement>()
            //         .HasRequired(e => e.LevelAfter)
            //           .WithMany()
            //.WillCascadeOnDelete(false);





            //modelBuilder.Entity<Level>()
            //    .HasMany(e => e.LevelIcons)
            //    .WithRequired(e => e.Level)
            //    .WillCascadeOnDelete(false);

        }
    }
}
