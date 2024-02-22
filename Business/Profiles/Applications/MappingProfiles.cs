using AutoMapper;
using Business.Requests.Aplicants;
using Business.Requests.Applications;
using Business.Response.Applications;
using Business.Responses.Applicants;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Applications
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Application, CreateApplicationRequest>().ReverseMap();
            CreateMap<Application, DeleteApplicationRequest>().ReverseMap();
            CreateMap<Application, UpdateApplicationRequest>().ReverseMap();
            CreateMap<Application, GetApplicationRequest>().ReverseMap();
            CreateMap<Application, CreateApplicationResponse>().ReverseMap();
            CreateMap<Application, DeleteApplicationResponse>().ReverseMap();
            CreateMap<Application, UpdateApplicationResponse>().ReverseMap();
            CreateMap<Application, GetApplicationResponse>().ReverseMap();
        }
    }
}
