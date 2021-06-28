using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Database
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<OrderedProduct> OrderedProducts { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StoreLocation> StoreLocations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.CustomerId, "UQ__Customer__A4AE64B9F7A5B22C")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LName");
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.ToTable("CustomerOrder");

                entity.HasIndex(e => e.CustomerOrderId, "UQ__Customer__28FBA0DD3A738DD3")
                    .IsUnique();

                entity.Property(e => e.CustomerOrderId).HasColumnName("CustomerOrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerOrdertime).HasColumnType("date");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__CustomerO__Custo__2C538F61");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__CustomerO__Locat__2D47B39A");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.HasIndex(e => e.InventoryId, "UQ__Inventor__F5FDE6D215ADAF2D")
                    .IsUnique();

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Inventory__Locat__39AD8A7F");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Inventory__Produ__38B96646");
            });

            modelBuilder.Entity<OrderedProduct>(entity =>
            {
                entity.HasKey(e => new { e.CustomerOrderId, e.QuantityOfItems })
                    .HasName("PK__OrderedP__8B06469BEBBB4F10");

                entity.ToTable("OrderedProduct");

                entity.Property(e => e.CustomerOrderId).HasColumnName("CustomerOrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderedProducts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__OrderedPr__Custo__33F4B129");

                entity.HasOne(d => d.CustomerOrder)
                    .WithMany(p => p.OrderedProducts)
                    .HasForeignKey(d => d.CustomerOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderedPr__Custo__34E8D562");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderedProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderedPr__produ__33008CF0");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.PlayerId).ValueGeneratedNever();

                entity.Property(e => e.PlayerFname)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PlayerLname)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.ProductId, "UQ__Product__B40CC6EC3E59C381")
                    .IsUnique();

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("productDescription");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<StoreLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__StoreLoc__E7FEA4771F79363F");

                entity.ToTable("StoreLocation");

                entity.HasIndex(e => e.LocationId, "UQ__StoreLoc__E7FEA476DABE47D5")
                    .IsUnique();

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
