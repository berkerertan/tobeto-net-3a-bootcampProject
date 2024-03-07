using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class EmployeeBusinessRules : BaseBusinessRules
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeBusinessRules(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task CheckIfEmployeeUserNameNotExist(string userName)
        {
            var isExist = await _employeeRepository.GetAsync(user => user.UserName == userName);
            if (isExist is not null) throw new BusinessException(BaseMessages.SameName);
        }
        public async Task CheckIfEmployeeIdAlreadyExist(Guid id)
        {
            var isExist = await _employeeRepository.GetAsync(x => x.Id == id);
            if (isExist is not null || id != Guid.Empty) throw new BusinessException(BaseMessages.AlreadyExist);
        }

        public async Task CheckIfEmployeeIdNotExist(Guid id)
        {
            var isExist = await _employeeRepository.GetAsync(x => x.Id == id);
            if (isExist is null || id == Guid.Empty) throw new BusinessException(BaseMessages.NotExist);
        }
    }
}
