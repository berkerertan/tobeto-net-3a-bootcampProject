using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IBootcampStateService
    {
        public Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request);
        public Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request);
        public Task<IResult> DeleteAsync(DeleteBootcampStateRequest request);
        public Task<IDataResult<List<GetBootcampStateResponse>>> GetAllAsync();
        public Task<IDataResult<GetBootcampStateResponse>> GetByIdAsync(Guid id);
    }
}
