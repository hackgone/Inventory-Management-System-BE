using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dto;
using ApiCore.Entity;
using AutoMapper;

namespace AllServices.AutoMapper
{
    //make it a automapper profile by inherirting ir from profile class that have createmap methods
    public class AutoMappingProfile:Profile
    {
        public AutoMappingProfile() {
            CreateMap<Login, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

        }
    }
}
