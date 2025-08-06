using inventario.src.Modules.Cities.Domain.Entities;
using inventario.src.Modules.Countries.Domain.Entities;
using inventario.src.Modules.Regions.Domain.Entties;
using inventario.src.Modules.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace inventario.src.Shared.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users => Set<User>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Region> Regions => Set<Region>();
    public DbSet<City> Cities => Set<City>();
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
