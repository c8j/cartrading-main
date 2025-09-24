using cartrade.domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace cartrade.persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Valuation> Valuations { get; set; }
    public DbSet<Engine> Engines { get; set; }
    public DbSet<FuelType> FuelTypes { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Model> Models { get; set; }
}