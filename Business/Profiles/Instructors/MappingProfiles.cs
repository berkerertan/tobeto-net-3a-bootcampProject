using AutoMapper;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Instructors
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();
            CreateMap<Instructor, DeleteInstructorRequest>().ReverseMap();
            CreateMap<Instructor, UpdateInstructorRequest>().ReverseMap();
            CreateMap<Instructor, GetInstructorRequest>().ReverseMap();
            CreateMap<Instructor, CreateInstructorResponse>().ReverseMap();
            CreateMap<Instructor, DeleteInstructorResponse>().ReverseMap();
            CreateMap<Instructor, UpdateInstructorResponse>().ReverseMap();
            CreateMap<Instructor, GetInstructorResponse>().ReverseMap();
        }
    }
}
