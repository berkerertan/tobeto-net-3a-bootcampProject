using AutoMapper;
using Azure;
using Business.Abstracts;
using Business.Requests.Users;
using Business.Responses.Users;
using Core.Utilities.Results;
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
        private readonly IMapper _mapper;

        public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request)
        {
            Employee employee = _mapper.Map<Employee>(request);
            await _employeeRepository.AddAsync(employee);
            CreateEmployeeResponse response = _mapper.Map<CreateEmployeeResponse>(employee);

            return new SuccessDataResult<CreateEmployeeResponse>(response, "Added Succesfuly");
        }

        public async Task<IResult> DeleteAsync(DeleteEmployeeRequest request)
        {
            var item = await _employeeRepository.GetAsync(p => p.Id == request.Id);
            if (item != null)
            {
                await _employeeRepository.DeleteAsync(item);
                return new SuccessResult("Deleted Succesfuly");
            }
            return new ErrorResult("Delete Failed!");
        }

        public async Task<IDataResult<List<GetEmployeeResponse>>> GetAllAsync()
        {

            var list = await _employeeRepository.GetAllAsync();
            List<GetEmployeeResponse> responselist = _mapper.Map<List<GetEmployeeResponse>>(list);

            return new SuccessDataResult<List<GetEmployeeResponse>>(responselist, "Listed Succesfuly.");
        }

        public async Task<IDataResult<GetEmployeeResponse>> GetByIdAsync(GetEmployeeRequest request)
        {
            var item = await _employeeRepository.GetAsync(p => p.Id == request.Id);
            if (item != null)
            {
                GetEmployeeResponse response = _mapper.Map<GetEmployeeResponse>(item);
                return new SuccessDataResult<GetEmployeeResponse>(response, "found Succesfuly.");
            }
            return new ErrorDataResult<GetEmployeeResponse>("Employee could not be found.");
        }

        public async Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request)
        {
            var item = await _employeeRepository.GetAsync(p => p.Id == request.Id);

            if (item != null)
            {
                _mapper.Map(request, item);
                await _employeeRepository.UpdateAsync(item);
                UpdateEmployeeResponse response = _mapper.Map<UpdateEmployeeResponse>(item);

                return new SuccessDataResult<UpdateEmployeeResponse>(response, "Employee succesfully updated!");
            }

            return new ErrorDataResult<UpdateEmployeeResponse>("Employee could not be found.");
        }
    }
}
