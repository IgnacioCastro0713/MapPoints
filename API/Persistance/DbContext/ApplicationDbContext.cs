using Microsoft.EntityFrameworkCore;

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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    private static partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}