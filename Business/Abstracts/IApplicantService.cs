using Business.Requests.Aplicants;
using Business.Requests.Users;
using Business.Responses.Applicants;
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
    public interface IApplicantService
    {
        public Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request);
        public Task<IDataResult<List<GetApplicantResponse>>> GetAllAsync();
        public Task<IDataResult<GetApplicantResponse>> GetByIdAsync(Guid id);
        public Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request);
        public Task<IResult> DeleteAsync(DeleteApplicantRequest request);
    }
}
