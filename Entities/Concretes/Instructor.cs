using Core.Entities;

namespace Entities.Concretes
{
    public class Instructor : User
    {
        public Instructor()
        {
            
        }

        public Instructor( string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email,
            byte[] passwordHash, byte[] passwordSalt, string companyName)
        {

            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NationalIdentity = nationalIdentity;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            CompanyName = companyName;
        }

        public string CompanyName { get; set; }
        public ICollection<Bootcamp> Bootcamps { get; set; }
    }
}
