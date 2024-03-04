using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Blacklist : BaseEntity<Guid>
    {
        public Blacklist()
        {
            
        }

        public Blacklist(string reason, DateTime date, Guid applicantId)
        {
            Reason = reason;
            Date = date;
            ApplicantId = applicantId;
        }

        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public Guid ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}
