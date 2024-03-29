﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ApplicantRepository : EfRepositoryBase<Applicant, Guid, BaseDbContext>, IApplicantRepository
    {
        public ApplicantRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
