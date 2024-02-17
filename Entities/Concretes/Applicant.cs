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
        public Applicant(int id, int userId, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email, string password, string about)
        {
            Id = id;
            UserId = userId;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NationalIdentity = nationalIdentity;
            Email = email;
            Password = password;
            About = about;
        }

        public string About { get; set; }
    }
}
