using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IApplicationStateService
    {
        public Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request);
        public Task<IDataResult<List<GetApplicationStateResponse>>> GetAllAsync();
        public Task<IDataResult<GetApplicationStateResponse>> GetByIdAsync(GetApplicationStateRequest request);
        public Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request);
        public Task<IResult> DeleteAsync(DeleteApplicationStateRequest request);
    }
}
