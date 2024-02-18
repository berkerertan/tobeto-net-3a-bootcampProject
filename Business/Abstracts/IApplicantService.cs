using Business.Requests.Aplicants;
using Business.Requests.Users;
using Business.Responses.Applicants;
using Business.Responses.Users;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IApplicantService
    {
        Task<CreateApplicantResponse> AddAsync(CreateApplicantRequest request);
        Task<List<Applicant>> GetAll();
        Task<Applicant> GetByIdAsync(int id);
        Task<UpdateApplicantResponse> UpdateAsync(Applicant aplicant);
        Task DeleteAsync(int id);
    }
}
