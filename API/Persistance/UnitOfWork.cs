using API.Core.Interfaces;
using API.Core.Interfaces.Repositories;
using API.Persistance.DbContext;
using API.Persistance.Repositories;

namespace API.Persistance;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IUserRepository UserRepository { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        UserRepository = new UserRepository(_context);
    }

    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }
}