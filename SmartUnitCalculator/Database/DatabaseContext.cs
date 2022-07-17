using Microsoft.EntityFrameworkCore;
using SmartUnitCalculator.Database.Models;

namespace SmartUnitCalculator.Database;
public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UnitType>? UnitTypes { get; set; }
    public DbSet<Unit>? Units { get; set; }
    public DbSet<Calculation>? Calculations { get; set; }
    public DbSet<History>? History { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(user =>
        {
            user.HasKey(u => u.Id);
            user.Property(u => u.Login).HasMaxLength(50).IsRequired();
            user.HasIndex(u => u.Login).IsUnique();
            user.Property(u => u.Password).IsRequired();
        });

        modelBuilder.Entity<UnitType>(unitType =>
        {
            unitType.HasKey(ut => ut.Name);
            unitType.Property(ut => ut.Priority).IsRequired();
            unitType.HasIndex(ut => ut.Priority).IsUnique();
        });

        modelBuilder.Entity<Unit>(unit =>
        {
            unit.HasKey(u => u.Id);
            unit.HasOne(u => u.Type).WithMany().HasForeignKey(u => u.TypeName);
            unit.Property(u => u.Name).IsRequired();
            unit.Property(u => u.Symbol).HasMaxLength(50).IsRequired(false);
            unit.Property(u => u.Priority).IsRequired();
        });

        modelBuilder.Entity<Calculation>(calculation =>
        {
            calculation.HasKey(c => c.Id);
            calculation.HasOne(c => c.BaseUnit).WithMany(u => u.Calculations).HasForeignKey(c => c.BaseUnitId).OnDelete(DeleteBehavior.Restrict);
            calculation.HasOne(c => c.ResultUnit).WithMany().HasForeignKey(c => c.ResultUnitId).OnDelete(DeleteBehavior.Restrict);
            calculation.Property(c => c.Multiplier).HasPrecision(28, 14).IsRequired(false);
        });

        modelBuilder.Entity<History>(history =>
        {
            history.HasKey(h => h.Id);
            history.HasOne(h => h.User).WithMany(u => u.History).HasForeignKey(h => h.UserId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
            history.HasOne(h => h.BaseUnit).WithMany().HasForeignKey(h => h.BaseUnitId).OnDelete(DeleteBehavior.Restrict);
            history.HasOne(h => h.ResultUnit).WithMany().HasForeignKey(h => h.ResultUnitId).OnDelete(DeleteBehavior.Restrict);
            history.Property(h => h.BaseValue).HasPrecision(28, 14);
            history.Property(h => h.ResultValue).HasPrecision(28, 14);
            history.Property(h => h.Created).HasDefaultValueSql("getdate()");
        });

        new DatabaseSeeder(modelBuilder).Seed();
    }
}
