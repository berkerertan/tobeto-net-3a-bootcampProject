using Core.DataAccess.EntityFramework;
using Core.Utilities.Security.Entities;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;

namespace DataAccess.Repositories;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim,Guid,BaseDbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(BaseDbContext context) : base(context)
    {
        
    }
}
