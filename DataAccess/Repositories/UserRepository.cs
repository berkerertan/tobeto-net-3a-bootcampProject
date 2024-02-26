using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : EfRepositoryBase<User, Guid, BaseDbContext>,IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
            
        }
    }
}
