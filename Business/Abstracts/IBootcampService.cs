using Business.Requests.Bootcamps;
using Business.Response.Bootcamps;
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
    public interface IBootcampService
    {
        public Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request);
        public Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request);
        public Task<IResult> DeleteAsync(DeleteBootcampRequest request);
        public Task<IDataResult<List<GetBootcampResponse>>> GetAllAsync();
        public Task<IDataResult<GetBootcampResponse>> GetByIdAsync(GetBootcampRequest request);
    }
}
