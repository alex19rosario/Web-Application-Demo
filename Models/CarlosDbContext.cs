using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApplicationDemo.Models;

public partial class CarlosDbContext : DbContext
{
    protected readonly IConfiguration Configuration;
    

    public CarlosDbContext(DbContextOptions<CarlosDbContext> options, IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customers_pkey");

            entity.ToTable("customers");

            entity.HasIndex(e => e.Email, "customers_email_key").IsUnique();

            entity.HasIndex(e => e.GovernmentId, "customers_government_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.GovernmentId)
                .HasMaxLength(255)
                .HasColumnName("government_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .HasColumnName("sex");
            entity.Property(e => e.Tel)
                .HasMaxLength(20)
                .HasColumnName("tel");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
