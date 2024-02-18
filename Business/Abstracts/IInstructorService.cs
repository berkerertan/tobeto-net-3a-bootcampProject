using Business.Requests.Instructors;
using Business.Requests.Users;
using Business.Responses.Instructors;
using Business.Responses.Users;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IInstructorService
    {
        Task<CreateInstructorResponse> AddAsync(CreateInstructorRequest request);
        Task<List<Instructor>> GetAll();
        Task<Instructor> GetByIdAsync(int id);
        Task<UpdateInstructorResponse> UpdateAsync(Instructor instructor);
        Task DeleteAsync(int id);
    }
}
