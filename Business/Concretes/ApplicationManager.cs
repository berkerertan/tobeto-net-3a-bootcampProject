using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Applications;
using Business.Response.Applications;
using Business.Rules;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ApplicationManager : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationBusinessRules _rules;

        public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper, IBlacklistService blacklistService, ApplicationBusinessRules rules)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
            _rules = rules;
        }

        //[LogAspect(typeof(MssqlLogger))]
        public async Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request)
        {
            await _rules.CheckIfApplicantIsBlacklisted(request.ApplicantId);
           
            Application application = _mapper.Map<Application>(request);
            await _applicationRepository.AddAsync(application);
            return new SuccessDataResult<CreateApplicationResponse>(BaseMessages.Added);
        }

        public async Task<IResult> DeleteAsync(DeleteApplicationRequest request)
        {
            await _rules.CheckIfApplicationIdNotExist(request.Id);
            var item = await _applicationRepository.GetAsync(p => p.Id == request.Id);

            await _applicationRepository.DeleteAsync(item);
            return new SuccessResult(BaseMessages.Deleted);

        }

        public async Task<IDataResult<List<GetApplicationResponse>>> GetAllAsync()
        {
            var list = await _applicationRepository.GetAllAsync(include: x => x.Include(p => p.Applicant).Include(p => p.Bootcamp).Include(p => p.ApplicationState));
            List<GetApplicationResponse> responseList = _mapper.Map<List<GetApplicationResponse>>(list);
            return new SuccessDataResult<List<GetApplicationResponse>>(responseList, BaseMessages.GetAll);
        }

        public async Task<IDataResult<GetApplicationResponse>> GetByIdAsync(Guid id)
        {
            await _rules.CheckIfApplicationIdNotExist(id);
            var list = await _applicationRepository.GetAllAsync(include: x => x.Include(p => p.Applicant).Include(p => p.Bootcamp).Include(p => p.ApplicationState));
            var item = list.Where(p => p.Id == id).FirstOrDefault();
            GetApplicationResponse response = _mapper.Map<GetApplicationResponse>(item);


            return new SuccessDataResult<GetApplicationResponse>(response, BaseMessages.GetById);


        }

        public async Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request)
        {
            await _rules.CheckIfApplicationIdNotExist(request.Id);
            var item = await _applicationRepository.GetAsync(p => p.Id == request.Id, include: x => x.Include(p => p.Applicant).Include(p => p.Bootcamp));
            _mapper.Map(request, item);
            await _applicationRepository.UpdateAsync(item);
            UpdateApplicationResponse response = _mapper.Map<UpdateApplicationResponse>(item);
            return new SuccessDataResult<UpdateApplicationResponse>(response, BaseMessages.Updated);


        }

    }
}
