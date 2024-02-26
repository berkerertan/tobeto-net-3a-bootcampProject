using Core.DataAccess;
using DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IInstructorRepository : IAsyncRepository<Instructor, Guid>
    {
    }
}
