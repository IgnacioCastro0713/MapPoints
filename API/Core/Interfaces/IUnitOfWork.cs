using API.Core.Interfaces.Repositories;

namespace API.Core.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    
    Task<int> Complete();
}