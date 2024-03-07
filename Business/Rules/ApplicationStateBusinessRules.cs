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
    public class ApplicationStateBusinessRules : BaseBusinessRules
    {
        private readonly IApplicationStateRepository _applicantStateRepository;

        public ApplicationStateBusinessRules(IApplicationStateRepository applicantStateRepository)
        {
            _applicantStateRepository = applicantStateRepository;
        }
        public async Task CheckIfApplicationStateIdAlreadyExist(Guid id)
        {
            var isExist = await _applicantStateRepository.GetAsync(x => x.Id == id);
            if (isExist is not null || id != Guid.Empty) throw new BusinessException(BaseMessages.AlreadyExist);
        }

        public async Task CheckIfApplicationStateIdNotExist(Guid id)
        {
            var isExist = await _applicantStateRepository.GetAsync(x => x.Id == id);
            if (isExist is null || id == Guid.Empty) throw new BusinessException(BaseMessages.NotExist);
        }
        public async Task CheckIfApplicationStateNameHave(string name)
        {
            var isExist = await _applicantStateRepository.GetAsync(x => x.Name == name);
            if (isExist is not null) throw new BusinessException(BaseMessages.SameName);
        }
    }
}
