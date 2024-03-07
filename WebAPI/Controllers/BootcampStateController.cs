using Business.Abstracts;
using Business.Requests.BootcampStates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampStateController : BaseController
    {
        private readonly IBootcampStateService _bootcampStateService;

        public BootcampStateController(IBootcampStateService bootcampStateService)
        {
            _bootcampStateService = bootcampStateService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(CreateBootcampStateRequest request)
        {
            return HandleDataResult(await _bootcampStateService.AddAsync(request));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> getAllAsync()
        {
            return HandleDataResult(await _bootcampStateService.GetAllAsync());
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> getByIdAsync(Guid id)
        {
            return HandleDataResult(await _bootcampStateService.GetByIdAsync(id));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(DeleteBootcampStateRequest request)
        {
            return HandleResult(await _bootcampStateService.DeleteAsync(request));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(UpdateBootcampStateRequest request)
        {
            return HandleDataResult(await _bootcampStateService.UpdateAsync(request));
        }
    }
}
