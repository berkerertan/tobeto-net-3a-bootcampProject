using Business.Abstracts;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : BaseController
    {
        private readonly IInstructorService _instructorManager;

        public InstructorsController(IInstructorService instructorManager)
        {
            _instructorManager = instructorManager;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateInstructorRequest request)
        {
            
            return HandleDataResult(await _instructorManager.AddAsync(request));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteInstructorRequest request)
        {
            return HandleResult(await _instructorManager.DeleteAsync(request));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return HandleDataResult(await _instructorManager.GetByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _instructorManager.GetAll();
            return HandleDataResult(users);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateInstructorRequest request)
        {
            return HandleDataResult(await _instructorManager.UpdateAsync(request));
        }
    }
}
