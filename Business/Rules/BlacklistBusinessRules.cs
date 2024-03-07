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
    public class BlacklistBusinessRules : BaseBusinessRules
    {
        private readonly IBlacklistRepository _blacklistRepository;

        public BlacklistBusinessRules(IBlacklistRepository blacklistRepository)
        {
            _blacklistRepository = blacklistRepository;
        }

        public async Task CheckIfBlacklistIdAlreadyExist(Guid id)
        {
            var isExist = await _blacklistRepository.GetAsync(user => user.Id == id);
            if (isExist is not null || id != Guid.Empty) throw new BusinessException(BaseMessages.AlreadyExist);
        }

        public async Task CheckIfBlacklistIdNotExist(Guid id)
        {
            var isExist = await _blacklistRepository.GetAsync(user => user.Id == id);
            if (isExist is null || id == Guid.Empty) throw new BusinessException(BaseMessages.NotExist);
        }
    }
}
