using Business.Abstracts;
using Business.Constants;
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
        private readonly IBlacklistService _blacklistService;

        public ApplicationBusinessRules(IApplicationRepository applicationRepository,IBlacklistService blacklistService)
        {
            _applicationRepository = applicationRepository;
            _blacklistService = blacklistService;
        }

        public async Task CheckIfApplicationIdAlreadyExist(Guid id)
        {
            var isExist = await _applicationRepository.GetAsync(user => user.Id == id);
            if (isExist is not null) throw new BusinessException(BaseMessages.AlreadyExist);
        }
        public async Task CheckIfApplicationIdNotExist(Guid id)
        {
            var isExist = await _applicationRepository.GetAsync(user => user.Id == id);
            if (isExist is null) throw new BusinessException(BaseMessages.NotExist);
        }
        public async Task CheckIfApplicantIsBlacklisted(Guid id)
        {
            var item = await _blacklistService.CheckIfApplicantIsBlacklisted(id);
            if (item.Data is not null)
            {
                throw new BusinessException(BaseMessages.Blacklisted);
            }
        }
    }
}
