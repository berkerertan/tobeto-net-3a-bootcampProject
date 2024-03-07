using Business.Abstracts;
using Business.Requests.Applications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : BaseController
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(CreateApplicationRequest request)
        {
            return HandleDataResult(await _applicationService.AddAsync(request));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> getAllAsync()
        {
            return HandleDataResult(await _applicationService.GetAllAsync());
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> getByIdAsync(Guid id)
        {
            return HandleDataResult(await _applicationService.GetByIdAsync(id));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(DeleteApplicationRequest request)
        {
            return HandleResult(await _applicationService.DeleteAsync(request));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(UpdateApplicationRequest request)
        {
            return HandleDataResult(await _applicationService.UpdateAsync(request));
        }
    }
}
