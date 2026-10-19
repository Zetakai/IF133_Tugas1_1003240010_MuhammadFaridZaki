using IF133.Tugas1.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace IF133.Tugas1.Api.Data;

/// <summary>
/// DbContext aplikasi. Menjembatani entity C# dengan tabel pada database SQLite.
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Description).HasMaxLength(250);
            // SQLite tidak punya tipe decimal native, disimpan sebagai TEXT
            // agar nilai uang tidak kehilangan presisi.
            entity.Property(p => p.Price).HasColumnType("TEXT");
        });
    }
}
