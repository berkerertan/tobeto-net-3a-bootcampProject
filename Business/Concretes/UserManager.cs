using Business.Abstracts;
using Business.Requests.Users;
using Business.Responses.Users;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<CreateUserResponse> AddAsync(CreateUserRequest request)
        {
            User user = new User();
            user.UserName = request.UserName;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.NationalIdentity = request.NationalIdentity;
            user.Password = request.Password;
            await _userRepository.Add(user);

            CreateUserResponse response = new CreateUserResponse();
            response.UserName = user.UserName;
            response.FirstName = user.FirstName;
            response.LastName = user.LastName;
            response.Email = user.Email;
            response.NationalIdentity = user.NationalIdentity;
            return response;

        }

        public async Task DeleteAsync(int id)
        {
            var user = await _userRepository.Get(u=>u.UserId == id);
            if (user != null)
            {
                await _userRepository.Delete(user);
            }
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetByIdAsync(int id)
        {
           return await _userRepository.Get(u=> u.UserId == id);
        }

        public async Task<UpdateUserResponse> UpdateAsync(User user)
        {
            var UpdatedUser = await _userRepository.Update(user);
            return new UpdateUserResponse
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                NationalIdentity = user.NationalIdentity,
                Password = user.Password,
            };
        }
    }
}
