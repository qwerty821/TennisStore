﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Abstractions;
using OnlineStore.Models.AccountsModels;
using OnlineStore.Models.RacketModels;
using OnlineStore.Models.RacketsModels;
using System.Reflection.Emit;

namespace OnlineStore.Models.DbModels;

public class OnlineStoreContext : IdentityDbContext<OnlineStoreUser>
{
    public OnlineStoreContext() { }
    public OnlineStoreContext(DbContextOptions<OnlineStoreContext> options)
        : base(options)
    {
    }

   
    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Racket> Rackets { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Server=tcp:sqlserverrackets.database.windows.net,1433;Initial Catalog=OnlineShop;Persist Security Info=False;User ID=qwerty821;Password=Asdfg132435;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

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

    public void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
