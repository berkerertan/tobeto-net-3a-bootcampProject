using Business.Abstracts;
using Business.Requests.Aplicants;
using Business.Responses.Applicants;
using Business.Responses.Users;
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
        public ApplicantManager(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }
        public async Task<CreateApplicantResponse> AddAsync(CreateApplicantRequest request)
        {
            Applicant aplicant = new Applicant();
            aplicant.UserName = request.UserName;
            aplicant.FirstName = request.FirstName;
            aplicant.LastName = request.LastName;
            aplicant.Email = request.Email;
            aplicant.NationalIdentity = request.NationalIdentity;
            aplicant.Password = request.Password;
            aplicant.About = request.About;
            await _applicantRepository.AddAsync(aplicant);

            CreateApplicantResponse response = new CreateApplicantResponse();
            response.UserName = aplicant.UserName;
            response.FirstName = aplicant.FirstName;
            response.LastName = aplicant.LastName;
            response.Email = aplicant.Email;
            response.NationalIdentity = aplicant.NationalIdentity;
            response.About = aplicant.About;
            return response;
        }

        public async Task DeleteAsync(int id)
        {
            var applicant = await _applicantRepository.GetAsync(a => a.Id == id);
            if (applicant != null)
            {
                await _applicantRepository.DeleteAsync(applicant);
            }
        }

        public async Task<List<Applicant>> GetAllAsync()
        {
            return await _applicantRepository.GetAllAsync();
        }

        public async Task<Applicant> GetByIdAsync(int id)
        {
            return await _applicantRepository.GetAsync(a => a.Id == id);
        }

        public async Task<UpdateApplicantResponse> UpdateAsync(Applicant aplicant)
        {
            var updatedAplicant = await _applicantRepository.UpdateAsync(aplicant);
            return new UpdateApplicantResponse
            {
                UserName = updatedAplicant.UserName,
                FirstName = updatedAplicant.FirstName,
                LastName = updatedAplicant.LastName,
                Email = updatedAplicant.Email,
                NationalIdentity = updatedAplicant.NationalIdentity,
                About = updatedAplicant.About
            };
        }
    }
}
