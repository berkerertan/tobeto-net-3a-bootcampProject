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
        private readonly IInstructorService _instructorManager;

        public InstructorsController(IInstructorService instructorManager)
        {
            _instructorManager = instructorManager;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateInstructorRequest request)
        {
            await _instructorManager.AddAsync(request);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteInstructorRequest request)
        {
            return Ok(await _instructorManager.DeleteAsync(request));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _instructorManager.GetByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _instructorManager.GetAll();
            return Ok(users);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateInstructorRequest request)
        {
            return Ok(await _instructorManager.UpdateAsync(request));
        }
    }
}
