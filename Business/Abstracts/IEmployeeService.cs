using Business.Requests.Users;
using Business.Responses.Users;
using Core.Utilities.Results;
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
        public Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request);
        public Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request);
        public Task<IResult> DeleteAsync(DeleteEmployeeRequest request);
        public Task<IDataResult<List<GetEmployeeResponse>>> GetAllAsync();
        public Task<IDataResult<GetEmployeeResponse>> GetByIdAsync(GetEmployeeRequest request);
    }
}
