using API.Core.Models;
using API.Persistance.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace API.Persistance.DbContext;

public partial class ApplicationDbContext : IApplicationDbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Place> Places { get; set; } = null!;

    private static partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8_general_ci").HasCharSet("utf8");
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new PlaceConfiguration());
    }
}