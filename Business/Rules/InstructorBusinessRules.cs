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
            if (isExist is not null) throw new BusinessException(BaseMessages.SameName);
        }
        public async Task CheckIfInstructorIdAlreadyExist(Guid id)
        {
            var isExist = await _instructorRepository.GetAsync(x => x.Id == id);
            if (isExist is not null || id != Guid.Empty) throw new BusinessException(BaseMessages.AlreadyExist);
        }

        public async Task CheckIfInstructorIdNotExist(Guid id)
        {
            var isExist = await _instructorRepository.GetAsync(x => x.Id == id);
            if (isExist is null || id == Guid.Empty) throw new BusinessException(BaseMessages.NotExist);
        }
    }
}
