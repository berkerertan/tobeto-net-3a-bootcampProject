using Business.Abstracts;
using Business.Requests.Applications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(CreateApplicationRequest request)
        {
            return Ok(await _applicationService.AddAsync(request));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> getAllAsync()
        {
            return Ok(await _applicationService.GetAllAsync());
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> getByIdAsync(Guid id)
        {
            return Ok(await _applicationService.GetByIdAsync(id));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(DeleteApplicationRequest request)
        {
            return Ok(await _applicationService.DeleteAsync(request));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(UpdateApplicationRequest request)
        {
            return Ok(await _applicationService.UpdateAsync(request));
        }
    }
}
