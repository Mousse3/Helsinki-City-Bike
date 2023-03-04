using AutoMapper;
using HBike.Models;
using HBike.DTOs;

namespace HBike.Profiles
{
    public class JourneyProfile : Profile
    {
        public JourneyProfile()
        {
            CreateMap<JourneyDTO, Journey>();
            CreateMap<Journey, JourneyDTO>();
            // CreateMap<JourneyNoStationsDTO, Journey>();
            // .ForMember(dest => dest.DepartureStation, opt => opt.Ignore())
            // .ForMember(dest => dest.ReturnStation, opt => opt.Ignore());
            // CreateMap<Journey, JourneyNoStationsDTO>();
        }
    }
}