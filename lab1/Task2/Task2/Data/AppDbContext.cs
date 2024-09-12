using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Task2.Models;

namespace Task2.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }


    public virtual DbSet<AppUser> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Data Source = prserver\\SQLEXPRESS;Initial Catalog = ispp1103;User ID = ispp1103;Password = 1103;TrustServerCertificate = true;");
        => optionsBuilder.UseSqlServer("Data Source = .\\SQLEXPRESS;Initial Catalog = LastMDK;User ID = lake;Password = 1;TrustServerCertificate = true;");

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        builder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.Login)
                .HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(50);
            entity.Property(e => e.Name)
                .HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(100);
        });
        builder.Entity<AppUser>().HasIndex(x => x.Email).IsUnique();
        builder.Entity<AppUser>().HasIndex(x => x.Login).IsUnique();
    }

}
