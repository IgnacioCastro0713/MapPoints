
using Microsoft.EntityFrameworkCore;
using API.Core.Models;
using API.Persistance.EntityConfigurations;

namespace API.Persistance.DbContext;

public partial class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Place> Places { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        { 
            optionsBuilder.UseMySql("server=localhost;database=map_points;user=root", ServerVersion.Parse("10.4.14-mariadb"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8_general_ci").HasCharSet("utf8");
        modelBuilder.ApplyConfiguration(new PlaceConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}