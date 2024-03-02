using AutoMapper;
using Azure.Core;
using Business.Abstracts;
using Business.Requests.Aplicants;
using Business.Responses.Applicants;
using Business.Responses.Users;
using Business.Rules;
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
    public class ApplicantManager : IApplicantService

    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMapper _mapper;
        private readonly ApplicantBusinessRules _rules;

        public ApplicantManager(IApplicantRepository applicantRepository, IMapper mapper, ApplicantBusinessRules rules)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request)
        {
            await _rules.CheckIfApplicantUserNameNotExist(request.UserName);
            Applicant applicant = _mapper.Map<Applicant>(request);
            await _applicantRepository.AddAsync(applicant);
            CreateApplicantResponse response = _mapper.Map<CreateApplicantResponse>(applicant);

            return new SuccessDataResult<CreateApplicantResponse>(response, "Added Succesfuly");
        }

        public async Task<IResult> DeleteAsync(DeleteApplicantRequest request)
        {
            await _rules.CheckIfApplicantIdNotExist(request.Id);
            var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);

            await _applicantRepository.DeleteAsync(item);
            return new SuccessResult("Deleted Succesfuly");
        }

        public async Task<IDataResult<List<GetApplicantResponse>>> GetAllAsync()
        {

            var list = await _applicantRepository.GetAllAsync();
            List<GetApplicantResponse> responselist = _mapper.Map<List<GetApplicantResponse>>(list);

            return new SuccessDataResult<List<GetApplicantResponse>>(responselist, "Listed Succesfuly.");
        }

        public async Task<IDataResult<GetApplicantResponse>> GetByIdAsync(Guid id)
        {
            await _rules.CheckIfApplicantIdNotExist(id);
            var item = await _applicantRepository.GetAsync(p => p.Id == id);

            GetApplicantResponse response = _mapper.Map<GetApplicantResponse>(item);
            return new SuccessDataResult<GetApplicantResponse>(response, "found Succesfuly.");


        }

        public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
        {
            await _rules.CheckIfApplicantIdNotExist(request.Id);

            var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);


            _mapper.Map(request, item);
            await _applicantRepository.UpdateAsync(item);
            UpdateApplicantResponse response = _mapper.Map<UpdateApplicantResponse>(item);

            return new SuccessDataResult<UpdateApplicantResponse>(response, "Applicant succesfully updated!");



        }
        
    }
}
