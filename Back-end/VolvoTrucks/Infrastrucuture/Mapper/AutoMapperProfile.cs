using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastrucuture.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(){

            CreateMap<Truck, Truck>()
                .ForMember(dest => dest.Model, upt => upt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Fabricateyear, upt => upt.MapFrom(src => src.Fabricateyear))
                .ForMember(dest => dest.Chassi_Code, upt => upt.MapFrom(src => src.Chassi_Code))
                .ForMember(dest => dest.Color, upt => upt.MapFrom(src => src.Color))
                .ForMember(dest => dest.Plan, upt => upt.MapFrom(src => src.Plan));
        }
    }
}
