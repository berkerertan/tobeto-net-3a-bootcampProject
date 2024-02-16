using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Instructor : User
    {
        public Instructor()
        {
            
        }

        public Instructor(int id,string companyName)
        {
            Id = id;
            CompanyName = companyName;
        }

        public string CompanyName { get; set; }
    }
}
