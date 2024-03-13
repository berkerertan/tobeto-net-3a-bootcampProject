using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Security.Entities;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DataAccess.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim ,Guid, BaseDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}
