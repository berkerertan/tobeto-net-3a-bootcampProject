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
    public class BootcampStateBusinessRules : BaseBusinessRules
    {
        private readonly IBootcampStateRepository _bootcampStateRepository;

        public BootcampStateBusinessRules(IBootcampStateRepository bootcampStateRepository)
        {
            _bootcampStateRepository = bootcampStateRepository;
        }

        public async Task CheckIfBootcampStateIdNotExist(Guid id)
        {
            var isExist = await _bootcampStateRepository.GetAsync(user => user.Id == id);
            if (isExist is null) throw new BusinessException("Id not null");
        }
    }
}
