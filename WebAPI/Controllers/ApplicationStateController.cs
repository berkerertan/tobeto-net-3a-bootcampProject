using Business.Abstracts;
using Business.Requests.ApplicationStates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStateController : ControllerBase
    {
        private readonly IApplicationStateService _applicationStateService;

        public ApplicationStateController(IApplicationStateService applicationStateService)
        {
            _applicationStateService = applicationStateService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(CreateApplicationStateRequest request)
        {
            return Ok(await _applicationStateService.AddAsync(request));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> getAllAsync()
        {
            return Ok(await _applicationStateService.GetAllAsync());
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> getByIdAsync(Guid id)
        {
            return Ok(await _applicationStateService.GetByIdAsync(id));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(DeleteApplicationStateRequest request)
        {
            return Ok(await _applicationStateService.DeleteAsync(request));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(UpdateApplicationStateRequest request)
        {
            return Ok(await _applicationStateService.UpdateAsync(request));
        }
    }
}
