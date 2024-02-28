using AutoMapper;
using Azure;
using Business.Abstracts;
using Business.Requests.Users;
using Business.Responses.Users;
using Core.Exceptions.Types;
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
            await CheckIfUserNameNotExist(request.UserName);
            Employee employee = _mapper.Map<Employee>(request);
            await _employeeRepository.AddAsync(employee);
            CreateEmployeeResponse response = _mapper.Map<CreateEmployeeResponse>(employee);

            return new SuccessDataResult<CreateEmployeeResponse>(response, "Added Succesfuly");
        }

        public async Task<IResult> DeleteAsync(DeleteEmployeeRequest request)
        {
            await CheckIfIdNotExist(request.Id);
            var item = await _employeeRepository.GetAsync(p => p.Id == request.Id);

            await _employeeRepository.DeleteAsync(item);
            return new SuccessResult("Deleted Succesfuly");

        }

        public async Task<IDataResult<List<GetEmployeeResponse>>> GetAllAsync()
        {

            var list = await _employeeRepository.GetAllAsync();
            List<GetEmployeeResponse> responselist = _mapper.Map<List<GetEmployeeResponse>>(list);

            return new SuccessDataResult<List<GetEmployeeResponse>>(responselist, "Listed Succesfuly.");
        }

        public async Task<IDataResult<GetEmployeeResponse>> GetByIdAsync(GetEmployeeRequest request)
        {
            await CheckIfIdNotExist(request.Id);
            var item = await _employeeRepository.GetAsync(p => p.Id == request.Id);

            GetEmployeeResponse response = _mapper.Map<GetEmployeeResponse>(item);
            return new SuccessDataResult<GetEmployeeResponse>(response, "found Succesfuly.");
        }

        public async Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request)
        {
            await CheckIfIdNotExist(request.Id);
            var item = await _employeeRepository.GetAsync(p => p.Id == request.Id);
            _mapper.Map(request, item);
            await _employeeRepository.UpdateAsync(item);
            UpdateEmployeeResponse response = _mapper.Map<UpdateEmployeeResponse>(item);

            return new SuccessDataResult<UpdateEmployeeResponse>(response, "Employee succesfully updated!");

        }
        private async Task CheckIfUserNameNotExist(string userName)
        {
            var isExist = await _employeeRepository.GetAsync(user => user.UserName == userName);
            if (isExist is not null) throw new BusinessException("Username name already exist");
        }
        private async Task CheckIfIdNotExist(Guid id)
        {
            var isExist = await _employeeRepository.GetAsync(user => user.Id == id);
            if (isExist == null || isExist.Id == Guid.Empty) throw new BusinessException("Id not null");
        }
    }
}
