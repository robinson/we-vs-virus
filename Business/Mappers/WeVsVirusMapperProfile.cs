using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeVsVirus.Business.ViewModels;
using WeVsVirus.Models.Entities;

namespace WeVsVirus.Business.Mappers
{
    public class WeVsVirusMapperProfile : Profile
    {
        public WeVsVirusMapperProfile()
        {
            CreateMap<SignUpDriverViewModel, AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
        }
    }
}
