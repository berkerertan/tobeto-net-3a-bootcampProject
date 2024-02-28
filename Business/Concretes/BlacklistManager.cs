using AutoMapper;
using Business.Abstracts;
using Business.Requests.Blacklist;
using Business.Responses.Applicants;
using Business.Responses.Blacklist;
using Core.Exceptions.Types;
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
            await CheckIfIdNotExist(request.Id);

            var item = await _blacklistRepository.GetAsync(p => p.Id == request.Id);

            await _blacklistRepository.DeleteAsync(item);
            return new SuccessResult("Deleted Succesfuly");

        }

        public async Task<IDataResult<List<GetBlacklistResponse>>> GetAllAsync()
        {
            var list = await _blacklistRepository.GetAllAsync();
            List<GetBlacklistResponse> responselist = _mapper.Map<List<GetBlacklistResponse>>(list);

            return new SuccessDataResult<List<GetBlacklistResponse>>(responselist, "Listed Succesfuly.");
        }

        public async Task<IDataResult<GetBlacklistResponse>> GetByApplicantIdAsync(Guid id)
        {
            var item = await _blacklistRepository.GetAsync(x => x.ApplicantId == id);
            if (item != null)
            {
                GetBlacklistResponse response = _mapper.Map<GetBlacklistResponse>(item);
                return new SuccessDataResult<GetBlacklistResponse>(response, "found Succesfuly.");
            }
            return new ErrorDataResult<GetBlacklistResponse>("BlackListed applicant could not be found.");
        }

        public async Task<IDataResult<GetBlacklistResponse>> GetByIdAsync(GetBlacklistRequest request)
        {
            await CheckIfIdNotExist(request.Id);
            var item = await _blacklistRepository.GetAsync(p => p.Id == request.Id);

            GetBlacklistResponse response = _mapper.Map<GetBlacklistResponse>(item);
            return new SuccessDataResult<GetBlacklistResponse>(response, "Found Succesfuly.");


        }

        public async Task<IDataResult<UpdateBlacklistResponse>> UpdateAsync(UpdateBlacklistRequest request)
        {
            await CheckIfIdNotExist(request.Id);
            var item = await _blacklistRepository.GetAsync(p => p.Id == request.Id);

            _mapper.Map(request, item);
            await _blacklistRepository.UpdateAsync(item);
            UpdateBlacklistResponse response = _mapper.Map<UpdateBlacklistResponse>(item);

            return new SuccessDataResult<UpdateBlacklistResponse>(response, "Applicant succesfully updated!");
        }
        private async Task CheckIfIdNotExist(Guid id)
        {
            var isExist = await _blacklistRepository.GetAsync(user => user.Id == id);
            if (isExist is null) throw new BusinessException("Id not null");
        }
    }
}
