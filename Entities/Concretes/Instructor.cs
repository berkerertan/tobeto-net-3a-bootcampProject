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

        public Instructor( string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email, string password, string companyName)
        {

            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NationalIdentity = nationalIdentity;
            Email = email;
            Password = password;
            CompanyName = companyName;
        }

        public string CompanyName { get; set; }
    }
}
