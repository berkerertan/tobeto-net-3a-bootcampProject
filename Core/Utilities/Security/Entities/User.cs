using Core.Entities;
using Core.Utilities.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class User : BaseEntity<Guid>
{
    public User()
    {
        //UserImages = new HashSet<UserImage>();
        UserOperationClaims = new HashSet<UserOperationClaim>();
    }

    public User(Guid id, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email, byte[] passwordSalt, byte[] passwordHash)
    {
        Id = id;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = email;
        //Password = password;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
    }
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string Email { get; set; }
    //public string Password { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    //public virtual ICollection<UserImage> UserImages { get; set; }
}
