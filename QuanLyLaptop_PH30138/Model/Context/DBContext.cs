using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QuanLyLaptop_PH30138.DomainClass;

namespace QuanLyLaptop_PH30138.Model.Context;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hang> Hangs { get; set; }

    public virtual DbSet<Laptop> Laptops { get; set; }

    public virtual DbSet<NoiSanXuat> NoiSanXuats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=BANGCHIU105\\SQLEXPRESS01;Initial Catalog=lab56;Integrated Security=True ;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hang>(entity =>
        {
            entity.HasKey(e => e.MaHang).HasName("PK__Hang__C28CA331A214C65B");
        });

        modelBuilder.Entity<Laptop>(entity =>
        {
            entity.HasKey(e => e.GuidId).HasName("PK__Laptop__6EBB7CEE95E2448D");

            entity.Property(e => e.GuidId).ValueGeneratedNever();
        });

        modelBuilder.Entity<NoiSanXuat>(entity =>
        {
            entity.HasKey(e => e.MaNsx).HasName("PK__NoiSanXu__26994274E3CE4432");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
