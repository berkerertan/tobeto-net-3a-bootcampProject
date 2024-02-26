using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Users
{
    public class CreateUserResponse
    {
        // Şifre gibi hassas bilgiler genellikle yanıtta döndürülmez.
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalIdentity { get; set; }
        public string Email { get; set; }
    }
}
