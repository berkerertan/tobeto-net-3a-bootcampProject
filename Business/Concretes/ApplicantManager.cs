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
            aplicant.FirstName = request.FirstName;
            aplicant.LastName = request.LastName;
            aplicant.Email = request.Email;
            aplicant.NationalIdentity = request.NationalIdentity;
            aplicant.Password = request.Password;
            aplicant.About = request.About;
            await _applicantRepository.Add(aplicant);

            CreateApplicantResponse response = new CreateApplicantResponse();
            response.FirstName = aplicant.FirstName;
            response.LastName = aplicant.LastName;
            response.Email = aplicant.Email;
            response.NationalIdentity = aplicant.NationalIdentity;
            response.About = aplicant.About;
            return response;
        }

        public async Task DeleteAsync(int id)
        {
            var applicant = await _applicantRepository.Get(a => a.UserId == id);
            if (applicant != null)
            {
                await _applicantRepository.Delete(applicant);
            }
        }

        public async Task<List<Applicant>> GetAll()
        {
            return await _applicantRepository.GetAll();
        }

        public async Task<Applicant> GetByIdAsync(int id)
        {
            return await _applicantRepository.Get(a => a.UserId == id);
        }

        public async Task<UpdateApplicantResponse> UpdateAsync(Applicant aplicant)
        {
            var updatedAplicant = await _applicantRepository.Update(aplicant);
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
