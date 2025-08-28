using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Student>().HasKey(s => s.Id);
            modelBuilder.Entity<Student>().Property(s => s.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Student>().Property(s => s.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Student>().Property(s => s.Document).IsRequired().HasMaxLength(13);
            modelBuilder.Entity<Student>().Property(s => s.Address).IsRequired().HasMaxLength(100);

        }
    }
}