using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PaymentGateway.Models
{
    public partial class PaymentDBContext : DbContext
    {
        public PaymentDBContext()
        {
        }

        public PaymentDBContext(DbContextOptions<PaymentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Merchant> Merchant { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source =.;Initial Catalog=PaymentDB;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Merchant>(entity =>
            {
                entity.Property(e => e.Merchantid)
                    .HasColumnName("merchantid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apikey)
                    .IsRequired()
                    .HasColumnName("apikey")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Paymentid)
                    .HasColumnName("paymentid")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Cardholdername)
                    .HasColumnName("cardholdername")
                    .IsUnicode(false);

                entity.Property(e => e.Cardnumber)
                    .HasColumnName("cardnumber")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cardtype)
                    .HasColumnName("cardtype")
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .IsUnicode(false);

                entity.Property(e => e.Expirydate)
                    .HasColumnName("expirydate")
                    .IsUnicode(false);

                entity.Property(e => e.Merchantid).HasColumnName("merchantid");

                entity.Property(e => e.Paymentdate)
                    .HasColumnName("paymentdate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.Merchantid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Payment__empid__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
