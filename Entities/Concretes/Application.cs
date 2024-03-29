﻿using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Application : BaseEntity<Guid>
    {
        public Application()
        {
            
        }

        public Application(Guid applicantId, Guid bootcampId, Guid applicationStateId, Applicant applicant, Bootcamp bootcamp, ApplicationState applicationState)
        {
            ApplicantId = applicantId;
            BootcampId = bootcampId;
            ApplicationStateId = applicationStateId;
            Applicant = applicant;
            Bootcamp = bootcamp;
            ApplicationState = applicationState;
        }

        public Guid ApplicantId { get; set; }
        public Guid BootcampId { get; set; }
        public Guid ApplicationStateId { get; set; }
        public virtual Applicant Applicant { get; set; }
        public virtual Bootcamp Bootcamp { get; set; }
        public virtual ApplicationState ApplicationState { get; set; }
    }
}
