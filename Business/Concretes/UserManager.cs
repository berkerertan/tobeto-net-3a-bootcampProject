using AutoMapper;
using Business.Abstracts;
using Business.Requests.Users;
using Business.Responses.Users;
using Core.Entities;
using Core.Utilities.Results;
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
        private readonly IMapper _mapper;

        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateUserResponse>> AddAsync(CreateUserRequest request)
        {
            User user = _mapper.Map<User>(request);
            await _userRepository.AddAsync(user);
            CreateUserResponse response = _mapper.Map<CreateUserResponse>(user);

            return new SuccessDataResult<CreateUserResponse>(response, "Added Succesfuly");
        }

        public async Task<IResult> DeleteAsync(DeleteUserRequest request)
        {
            var item = await _userRepository.GetAsync(p => p.Id == request.Id);
            if (item != null)
            {
                await _userRepository.DeleteAsync(item);
                return new SuccessResult("Deleted Succesfuly");
            }
            return new ErrorResult("Delete Failed!");
        }

        public async Task<IDataResult<List<GetUserResponse>>> GetAllAsync()
        {

            var list = await _userRepository.GetAllAsync();
            List<GetUserResponse> responselist = _mapper.Map<List<GetUserResponse>>(list);

            return new SuccessDataResult<List<GetUserResponse>>(responselist, "Listed Succesfuly.");
        }

        public async Task<DataResult<User>> GetById(Guid id)
        {
            return new SuccessDataResult<User>(await _userRepository.GetAsync(x => x.Id == id));
        }

        public async Task<IDataResult<GetUserResponse>> GetByIdAsync(Guid id)
        {
            var item = await _userRepository.GetAsync(p => p.Id == id);
            if (item != null)
            {
                GetUserResponse response = _mapper.Map<GetUserResponse>(item);
                return new SuccessDataResult<GetUserResponse>(response, "found Succesfuly.");
            }
            return new ErrorDataResult<GetUserResponse>("User could not be found.");
        }

        public async Task<DataResult<User>> GetByMail(string email)
        {
            return new SuccessDataResult<User>(await _userRepository.GetAsync(x => x.Email == email));
        }

        public async Task<IDataResult<UpdateUserResponse>> UpdateAsync(UpdateUserRequest request)
        {
            var item = await _userRepository.GetAsync(p => p.Id == request.Id);

            if (item != null)
            {
                _mapper.Map(request, item);
                await _userRepository.UpdateAsync(item);
                UpdateUserResponse response = _mapper.Map<UpdateUserResponse>(item);

                return new SuccessDataResult<UpdateUserResponse>(response, "User succesfully updated!");
            }

            return new ErrorDataResult<UpdateUserResponse>("User could not be found.");
        }
    }
}
