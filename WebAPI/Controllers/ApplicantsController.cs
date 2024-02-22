using Business.Abstracts;
using Business.Requests.Aplicants;
using Business.Responses.Applicants;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        private readonly IApplicantService _applicantManager;

        public ApplicantsController(IApplicantService applicantManager)
        {
            _applicantManager = applicantManager;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateApplicantRequest request)
        {
            return Ok(await _applicantManager.AddAsync(request));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteApplicantRequest request)
        {
            return Ok(await _applicantManager.DeleteAsync(request));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(GetApplicantRequest request)
        {
            var user = await _applicantManager.GetByIdAsync(request);
            return Ok(user);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _applicantManager.GetAllAsync();
            return Ok(users);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateApplicantRequest request)
        {
            return Ok(await _applicantManager.UpdateAsync(request));
        }
    }
}
