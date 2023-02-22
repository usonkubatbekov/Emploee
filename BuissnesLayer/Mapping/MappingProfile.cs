using AutoMapper;
using DataLayer.Entityes;
using PresentationLayer.Models;
using ServiceLayer.Dto;

namespace ServiceLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SotrudnikDto, SotrudnikEntity>();
            CreateMap<SotrudnikEntity, SotrudnikDto>();

            CreateMap<SotrudnikEntity, SotrudnikDtoforIndex>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.FIO, opt => opt.MapFrom(src => src.Name + " " + src.SurName + " " + src.LastName))
                .ForMember(dst => dst.Age, opt => opt.MapFrom(src => DateTime.Now.Year - src.BirthDay.Year))
                .ForMember(dst => dst.Position, opt => opt.MapFrom(src => src.Position));


            CreateMap<ChildDto, ChildEntity>();
            CreateMap<ChildEntity, ChildDto>();

            CreateMap<ChildEntity, ChildDtoForIndex>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.FIO, opt => opt.MapFrom(src => src.Name + " " + src.SurName + " " + src.LastName))
                .ForMember(dst => dst.Age, opt => opt.MapFrom(src => DateTime.Now.Year - src.BirthDay.Year));
        }
    }
}
