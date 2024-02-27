using AutoMapper;
using Business.Abstracts;
using Business.Requests.Blacklist;
using Business.Responses.Applicants;
using Business.Responses.Blacklist;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class BlacklistManager : IBlacklistService
    {
        private readonly IBlacklistRepository _blacklistRepository;
        private readonly IMapper _mapper;

        public BlacklistManager(IBlacklistRepository blacklistRepository, IMapper mapper)
        {
            _blacklistRepository = blacklistRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateBlacklistResponse>> AddAsync(CreateBlacklistRequest request)
        {
            Blacklist blacklist = _mapper.Map<Blacklist>(request);
            await _blacklistRepository.AddAsync(blacklist);
            CreateBlacklistResponse response = _mapper.Map<CreateBlacklistResponse>(blacklist);

            return new SuccessDataResult<CreateBlacklistResponse>(response, "Added Succesfuly");
        }

        public async Task<IResult> DeleteAsync(DeleteBlacklistRequest request)
        {
            var item = await _blacklistRepository.GetAsync(p => p.Id == request.Id);
            if (item != null)
            {
                await _blacklistRepository.DeleteAsync(item);
                return new SuccessResult("Deleted Succesfuly");
            }
            return new ErrorResult("Delete Failed!");
        }

        public async Task<IDataResult<List<GetBlacklistResponse>>> GetAllAsync()
        {
            var list = await _blacklistRepository.GetAllAsync();
            List<GetBlacklistResponse> responselist = _mapper.Map<List<GetBlacklistResponse>>(list);

            return new SuccessDataResult<List<GetBlacklistResponse>>(responselist, "Listed Succesfuly.");
        }

        public async Task<IDataResult<GetBlacklistResponse>> GetByIdAsync(GetBlacklistRequest request)
        {
            var item = await _blacklistRepository.GetAsync(p => p.Id == request.Id);
            if (item != null)
            {
                GetBlacklistResponse response = _mapper.Map<GetBlacklistResponse>(item);
                return new SuccessDataResult<GetBlacklistResponse>(response, "Found Succesfuly.");
            }
            return new ErrorDataResult<GetBlacklistResponse>("Applicant could not be found.");
        }

        public async Task<IDataResult<UpdateBlacklistResponse>> UpdateAsync(UpdateBlacklistRequest request)
        {
            var item = await _blacklistRepository.GetAsync(p => p.Id == request.Id);

            if (item != null)
            {
                _mapper.Map(request, item);
                await _blacklistRepository.UpdateAsync(item);
                UpdateBlacklistResponse response = _mapper.Map<UpdateBlacklistResponse>(item);

                return new SuccessDataResult<UpdateBlacklistResponse>(response, "Applicant succesfully updated!");
            }

            return new ErrorDataResult<UpdateBlacklistResponse>("Applicant could not be found.");
        }
    }
}
