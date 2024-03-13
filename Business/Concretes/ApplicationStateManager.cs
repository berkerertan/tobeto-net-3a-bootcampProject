using AutoMapper;
using AutoMapper.Configuration;
using Business.Abstracts;
using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;
using DataAccess.Repositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstracts;
using Business.Rules;
using Azure.Core;
using Business.Constants;

namespace Business.Concretes
{
    public class ApplicationStateManager : IApplicationStateService
    {
        private readonly IApplicationStateRepository _applicantStateRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationStateBusinessRules _rules;

        public ApplicationStateManager(IApplicationStateRepository applicantStateRepository, IMapper mapper, ApplicationStateBusinessRules rules)
        {
            _applicantStateRepository = applicantStateRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
        {
            await _rules.CheckIfApplicationStateNameHave(request.Name);
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
            await _applicantStateRepository.AddAsync(applicationState);
            return new SuccessDataResult<CreateApplicationStateResponse>(BaseMessages.Added);
        }

        public async Task<IResult> DeleteAsync(DeleteApplicationStateRequest request)
        {
            await _rules.CheckIfApplicationStateIdNotExist(request.Id);
            var item = await _applicantStateRepository.GetAsync(p => p.Id == request.Id);
            await _applicantStateRepository.DeleteAsync(item);
            return new SuccessResult(BaseMessages.Deleted);
        }

        public async Task<IDataResult<List<GetApplicationStateResponse>>> GetAllAsync()
        {
            var list = await _applicantStateRepository.GetAllAsync();
            List<GetApplicationStateResponse> responseList = _mapper.Map<List<GetApplicationStateResponse>>(list);
            return new SuccessDataResult<List<GetApplicationStateResponse>>(responseList, BaseMessages.GetAll);
        }

        public async Task<IDataResult<GetApplicationStateResponse>> GetByIdAsync(Guid id)
        {
            await _rules.CheckIfApplicationStateIdNotExist(id);
            var item = await _applicantStateRepository.GetAsync(p => p.Id == id);
            GetApplicationStateResponse response = _mapper.Map<GetApplicationStateResponse>(item);
            return new SuccessDataResult<GetApplicationStateResponse>(response, BaseMessages.GetById);
        }

        public async Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
        {
            await _rules.CheckIfApplicationStateIdNotExist(request.Id);
            var item = await _applicantStateRepository.GetAsync(p => p.Id == request.Id);
            _mapper.Map(request, item);
            await _applicantStateRepository.UpdateAsync(item);

            UpdateApplicationStateResponse response = _mapper.Map<UpdateApplicationStateResponse>(item);
            return new SuccessDataResult<UpdateApplicationStateResponse>(response, BaseMessages.Updated);
        }
    }
}
