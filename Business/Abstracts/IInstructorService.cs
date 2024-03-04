using Business.Requests.Instructors;
using Business.Requests.Users;
using Business.Responses.Instructors;
using Business.Responses.Users;
using Core.Utilities.Results;
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
        public Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request);
        public Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request);
        public Task<IResult> DeleteAsync(DeleteInstructorRequest request);
        public Task<IDataResult<List<GetInstructorResponse>>> GetAll();
        public Task<IDataResult<GetInstructorResponse>> GetByIdAsync(Guid id);
    }
}
