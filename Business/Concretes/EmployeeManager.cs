using Azure;
using Business.Abstracts;
using Business.Requests.Users;
using Business.Responses.Users;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<CreateEmployeeResponse> AddAsync(CreateEmployeeRequest request)
        {
            Employee employee = new Employee();
            employee.UserName = request.UserName;
            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Email = request.Email;
            employee.NationalIdentity = request.NationalIdentity;
            employee.Password = request.Password;
            employee.Position = request.Position;
            await _employeeRepository.AddAsync(employee);

            CreateEmployeeResponse response = new CreateEmployeeResponse();
            response.UserName = employee.UserName;
            response.FirstName = employee.FirstName;
            response.LastName = employee.LastName;
            response.Email = employee.Email;
            response.NationalIdentity = employee.NationalIdentity;
            response.Position=employee.Position;
            return response;
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _employeeRepository.GetAsync(e => e.Id == id);
            if (employee !=null)
            {
                await _employeeRepository.DeleteAsync(employee);
            }
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _employeeRepository.GetAsync(e=>e.Id == id);
        }

        public async Task<UpdateEmployeeResponse> UpdateAsync(Employee employee)
        {
            var UpdatedEmployee = await _employeeRepository.UpdateAsync(employee);
            return new UpdateEmployeeResponse
            {
                UserName = UpdatedEmployee.UserName,
                FirstName = UpdatedEmployee.FirstName,
                LastName = UpdatedEmployee.LastName,
                Email = UpdatedEmployee.Email,
                NationalIdentity = UpdatedEmployee.NationalIdentity,
                Position = UpdatedEmployee.Position
            };
        }
    }
}
