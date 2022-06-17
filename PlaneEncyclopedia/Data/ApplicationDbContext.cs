using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlaneEncyclopedia.Models;

namespace PlaneEncyclopedia.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public override DbSet<User> Users { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Missile> Missiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PlaneMissilesMapper>().HasKey(pm => new
            {
                pm.MissileId,
                pm.PlaneId
            });
            builder.Entity<PlaneMissilesMapper>().HasOne(pm => pm.Missile)
                .WithMany(pm => pm.planeMissilesMappers)
                .HasForeignKey(pm => pm.MissileId);
                

            builder.Entity<PlaneMissilesMapper>().HasOne(pm => pm.Plane)
                .WithMany(pm => pm.planeMissilesMappers)
                .HasForeignKey(pm => pm.PlaneId)
                .OnDelete(DeleteBehavior.Restrict);
                
            base.OnModelCreating(builder);
        }

        public DbSet<PlaneEncyclopedia.Models.PlaneMissilesMapper>? PlaneMissilesMapper { get; set; }
       
    }
}