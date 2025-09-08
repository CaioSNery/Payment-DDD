using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Notification>();

            modelBuilder.Ignore<Payment>();
            modelBuilder.Ignore<BoletoPayment>();
            modelBuilder.Ignore<CreditCardPayment>();
            modelBuilder.Ignore<PaypalPayment>();
            modelBuilder.Ignore<Subscription>();

            modelBuilder.Entity<Subscription>().Ignore(s => s.Payments);


            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.OwnsOne(e => e.Name, name =>
                {
                    name.Property(n => n.FirstName).HasColumnName("FirstName").HasMaxLength(40).IsRequired();
                    name.Property(n => n.LastName).HasColumnName("LastName").HasMaxLength(40).IsRequired();
                });

                entity.OwnsOne(e => e.Document, document =>
                {
                    document.Property(d => d.Number).HasColumnName("Document").HasMaxLength(11).IsRequired();
                    document.Property(d => d.Type).HasColumnName("DocumentType").IsRequired();
                });

                entity.OwnsOne(e => e.Email, email =>
                {
                    email.Property(em => em.Address).HasColumnName("Email").HasMaxLength(160).IsRequired();
                });

                entity.OwnsOne(e => e.Address, address =>
                {
                    address.Property(a => a.Street).HasColumnName("Street").HasMaxLength(160).IsRequired();
                    address.Property(a => a.Number).HasColumnName("Number").HasMaxLength(20).IsRequired();
                    address.Property(a => a.Neighborhood).HasColumnName("Neighborhood").HasMaxLength(60).IsRequired();
                    address.Property(a => a.City).HasColumnName("City").HasMaxLength(60).IsRequired();
                    address.Property(a => a.State).HasColumnName("State").HasMaxLength(60).IsRequired();
                    address.Property(a => a.Country).HasColumnName("Country").HasMaxLength(90).IsRequired();
                    address.Property(a => a.ZipCode).HasColumnName("ZipCode").HasMaxLength(20).IsRequired();
                });

                entity.Ignore(e => e.Subscriptions);
            });

        }
    }
}