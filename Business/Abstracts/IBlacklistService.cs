using Business.Requests.Aplicants;
using Business.Requests.Blacklist;
using Business.Responses.Applicants;
using Business.Responses.Blacklist;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IBlacklistService
    {
        public Task<IDataResult<CreateBlacklistResponse>> AddAsync(CreateBlacklistRequest request);
        public Task<IDataResult<List<GetBlacklistResponse>>> GetAllAsync();
        public Task<IDataResult<GetBlacklistResponse>> GetByIdAsync(GetBlacklistRequest request);
        public Task<IDataResult<UpdateBlacklistResponse>> UpdateAsync(UpdateBlacklistRequest request);
        public Task<IResult> DeleteAsync(DeleteBlacklistRequest request);
        Task<IDataResult<GetBlacklistResponse>> GetByApplicantIdAsync(Guid id);
    }
}
