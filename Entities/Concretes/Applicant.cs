﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Applicant : User
    {
        public Applicant()
        {
            
        }

        public Applicant(int id,string about)
        {
            Id = id;
            About = about;
        }

        public string About { get; set; }
    }
}
