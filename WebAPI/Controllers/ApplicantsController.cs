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
        private readonly IApplicantService _applicantService;

        public ApplicantsController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request)
        {
            var response = await _applicantService.AddAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<Applicant>>> GetAll()
        {
            var applicants = await _applicantService.GetAllAsync();
            return Ok(applicants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Applicant>> GetByIdAsync(int id)
        {
            var applicant = await _applicantService.GetByIdAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return Ok(applicant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Applicant applicant)
        {
            if (id != applicant.Id)
            {
                return BadRequest("Geçersiz başvuru kimliği");
            }

            var updatedApplicant = await _applicantService.UpdateAsync(applicant);
            if (updatedApplicant == null)
            {
                return NotFound("Başvuru bulunamadı");
            }

            return Ok("Başvuru başarıyla güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _applicantService.DeleteAsync(id);

            return Ok("Başvuru başarıyla silindi");
        }
    }
}
