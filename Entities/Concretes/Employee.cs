using Core.Entities;

namespace Entities.Concretes
{
    public class Employee : User
    {
        public Employee()
        {
            
        }

        public Employee(string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email,
            byte[] passwordHash,byte[] passwordSalt, string position)
        {

            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NationalIdentity = nationalIdentity;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            Position = position;
        }

        public string Position { get; set; }
    }
}
