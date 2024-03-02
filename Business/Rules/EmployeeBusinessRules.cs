using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
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
            if (isExist is not null) throw new BusinessException("Username name already exist");
        }
        public async Task CheckIfEmployeeIdNotExist(Guid id)
        {
            var isExist = await _employeeRepository.GetAsync(user => user.Id == id);
            if (isExist == null || isExist.Id == Guid.Empty) throw new BusinessException("Id not null");
        }
    }
}
