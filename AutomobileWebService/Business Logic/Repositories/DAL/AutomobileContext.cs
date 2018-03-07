using AutomobileWebService.Business_Logic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Repositories.DAL
{
    public class AutomobileContext : DbContext
    {
        public AutomobileContext(DbContextOptions<AutomobileContext> options)
            : base(options)
        { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyAddress> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Automobile");

            modelBuilder.Entity<Car>(x =>
            {
                x.HasKey(z => z.Id);
                x.Property(z => z.Id).ValueGeneratedOnAdd();
                x.HasMany(z => z.Projects).WithOne(y => y.Car).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>(x =>
            {
                x.HasKey(z => z.Id);
                x.Property(z => z.Id).ValueGeneratedOnAdd();                
            });

            modelBuilder.Entity<Brand>(x =>
            {
                x.HasKey(z => z.Id);
                x.Property(z => z.Id).ValueGeneratedOnAdd();                
                x.HasMany(z => z.Cars).WithOne(y => y.Brand).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Project>(x =>
            {
                x.HasKey(z => z.Id);
                x.Property(z => z.Id).ValueGeneratedOnAdd();                
                x.HasOne(z => z.User).WithMany(y => y.Projects).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Comment>(x =>
            {
                x.HasKey(z => z.Id);
                x.Property(z => z.Id).ValueGeneratedOnAdd();                
                x.HasOne(z => z.Commenter).WithMany(y => y.Comments).OnDelete(DeleteBehavior.Restrict);
                x.HasOne(z => z.Project).WithMany(y => y.Comments).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Company>(x =>
            {
                x.HasKey(z => z.Id);
                x.Property(z => z.Id).ValueGeneratedOnAdd();                
                x.HasOne(z => z.CompanyAddress).WithOne(z => z.Company).HasForeignKey<CompanyAddress>(y => y.CompanyId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CompanyAddress>(x =>
            {
                x.HasKey(z => z.Id);
                x.Property(z => z.Id).ValueGeneratedOnAdd();                
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
