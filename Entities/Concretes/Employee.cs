using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Employee : User
    {
        public Employee()
        {
            
        }

        public Employee(int id, int userId, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email, string password, string position)
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
            Position = position;
        }

        public string Position { get; set; }
    }
}
