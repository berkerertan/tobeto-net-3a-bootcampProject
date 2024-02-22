using AutoMapper;
using Business.Requests.Users;
using Business.Responses.Users;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Employees
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, CreateEmployeeRequest>().ReverseMap();
            CreateMap<Employee, DeleteEmployeeRequest>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeRequest>().ReverseMap();
            CreateMap<Employee, GetEmployeeRequest>().ReverseMap();
            CreateMap<Employee, CreateEmployeeResponse>().ReverseMap();
            CreateMap<Employee, DeleteEmployeeResponse>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeResponse>().ReverseMap();
            CreateMap<Employee, GetEmployeeResponse>().ReverseMap();
  
        }
    }
}
