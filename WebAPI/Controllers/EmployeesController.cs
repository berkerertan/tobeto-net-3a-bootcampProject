using Business.Abstracts;
using Business.Requests.Users;
using Business.Responses.Users;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request)
        {
            var response = await _employeeService.AddAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest("Geçersiz çalışan kimliği");
            }
            var updatedEmployee = await _employeeService.UpdateAsync(employee);
            if (updatedEmployee == null)
            {
                return NotFound("Çalışan bulunamadı");
            }
            return Ok("Çalışan başarıyla güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _employeeService.DeleteAsync(id);
            return Ok("Çalışan başarıyla silindi");
        }
    }
}
