using AutoMapper;
using Azure;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Users;
using Business.Responses.Users;
using Business.Rules;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
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
        private readonly EmployeeBusinessRules _rules;

        public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper, EmployeeBusinessRules rules)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _rules = rules;
        }

        //[LogAspect(typeof(MssqlLogger))]
        public async Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request)
        {
            await _rules.CheckIfEmployeeUserNameNotExist(request.UserName);
            Employee employee = _mapper.Map<Employee>(request);
            await _employeeRepository.AddAsync(employee);
            CreateEmployeeResponse response = _mapper.Map<CreateEmployeeResponse>(employee);
            return new SuccessDataResult<CreateEmployeeResponse>(response, BaseMessages.Added);
        }

        public async Task<IResult> DeleteAsync(DeleteEmployeeRequest request)
        {
            await _rules.CheckIfEmployeeIdNotExist(request.Id);
            var item = await _employeeRepository.GetAsync(p => p.Id == request.Id);
            await _employeeRepository.DeleteAsync(item);
            return new SuccessResult(BaseMessages.Deleted);
        }

        public async Task<IDataResult<List<GetEmployeeResponse>>> GetAllAsync()
        {
            var list = await _employeeRepository.GetAllAsync();
            List<GetEmployeeResponse> responselist = _mapper.Map<List<GetEmployeeResponse>>(list);
            return new SuccessDataResult<List<GetEmployeeResponse>>(responselist, BaseMessages.GetAll);
        }

        public async Task<IDataResult<GetEmployeeResponse>> GetByIdAsync(Guid id)
        {
            await _rules.CheckIfEmployeeIdNotExist(id);
            var item = await _employeeRepository.GetAsync(p => p.Id == id);
            GetEmployeeResponse response = _mapper.Map<GetEmployeeResponse>(item);
            return new SuccessDataResult<GetEmployeeResponse>(response, BaseMessages.GetById);
        }

        public async Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request)
        {
            await _rules.CheckIfEmployeeIdNotExist(request.Id);
            var item = await _employeeRepository.GetAsync(p => p.Id == request.Id);
            _mapper.Map(request, item);
            await _employeeRepository.UpdateAsync(item);
            UpdateEmployeeResponse response = _mapper.Map<UpdateEmployeeResponse>(item);
            return new SuccessDataResult<UpdateEmployeeResponse>(response, BaseMessages.Updated);
        }
        
    }
}
