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
    public class ApplicantBusinessRules : BaseBusinessRules
    {
        private readonly IApplicantRepository _applicantRepository;

        public ApplicantBusinessRules(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        public async Task CheckIfApplicantUserNameNotExist(string userName)
        {
            var isExist = await _applicantRepository.GetAsync(user => user.UserName == userName);
            if (isExist is not null) throw new BusinessException(BaseMessages.SameName);
        }

        public async Task CheckIfApplicantIdAlreadyExist(Guid id)
        {
            var isExist = await _applicantRepository.GetAsync(user => user.Id == id);
            if (isExist is not null || id != Guid.Empty) throw new BusinessException(BaseMessages.AlreadyExist);
        }

        public async Task CheckIfApplicantIdNotExist(Guid id)
        {
            var isExist = await _applicantRepository.GetAsync(user => user.Id == id);
            if (isExist is null || id == Guid.Empty) throw new BusinessException(BaseMessages.NotExist);
        }

    }
}
