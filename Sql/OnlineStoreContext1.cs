using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Models;

public partial class OnlineStoreContext1 : DbContext
{
    private readonly IConfiguration _config;
    
     
    public OnlineStoreContext1()
    {

    }

    public OnlineStoreContext1(DbContextOptions<OnlineStoreContext1> options)
        : base(options)
    {

    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Racket> Rackets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=tcp:sqlserverrackets.database.windows.net,1433;Initial Catalog=OnlineShop;Persist Security Info=False;User ID=qwerty821;Password=Asdfg132435;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BId).HasName("PK_Brand_Id");

            entity.Property(e => e.BId)
                .ValueGeneratedNever()
                .HasColumnName("b_id");
            entity.Property(e => e.BName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("b_name");
        });

        modelBuilder.Entity<Racket>(entity =>
        {
            entity.HasKey(e => e.RId).HasName("PK_Racket_Id");

            entity.Property(e => e.RId)
                .ValueGeneratedNever()
                .HasColumnName("r_id");
            entity.Property(e => e.RBrand).HasColumnName("r_brand");
            entity.Property(e => e.RImageUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("r_image_url");
            entity.Property(e => e.RName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("r_name");
            entity.Property(e => e.RPrice)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("r_price");

            entity.HasOne(d => d.RBrandNavigation).WithMany(p => p.Rackets)
                .HasForeignKey(d => d.RBrand)
                .HasConstraintName("FK_Brands_To_Rackets");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
