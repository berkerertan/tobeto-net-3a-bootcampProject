using AutoMapper;
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

namespace Business.Concretes
{
    public class ApplicationStateManager : IApplicationStateService
    {
        private readonly IApplicationStateRepository _applicantStateRepository;
        private readonly IMapper _mapper;

        public ApplicationStateManager(IApplicationStateRepository applicantStateRepository, IMapper mapper)
        {
            _applicantStateRepository = applicantStateRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
        {
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
            await _applicantStateRepository.AddAsync(applicationState);
            return new SuccessDataResult<CreateApplicationStateResponse>("Added Succesfuly");
        }

        public async Task<IResult> DeleteAsync(DeleteApplicationStateRequest request)
        {
            var item = await _applicantStateRepository.GetAsync(p => p.Id == request.Id);
            if (item != null)
            {
                await _applicantStateRepository.DeleteAsync(item);
                return new SuccessResult("Deleted Succesfuly");
            }

            return new ErrorResult("Delete Failed!");
        }

        public async Task<IDataResult<List<GetApplicationStateResponse>>> GetAllAsync()
        {
            var list = await _applicantStateRepository.GetAllAsync();
            List<GetApplicationStateResponse> responseList = _mapper.Map<List<GetApplicationStateResponse>>(list);
            return new SuccessDataResult<List<GetApplicationStateResponse>>(responseList, "Listed Succesfuly.");
        }

        public async Task<IDataResult<GetApplicationStateResponse>> GetByIdAsync(GetApplicationStateRequest request)
        {
            var item = await _applicantStateRepository.GetAsync(p => p.Id == request.Id);
            GetApplicationStateResponse response = _mapper.Map<GetApplicationStateResponse>(item);

            if (item != null)
            {
                return new SuccessDataResult<GetApplicationStateResponse>(response, "found Succesfuly.");
            }
            return new ErrorDataResult<GetApplicationStateResponse>("ApplicationState could not be found.");
        }

        public async Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
        {
            var item = await _applicantStateRepository.GetAsync(p => p.Id == request.Id);
            if (request.Id == 0 || item == null)
            {
                return new ErrorDataResult<UpdateApplicationStateResponse>("ApplicationState could not be found.");
            }

            _mapper.Map(request, item);
            await _applicantStateRepository.UpdateAsync(item);

            UpdateApplicationStateResponse response = _mapper.Map<UpdateApplicationStateResponse>(item);
            return new SuccessDataResult<UpdateApplicationStateResponse>(response, "ApplicationState succesfully updated!");
        }
    }
}
