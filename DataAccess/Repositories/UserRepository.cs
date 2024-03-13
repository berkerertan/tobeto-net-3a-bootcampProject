using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;

namespace DataAccess.Repositories;

public class UserRepository : EfRepositoryBase<User, Guid, BaseDbContext>,IUserRepository
{
    public UserRepository(BaseDbContext context) : base(context)
    {
        
    }
}
