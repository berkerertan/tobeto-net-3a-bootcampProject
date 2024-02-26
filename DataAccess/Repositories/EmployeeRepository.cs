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
    public class EmployeeRepository : EfRepositoryBase<Employee, Guid, BaseDbContext>, IEmployeeRepository
    {
        public EmployeeRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
