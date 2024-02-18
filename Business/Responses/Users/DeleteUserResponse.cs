using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Users
{
    public class DeleteUserResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        // Silme işleminin başarılı olup olmadığını ve hata mesajını taşıyan özellikler
    }
}
