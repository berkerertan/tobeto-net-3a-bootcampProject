using Core.CrossCuttingConcerns.Rules;
using DataAccess.Abstracts;
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

    }
}
