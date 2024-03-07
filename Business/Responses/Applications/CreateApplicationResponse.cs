using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Response.Applications
{
    public class CreateApplicationResponse
    {
        public Guid Id { get; set; }
        public string BootcampName { get; set; }
        public string AplicantUserName { get; set; }
        public string AplicantFirstName { get; set; }
        public string AplicantLastName { get; set; }
        public Guid ApplicantId { get; set; }
        public Guid BootcampId { get; set; }
        public Guid ApplicationStateId { get; set; }

    }
}
