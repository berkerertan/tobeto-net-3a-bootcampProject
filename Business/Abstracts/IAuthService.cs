using Core.Entities;
using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.JWT;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAuthService
    {
        Task<DataResult<AccessToken>> Login(UserForLoginDto userForLoginDto);
        Task<DataResult<AccessToken>> InstructorRegister(InstructorForRegisterDto instructorForRegisterDto);
        Task<DataResult<AccessToken>> EmployeeRegister(EmployeeForRegisterDto employeeForRegisterDto);
        Task<DataResult<AccessToken>> ApplicantRegister(ApplicantForRegisterDto applicantForRegisterDto);
        Task<DataResult<AccessToken>> CreateAccessToken(User user);
        //Task<DataResult<AccessToken>> CreateAccessToken(Employee employee);
        //Task<DataResult<AccessToken>> CreateAccessToken(Instructor instructor);
        //Task<DataResult<AccessToken>> CreateAccessToken(Applicant applicant);
    }
}
