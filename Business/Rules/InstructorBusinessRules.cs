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
    public class InstructorBusinessRules : BaseBusinessRules
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorBusinessRules(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task CheckIfInstructorUserNameNotExist(string userName)
        {
            var isExist = await _instructorRepository.GetAsync(user => user.UserName == userName);
            if (isExist is not null) throw new BusinessException("Username name already exist");
        }
        public async Task CheckIfInstructorIdNotExist(Guid id)
        {
            var isExist = await _instructorRepository.GetAsync(user => user.Id == id);
            if (isExist is null) throw new BusinessException("Id not null");
        }
    }
}
