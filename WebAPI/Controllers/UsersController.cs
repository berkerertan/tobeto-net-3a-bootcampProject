using Business.Abstracts;
using Business.Requests.Users;
using Business.Responses.Users;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IUserService _userManager;

        public UsersController(IUserService userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var addedUser = await _userManager.AddAsync(request);
            return Ok(addedUser);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteUserRequest request)
        {
            var item = await _userManager.DeleteAsync(request);
            return Ok(item);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(GetUserRequest request)
        {
            var user = await _userManager.GetByIdAsync(request);

            return Ok(user);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return HandleDataResult(await _userManager.GetAllAsync());
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateUserRequest request)
        {
            if (request.Id == null)
            {
                return BadRequest();
            }
            var updatedUser = await _userManager.UpdateAsync(request);
            return Ok(updatedUser);
        }
    }
}
