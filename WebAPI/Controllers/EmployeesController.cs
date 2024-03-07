using Business.Abstracts;
using Business.Requests.Users;
using Business.Responses.Users;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeService _employeeManager;

        public EmployeesController(IEmployeeService employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateEmployeeRequest request)
        {
            var addedEmployee = await _employeeManager.AddAsync(request);
            return HandleDataResult(addedEmployee);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteEmployeeRequest request)
        {


            return HandleResult(await _employeeManager.DeleteAsync(request));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _employeeManager.GetByIdAsync(id);
            return HandleDataResult(user);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _employeeManager.GetAllAsync();
            return HandleDataResult(users);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateEmployeeRequest request)
        {
            return HandleDataResult(await _employeeManager.UpdateAsync(request));
        }
    }
}
