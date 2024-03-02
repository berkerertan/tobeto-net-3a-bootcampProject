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
    public class BootcampBusinessRules : BaseBusinessRules
    {
        private readonly IBootcampRepository _bootcampRepository;

        public BootcampBusinessRules(IBootcampRepository bootcampRepository)
        {
            _bootcampRepository = bootcampRepository;
        }

        public async Task CheckIfBootcampIdNotExist(Guid id)
        {
            var isExist = await _bootcampRepository.GetAsync(user => user.Id == id);
            if (isExist is null) throw new BusinessException("Id not null");
        }
    }
}
