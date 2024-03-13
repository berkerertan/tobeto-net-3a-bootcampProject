using AutoMapper;
using Business.Requests.Users;
using Business.Responses.Users;
using Core.Entities;

namespace Business.Profiles.Users;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, CreateUserRequest>().ReverseMap();
        CreateMap<User, DeleteUserRequest>().ReverseMap();
        CreateMap<User, UpdateUserRequest>().ReverseMap();
        CreateMap<User, GetUserRequest>().ReverseMap();
        CreateMap<User, CreateUserResponse>().ReverseMap();
        CreateMap<User, DeleteUserResponse>().ReverseMap();
        CreateMap<User, UpdateUserResponse>().ReverseMap();
        CreateMap<User, GetUserResponse>().ReverseMap();

    }
}
