using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Blacklist;
using Business.Responses.Blacklist;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class BlacklistManager : IBlacklistService
    {
        private readonly IBlacklistRepository _blacklistRepository;
        private readonly IMapper _mapper;
        private readonly BlacklistBusinessRules _rules;

        public BlacklistManager(IBlacklistRepository blacklistRepository, IMapper mapper, BlacklistBusinessRules rules)
        {
            _blacklistRepository = blacklistRepository;
            _mapper = mapper;
            _rules = rules;
        }

        //[LogAspect(typeof(MssqlLogger))]
        public async Task<IDataResult<CreateBlacklistResponse>> AddAsync(CreateBlacklistRequest request)
        {
            await _rules.CheckIfBlacklistIdAlreadyExist(request.ApplicantId);
            Blacklist blacklist = _mapper.Map<Blacklist>(request);
            await _blacklistRepository.AddAsync(blacklist);
            CreateBlacklistResponse response = _mapper.Map<CreateBlacklistResponse>(blacklist);
            return new SuccessDataResult<CreateBlacklistResponse>(response, BaseMessages.Added);
        }

        public async Task<IResult> DeleteAsync(DeleteBlacklistRequest request)
        {
            await _rules.CheckIfBlacklistIdNotExist(request.Id);
            var item = await _blacklistRepository.GetAsync(p => p.Id == request.Id);
            await _blacklistRepository.DeleteAsync(item);
            return new SuccessResult(BaseMessages.Deleted);
        }

        public async Task<IDataResult<List<GetBlacklistResponse>>> GetAllAsync()
        {
            var list = await _blacklistRepository.GetAllAsync(include: x => x.Include(x => x.Applicant));
            List<GetBlacklistResponse> responselist = _mapper.Map<List<GetBlacklistResponse>>(list);
            return new SuccessDataResult<List<GetBlacklistResponse>>(responselist, BaseMessages.GetAll);
        }

        public async Task<IDataResult<GetBlacklistResponse>> CheckIfApplicantIsBlacklisted(Guid id)
        {
            //await _rules.CheckIfBlacklistIdNotExist(id);
            var item = await _blacklistRepository.GetAsync(x => x.ApplicantId == id);
            GetBlacklistResponse response = _mapper.Map<GetBlacklistResponse>(item);
            return new SuccessDataResult<GetBlacklistResponse>(response, "found Succesfuly.");
        }

        public async Task<IDataResult<GetBlacklistResponse>> GetByIdAsync(Guid id)
        {
            await _rules.CheckIfBlacklistIdNotExist(id);
            var item = await _blacklistRepository.GetAsync(p => p.Id == id, include: a => a.Include(x => x.Applicant));
            GetBlacklistResponse response = _mapper.Map<GetBlacklistResponse>(item);
            return new SuccessDataResult<GetBlacklistResponse>(response, BaseMessages.GetById);
        }

        public async Task<IDataResult<UpdateBlacklistResponse>> UpdateAsync(UpdateBlacklistRequest request)
        {
            await _rules.CheckIfBlacklistIdNotExist(request.Id);
            var item = await _blacklistRepository.GetAsync(p => p.Id == request.Id);
            _mapper.Map(request, item);
            await _blacklistRepository.UpdateAsync(item);
            UpdateBlacklistResponse response = _mapper.Map<UpdateBlacklistResponse>(item);
            return new SuccessDataResult<UpdateBlacklistResponse>(response, BaseMessages.Updated);
        }

    }
}
