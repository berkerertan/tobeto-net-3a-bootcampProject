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
    public class BootcampStateBusinessRules : BaseBusinessRules
    {
        private readonly IBootcampStateRepository _bootcampStateRepository;

        public BootcampStateBusinessRules(IBootcampStateRepository bootcampStateRepository)
        {
            _bootcampStateRepository = bootcampStateRepository;
        }

        public async Task CheckIfBootcampStateIdAlreadyExist(Guid id)
        {
            var isExist = await _bootcampStateRepository.GetAsync(x => x.Id == id);
            if (isExist is not null || id != Guid.Empty) throw new BusinessException(BaseMessages.AlreadyExist);
        }

        public async Task CheckIfBootcampStateIdNotExist(Guid id)
        {
            var isExist = await _bootcampStateRepository.GetAsync(x => x.Id == id);
            if (isExist is null || id == Guid.Empty) throw new BusinessException(BaseMessages.NotExist);
        }
        public async Task CheckIfBootcampStateNameHave(string name)
        {
            var isExist = await _bootcampStateRepository.GetAsync(x => x.Name == name);
            if (isExist is not null) throw new BusinessException(BaseMessages.SameName);
        }
    }
}
