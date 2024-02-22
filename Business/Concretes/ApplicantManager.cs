using AutoMapper;
using Business.Abstracts;
using Business.Requests.Aplicants;
using Business.Responses.Applicants;
using Business.Responses.Users;
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

        public ApplicantManager(IApplicantRepository applicantRepository, IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request)
        {
            Applicant applicant = _mapper.Map<Applicant>(request);
            await _applicantRepository.AddAsync(applicant);
            CreateApplicantResponse response = _mapper.Map<CreateApplicantResponse>(applicant);

            return new SuccessDataResult<CreateApplicantResponse>(response, "Added Succesfuly");
        }

        public async Task<IResult> DeleteAsync(DeleteApplicantRequest request)
        {
            var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);
            if (item != null)
            {
                await _applicantRepository.DeleteAsync(item);
                return new SuccessResult("Deleted Succesfuly");
            }
            return new ErrorResult("Delete Failed!");
        }

        public async Task<IDataResult<List<GetApplicantResponse>>> GetAllAsync()
        {

            var list = await _applicantRepository.GetAllAsync();
            List<GetApplicantResponse> responselist = _mapper.Map<List<GetApplicantResponse>>(list);

            return new SuccessDataResult<List<GetApplicantResponse>>(responselist, "Listed Succesfuly.");
        }

        public async Task<IDataResult<GetApplicantResponse>> GetByIdAsync(GetApplicantRequest request)
        {
            var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);
            if (item != null)
            {
                GetApplicantResponse response = _mapper.Map<GetApplicantResponse>(item);
                return new SuccessDataResult<GetApplicantResponse>(response, "found Succesfuly.");
            }
            return new ErrorDataResult<GetApplicantResponse>("Applicant could not be found.");
        }

        public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
        {
            var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);

            if (item != null)
            {
                _mapper.Map(request, item);
                await _applicantRepository.UpdateAsync(item);
                UpdateApplicantResponse response = _mapper.Map<UpdateApplicantResponse>(item);

                return new SuccessDataResult<UpdateApplicantResponse>(response, "Applicant succesfully updated!");
            }

            return new ErrorDataResult<UpdateApplicantResponse>("Applicant could not be found.");
        }
    }
}
