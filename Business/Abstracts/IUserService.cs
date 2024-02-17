using Business.Requests.Users;
using Business.Responses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Abstracts;

public interface IUserService
{
    Task<CreateUserResponse> AddAsync(CreateUserRequest request);
}