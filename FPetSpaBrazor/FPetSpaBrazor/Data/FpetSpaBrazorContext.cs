using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FPetSpaBrazor.Data;

public partial class FpetSpaBrazorContext : IdentityDbContext<ApplicationUser>
{
    public FpetSpaBrazorContext()
    {
    }

    public FpetSpaBrazorContext(DbContextOptions<FpetSpaBrazorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookingTime> BookingTimes { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartDetail> CartDetails { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<FeedBack> FeedBacks { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<PetType> PetTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductOrderDetail> ProductOrderDetails { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceOrderDetail> ServiceOrderDetails { get; set; }

    public virtual DbSet<StaffStatus> StaffStatuses { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.UseCollation("Vietnamese_CI_AS");

        modelBuilder.Entity<BookingTime>(entity =>
        {
            entity.ToTable("BookingTime");

            entity.Property(e => e.BookingTime1).HasColumnName("BookingTime");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD79747FAC93A");

            entity.ToTable("Cart");

            entity.HasIndex(e => e.UserId, "IX_Cart_UserID");

            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<CartDetail>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.CartId, "IX_CartDetails_CartID");

            entity.HasIndex(e => e.ProductId, "IX_CartDetails_ProductID");

            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductId)
                .HasMaxLength(20)
                .HasColumnName("ProductID");

            entity.HasOne(d => d.Cart).WithMany()
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK_CartDetails.CartID");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_CartDetails.ProductID");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2B022D7698");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(20)
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(20);
            entity.Property(e => e.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<FeedBack>(entity =>
        {
            entity.ToTable("FeedBack");

            entity.HasIndex(e => e.ProductId, "IX_FeedBack_OrderID");

            entity.HasIndex(e => e.UserFeedBackId, "IX_FeedBack_UserFeedBackID");

            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.PictureName).HasMaxLength(50);
            entity.Property(e => e.ProductId).HasMaxLength(20);
            entity.Property(e => e.UserFeedBackId).HasColumnName("UserFeedBackID");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Message).HasColumnType("text");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BAF71F59845");

            entity.ToTable("Order");

            entity.HasIndex(e => e.CustomerId, "IX_Order_CustomerID");

            entity.HasIndex(e => e.StaffId, "IX_Order_StaffID");

            entity.HasIndex(e => e.TransactionId, "IX_Order_TransactionID");

            entity.HasIndex(e => e.VoucherId, "IX_Order_VoucherID");

            entity.Property(e => e.OrderId)
                .HasMaxLength(20)
                .HasColumnName("OrderID");
            entity.Property(e => e.BookingTime).HasColumnType("datetime");
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DeliveryOption)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Total).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(20)
                .HasColumnName("TransactionID");
            entity.Property(e => e.VoucherId)
                .HasMaxLength(20)
                .HasColumnName("VoucherID");

            entity.HasOne(d => d.Transaction).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK_Order.TransactionID");

            entity.HasOne(d => d.Voucher).WithMany(p => p.Orders)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK_Order.VoucherID");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.MethodId).HasName("PK__PaymentM__FC681FB19861E276");

            entity.ToTable("PaymentMethod");

            entity.Property(e => e.MethodId)
                .ValueGeneratedNever()
                .HasColumnName("MethodID");
            entity.Property(e => e.MethodApi)
                .HasMaxLength(100)
                .HasColumnName("MethodAPI");
            entity.Property(e => e.MethodName).HasMaxLength(20);
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.PetId).HasName("PK__Pet__48E538029A90B6D1");

            entity.ToTable("Pet");

            entity.HasIndex(e => e.CustomerId, "IX_Pet_CustomerID");

            entity.Property(e => e.PetId).HasColumnName("PetID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.PetName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Pet Name");
            entity.Property(e => e.PetWeight)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("Pet Weight");
            entity.Property(e => e.PictureName).HasMaxLength(50);
        });

        modelBuilder.Entity<PetType>(entity =>
        {
            entity.ToTable("PetType");

            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6ED118BD779");

            entity.ToTable("Product");

            entity.HasIndex(e => e.CategoryId, "IX_Product_CategoryID");

            entity.Property(e => e.ProductId)
                .HasMaxLength(20)
                .HasColumnName("ProductID");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(20)
                .HasColumnName("CategoryID");
            entity.Property(e => e.PictureName).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductDescription).HasMaxLength(300);
            entity.Property(e => e.ProductName).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Product.CategoryID");
        });

        modelBuilder.Entity<ProductOrderDetail>(entity =>
        {
            entity.HasIndex(e => e.OrderId, "IX_ProductOrderDetails_OrderID");

            entity.HasIndex(e => e.ProductId, "IX_ProductOrderDetails_ProductId");

            entity.Property(e => e.OrderId)
                .HasMaxLength(20)
                .HasColumnName("OrderID");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductId).HasMaxLength(20);
            entity.Property(e => e.ProductPicture)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Order).WithMany(p => p.ProductOrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_ProductOrderDetails.OrderID");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__C51BB0EAC4D88B37");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId)
                .HasMaxLength(20)
                .HasColumnName("ServiceID");
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.MaxWeight).HasColumnType("decimal(6, 3)");
            entity.Property(e => e.MinWeight).HasColumnType("decimal(5, 3)");
            entity.Property(e => e.PictureName).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ServiceName).HasMaxLength(50);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ServiceOrderDetail>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.OrderId, "IX_ServiceOrderDetails_OrderID");

            entity.HasIndex(e => e.PetId, "IX_ServiceOrderDetails_PetID");

            entity.HasIndex(e => e.ServiceId, "IX_ServiceOrderDetails_ServiceID");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.OrderId)
                .HasMaxLength(20)
                .HasColumnName("OrderID");
            entity.Property(e => e.PetId).HasColumnName("PetID");
            entity.Property(e => e.PetWeight).HasColumnType("decimal(5, 3)");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ServiceId)
                .HasMaxLength(20)
                .HasColumnName("ServiceID");

            entity.HasOne(d => d.Order).WithMany()
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_ServiceOrderDetails.OrderID");
        });

        modelBuilder.Entity<StaffStatus>(entity =>
        {
            entity.ToTable("StaffStatus");

            entity.Property(e => e.StaffId)
                .HasMaxLength(450)
                .IsUnicode(false);
            entity.Property(e => e.StaffName)
                .HasMaxLength(450)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A4B99715DB2");

            entity.HasIndex(e => e.MethodId, "IX_Transactions_MethodID");

            entity.Property(e => e.TransactionId)
                .HasMaxLength(20)
                .HasColumnName("TransactionID");
            entity.Property(e => e.MethodId).HasColumnName("MethodID");
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            entity.HasOne(d => d.Method).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.MethodId)
                .HasConstraintName("FK_Transactions.MethodID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Gmail).HasMaxLength(100);
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.VoucherId).HasName("PK__Voucher__3AEE79C1F400B288");

            entity.ToTable("Voucher");

            entity.Property(e => e.VoucherId)
                .HasMaxLength(20)
                .HasColumnName("VoucherID");
            entity.Property(e => e.Description).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
