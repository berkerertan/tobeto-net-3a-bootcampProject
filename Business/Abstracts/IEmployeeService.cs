using Business.Requests.Users;
using Business.Responses.Users;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IEmployeeService
    {
        Task<CreateEmployeeResponse> AddAsync(CreateEmployeeRequest request);
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<UpdateEmployeeResponse> UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
    }
}
