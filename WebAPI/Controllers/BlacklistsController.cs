using Business.Abstracts;
using Business.Requests.Aplicants;
using Business.Requests.Blacklist;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlacklistsController : BaseController
    {
        private readonly IBlacklistService _blacklistService;

        public BlacklistsController(IBlacklistService blacklistService)
        {
            _blacklistService = blacklistService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateBlacklistRequest request)
        {
            return HandleDataResult(await _blacklistService.AddAsync(request));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteBlacklistRequest request)
        {
            return HandleResult(await _blacklistService.DeleteAsync(request));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _blacklistService.GetByIdAsync(id);
            return HandleDataResult(user);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _blacklistService.GetAllAsync();
            return HandleDataResult(users);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateBlacklistRequest request)
        {
            return HandleDataResult(await _blacklistService.UpdateAsync(request));
        }
    }
}
