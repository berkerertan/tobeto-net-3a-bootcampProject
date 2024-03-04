using Business.Requests.Aplicants;
using Business.Requests.Applications;
using Business.Response.Applications;
using Business.Responses.Applicants;
using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IApplicationService
    {
        public Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request);
        public Task<IDataResult<List<GetApplicationResponse>>> GetAllAsync();
        public Task<IDataResult<GetApplicationResponse>> GetByIdAsync(Guid id);
        public Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request);
        public Task<IResult> DeleteAsync(DeleteApplicationRequest request);
    }
}
