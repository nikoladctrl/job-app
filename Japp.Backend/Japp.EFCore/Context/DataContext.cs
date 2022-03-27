using Japp.Core.Entities;
using Japp.Core.Enums;
using Japp.Core.Keys;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Japp.EFCore.Context
{
    public class DataContext : IdentityDbContext<Member>
    {
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<CompanyTechnology> CompanyTechnologies { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<Company>()
                .HasIndex(c => c.Name).IsUnique();

            modelBuilder.Entity<Company>()
                .Property(c => c.IsPremium).HasDefaultValue(false);

            modelBuilder.Entity<Company>()
                .Property(c => c.Likes).HasDefaultValue(0);

            modelBuilder.Entity<Company>()
                .Property(c => c.Likes).HasDefaultValue(0);

            modelBuilder.Entity<Job>()
                .Property(j => j.SalaryType).HasDefaultValue(SalaryType.Month);

            modelBuilder.Entity<Job>()
                .Property(j => j.CreatedOn).HasDefaultValueSql("date('now')");
            
            modelBuilder.Entity<Comment>()
                .Property(c => c.Likes).HasDefaultValue(0);

            modelBuilder.Entity<Comment>()
                .Property(c => c.Dislikes).HasDefaultValue(0);

            modelBuilder.Entity<Comment>()
                .Property(c => c.CreatedOn).HasDefaultValueSql("date('now')");


            modelBuilder.Entity<Technology>()
                .HasIndex(t => t.Name).IsUnique();

            modelBuilder.Entity<Member>()
                .HasIndex(m => m.Email).IsUnique();

            modelBuilder.Entity<Member>()
                .HasIndex(m => m.KnownAs).IsUnique();

            modelBuilder.Entity<Member>()
                .HasIndex(m => m.UserName).IsUnique();

            modelBuilder.Entity<CompanyTechnology>()
                .HasKey(ct => new { ct.CompanyId, ct.TechnologyId });         
        }
    }
}