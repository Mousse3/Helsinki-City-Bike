using AutoMapper;
using HBike.Models;
using HBike.DTOs;

namespace HBike.Profiles
{
    public class StationProfile : Profile
    {
        public StationProfile()
        {
            CreateMap<StationDTO, Station>();
            CreateMap<Station, StationDTO>();
            // CreateMap<StationNoJourneysDTO, Station>();
            // .ForMember(dest => dest.Departures, opt => opt.Ignore())
            // .ForMember(dest => dest.Returns, opt => opt.Ignore());
            // CreateMap<Station, StationNoJourneysDTO>();
        }
    }
}