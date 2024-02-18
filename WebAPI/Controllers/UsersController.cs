using Business.Abstracts;
using Business.Requests.Users;
using Business.Responses.Users;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<CreateUserResponse> AddAsync(CreateUserRequest request)
        {
            return await _userService.AddAsync(request);
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetByIdAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest("");//HTTP yanıt kodu olarak 400 Bad Request kodunu döndürür. Kullanıcı bulunamadı.
            }

            var updatedUser = await _userService.UpdateAsync(user);
            if (updatedUser == null)
            {
                return NotFound("Kullanıcı bulunamadı");//HTTP yanıt kodu olarak 404 Not Found kodunu döndürür. Kullanıcı bulunamadı.
            }

            return Ok("Başarıyla güncellendi");//HTTP yanıt kodu olarak 200 OK kodunu döndürür. Kullanıcı başarıyla güncellendi.
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _userService.DeleteAsync(id);

            return Ok("Kullanıcı başarıyla silindi");
        }
    }
}
