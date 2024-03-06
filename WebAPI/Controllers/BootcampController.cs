using Business.Abstracts;
using Business.Requests.Bootcamps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampController : ControllerBase
    {
        private readonly IBootcampService _bootcampService;

        public BootcampController(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(CreateBootcampRequest request)
        {
            return Ok(await _bootcampService.AddAsync(request));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> getAllAsync()
        {
            return Ok(await _bootcampService.GetAllAsync());
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> getByIdAsync(Guid id)
        {
            return Ok(await _bootcampService.GetByIdAsync(id));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(DeleteBootcampRequest request)
        {
            return Ok(await _bootcampService.DeleteAsync(request));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(UpdateBootcampRequest request)
        {
            return Ok(await _bootcampService.UpdateAsync(request));
        }
    }
}
