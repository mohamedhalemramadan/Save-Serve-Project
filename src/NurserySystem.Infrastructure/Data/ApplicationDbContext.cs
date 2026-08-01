using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NurserySystem.Domain.Entities;

namespace NurserySystem.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Child> Children { get; set; }
    public DbSet<Guardian> Guardians { get; set; }
    public DbSet<ClassRoom> ClassRooms { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Bus> Buses { get; set; }
    public DbSet<Area> Areas { get; set; }
    public DbSet<BusRoute> BusRoutes { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Revenue> Revenues { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
    public DbSet<SaleInvoice> SaleInvoices { get; set; }
    public DbSet<CashRegister> CashRegisters { get; set; }
    public DbSet<CashTransaction> CashTransactions { get; set; }
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Child entity
        modelBuilder.Entity<Child>(entity =>
        {
            entity.HasIndex(e => e.LastName);
            entity.HasOne(e => e.Guardian)
                .WithMany(g => g.Children)
                .HasForeignKey(e => e.GuardianId);
            entity.HasOne(e => e.ClassRoom)
                .WithMany(c => c.Children)
                .HasForeignKey(e => e.ClassRoomId);
        });

        // Configure Guardian entity
        modelBuilder.Entity<Guardian>(entity =>
        {
            entity.HasIndex(e => e.PhoneNumber);
            entity.HasIndex(e => e.NationalId).IsUnique();
        });

        // Configure ClassRoom entity
        modelBuilder.Entity<ClassRoom>(entity =>
        {
            entity.HasOne(e => e.Level)
                .WithMany(l => l.ClassRooms)
                .HasForeignKey(e => e.LevelId);
        });

        // Configure Subscription entity
        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasOne(e => e.Child)
                .WithMany(c => c.Subscriptions)
                .HasForeignKey(e => e.ChildId);
        });

        // Configure Payment entity
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasOne(e => e.Child)
                .WithMany(c => c.Payments)
                .HasForeignKey(e => e.ChildId);
            entity.HasOne(e => e.Subscription)
                .WithMany(s => s.Payments)
                .HasForeignKey(e => e.SubscriptionId);
        });

        // Configure Attendance entity
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasIndex(e => new { e.ChildId, e.Date }).IsUnique();
            entity.HasOne(e => e.Child)
                .WithMany(c => c.Attendances)
                .HasForeignKey(e => e.ChildId);
        });

        // Configure Bus entity
        modelBuilder.Entity<Bus>(entity =>
        {
            entity.HasIndex(e => e.PlateNumber).IsUnique();
        });

        // Configure Area entity
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasIndex(e => e.Name).IsUnique();
        });

        // Configure BusRoute entity
        modelBuilder.Entity<BusRoute>(entity =>
        {
            entity.HasOne(e => e.Bus)
                .WithMany(b => b.Routes)
                .HasForeignKey(e => e.BusId);
            entity.HasOne(e => e.Area)
                .WithMany(a => a.BusRoutes)
                .HasForeignKey(e => e.AreaId);
        });

        // Configure InventoryItem entity
        modelBuilder.Entity<InventoryItem>(entity =>
        {
            entity.HasIndex(e => e.Name);
        });

        // Configure PurchaseInvoice entity
        modelBuilder.Entity<PurchaseInvoice>(entity =>
        {
            entity.HasIndex(e => e.InvoiceNumber).IsUnique();
            entity.HasOne(e => e.InventoryItem)
                .WithMany(i => i.PurchaseInvoices)
                .HasForeignKey(e => e.InventoryItemId);
        });

        // Configure SaleInvoice entity
        modelBuilder.Entity<SaleInvoice>(entity =>
        {
            entity.HasIndex(e => e.InvoiceNumber).IsUnique();
            entity.HasOne(e => e.InventoryItem)
                .WithMany(i => i.SaleInvoices)
                .HasForeignKey(e => e.InventoryItemId);
        });

        // Configure CashRegister entity
        modelBuilder.Entity<CashRegister>(entity =>
        {
            entity.HasMany(e => e.Transactions)
                .WithOne(t => t.CashRegister)
                .HasForeignKey(t => t.CashRegisterId);
        });

        // Configure CashTransaction entity
        modelBuilder.Entity<CashTransaction>(entity =>
        {
            entity.HasOne(e => e.CashRegister)
                .WithMany(r => r.Transactions)
                .HasForeignKey(e => e.CashRegisterId);
        });

        // Configure Receipt entity
        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.HasIndex(e => e.ReceiptNumber).IsUnique();
            entity.HasOne(e => e.Child)
                .WithMany()
                .HasForeignKey(e => e.ChildId);
        });

        // Configure AuditLog entity
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasIndex(e => e.ActionDate);
            entity.HasIndex(e => e.UserId);
        });
    }
}
