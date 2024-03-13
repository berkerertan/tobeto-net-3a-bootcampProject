using Core.Entities;
using System;
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
        public Applicant(string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email, 
            byte[] passwordHash,byte[] passwordSalt, string about)
        {

            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NationalIdentity = nationalIdentity;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            About = about;
        }

        public string About { get; set; }
        public ICollection<Application> Applications { get; set; }
        public Blacklist Blacklist { get; set; }
    }
}
