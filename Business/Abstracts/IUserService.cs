using Business.Requests.Users;
using Business.Responses.Users;
using Core.Entities;
using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserService
    {
        public Task<IDataResult<CreateUserResponse>> AddAsync(CreateUserRequest request);
        public Task<IDataResult<UpdateUserResponse>> UpdateAsync(UpdateUserRequest request);
        public Task<IResult> DeleteAsync(DeleteUserRequest request);
        public Task<IDataResult<List<GetUserResponse>>> GetAllAsync();
        public Task<IDataResult<GetUserResponse>> GetByIdAsync(Guid id);
        public Task<DataResult<User>> GetById(Guid id);
        public Task<DataResult<User>> GetByMail(string email);
    }
}
