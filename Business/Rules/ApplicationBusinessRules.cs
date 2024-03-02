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
    public class ApplicationBusinessRules : BaseBusinessRules
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationBusinessRules(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task CheckIfApplicationIdNotExist(Guid id)
        {
            var isExist = await _applicationRepository.GetAsync(user => user.Id == id);
            if (isExist is null) throw new BusinessException("Id not null");
        }
    }
}
