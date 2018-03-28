using System.Data.Entity;
using XYZ.DAL.Models;
using DAL.Models;

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
        public virtual DbSet<ClientUser> ClientUsers { get; set; }
        public virtual DbSet<ClientRole> ClientRoles { get; set; }
        public virtual DbSet<ClientLogin> ClientLogins { get; set; }
        public virtual DbSet<ClientClaim> ClientClaims { get; set; }
        public virtual DbSet<RoleForClient> RoleForClientList { get; set; }
        public virtual DbSet<PlayerStatus> PlayerStatuses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AdminRole>()
                       .HasKey(r => new { r.UserId, r.RoleId })
                       .ToTable("AdminRole");

            modelBuilder.Entity<AdminLogin>()
          .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
          .ToTable("AdminLogin");

            modelBuilder.Entity<ClientRole>()
                     .HasKey(r => new { r.UserId, r.RoleId })
                     .ToTable("ClientUserRole");

            modelBuilder.Entity<ClientLogin>()
          .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
          .ToTable("ClientUserLogin");


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
