using Business.Abstracts;
using Core.Utilities.Security.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("RegisterForApplicant")]
        public async Task<IActionResult> Register(ApplicantForRegisterDto applicantForRegisterDto)
        {
            var result = await _authService.ApplicantRegister(applicantForRegisterDto);
            return HandleDataResult(result);
        }

        [HttpPost("RegisterForEmployee")]
        public async Task<IActionResult> Register(EmployeeForRegisterDto employeeForRegisterDto)
        {
            var result = await _authService.EmployeeRegister(employeeForRegisterDto);
            return HandleDataResult(result);
        }

        [HttpPost("RegisterForInstructor")]
        public async Task<IActionResult> Register(InstructorForRegisterDto instructorForRegisterDto)
        {
            var result = await _authService.InstructorRegister(instructorForRegisterDto);
            return HandleDataResult(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var result = await _authService.Login(userForLoginDto);
            return HandleDataResult(result);
        }
    }
}
