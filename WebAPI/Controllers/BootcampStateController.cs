using Business.Abstracts;
using Business.Requests.BootcampStates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampStateController : ControllerBase
    {
        private readonly IBootcampStateService _bootcampStateService;

        public BootcampStateController(IBootcampStateService bootcampStateService)
        {
            _bootcampStateService = bootcampStateService;
        }

        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(CreateBootcampStateRequest request)
        {
            return Ok(await _bootcampStateService.AddAsync(request));
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> getAllAsync()
        {
            return Ok(await _bootcampStateService.GetAllAsync());
        }

        [HttpPost("GetByIdAsync")]
        public async Task<IActionResult> getByIdAsync(GetBootcampStateRequest request)
        {
            return Ok(await _bootcampStateService.GetByIdAsync(request));
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(DeleteBootcampStateRequest request)
        {
            return Ok(await _bootcampStateService.DeleteAsync(request));
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(UpdateBootcampStateRequest request)
        {
            return Ok(await _bootcampStateService.UpdateAsync(request));
        }
    }
}
