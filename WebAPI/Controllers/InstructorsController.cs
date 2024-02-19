using Business.Abstracts;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request)
        {
            var response = await _instructorService.AddAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<Instructor>>> GetAll()
        {
            var instructors = await _instructorService.GetAllAsync();
            return Ok(instructors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Instructor>> GetByIdAsync(int id)
        {
            var instructor = await _instructorService.GetByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return Ok(instructor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Instructor instructor)
        {
            if (id != instructor.Id)
            {
                return BadRequest("Geçersiz eğitmen kimliği");
            }

            var updatedInstructor = await _instructorService.UpdateAsync(instructor);
            if (updatedInstructor == null)
            {
                return NotFound("Eğitmen bulunamadı");
            }

            return Ok("Eğitmen başarıyla güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _instructorService.DeleteAsync(id);

            return Ok("Eğitmen başarıyla silindi");
        }
    }
}
