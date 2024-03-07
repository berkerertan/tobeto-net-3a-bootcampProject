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
    public class BootcampBusinessRules : BaseBusinessRules
    {
        private readonly IBootcampRepository _bootcampRepository;

        public BootcampBusinessRules(IBootcampRepository bootcampRepository)
        {
            _bootcampRepository = bootcampRepository;
        }

        public async Task CheckIfBootcampIdAlreadyExist(Guid id)
        {
            var isExist = await _bootcampRepository.GetAsync(x => x.Id == id);
            if (isExist is not null || id != Guid.Empty) throw new BusinessException(BaseMessages.AlreadyExist);
        }

        public async Task CheckIfBootcampIdNotExist(Guid id)
        {
            var isExist = await _bootcampRepository.GetAsync(x => x.Id == id);
            if (isExist is null || id == Guid.Empty) throw new BusinessException(BaseMessages.NotExist);
        }
    }
}
