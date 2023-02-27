using AutoMapper;
using DataLayer.Entities;
using ServiceLayer.Dtos;

namespace ServiceLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();

            CreateMap<Employee, EmloyeeDtoforIndex>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.FIO, opt => opt.MapFrom(src => src.Name + " " + src.Surname + " " + src.Lastname))
                .ForMember(dst => dst.Age, opt => opt.MapFrom(src => DateTime.Now.Year - src.Birthday.Year))
                .ForMember(dst => dst.Position, opt => opt.MapFrom(src => src.Position));


            CreateMap<ChildDto, Child>();
            CreateMap<Child, ChildDto>();

            CreateMap<Child, ChildDtoForIndex>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.FIO, opt => opt.MapFrom(src => src.Name + " " + src.Surname + " " + src.Lastname))
                .ForMember(dst => dst.Age, opt => opt.MapFrom(src => DateTime.Now.Year - src.Birthday.Year));
        }
    }
}
