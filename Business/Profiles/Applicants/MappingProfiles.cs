using AutoMapper;
using Business.Requests.Aplicants;
using Business.Responses.Applicants;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Applicants
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Applicant,CreateApplicantRequest>().ReverseMap();
            CreateMap<Applicant,DeleteApplicantRequest>().ReverseMap();
            CreateMap<Applicant,UpdateApplicantRequest>().ReverseMap();
            CreateMap<Applicant,GetApplicantRequest>().ReverseMap();
            CreateMap<Applicant,CreateApplicantResponse>().ReverseMap();
            CreateMap<Applicant,DeleteApplicantResponse>().ReverseMap();
            CreateMap<Applicant,UpdateApplicantResponse>().ReverseMap();
            CreateMap<Applicant,GetApplicantResponse>().ReverseMap();
        }
    }
}
