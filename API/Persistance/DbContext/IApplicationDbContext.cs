using API.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Persistance.DbContext;

public interface IApplicationDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Place> Places { get; set; }
}