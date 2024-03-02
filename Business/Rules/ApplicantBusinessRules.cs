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
            if (isExist is not null) throw new BusinessException("Username name already exist");
        }

        public async Task CheckIfApplicantIdNotExist(Guid id)
        {
            var isExist = await _applicantRepository.GetAsync(user => user.Id == id);
            if (isExist is null || isExist.Id == Guid.Empty) throw new BusinessException("Id not null");
        }
    }
}
