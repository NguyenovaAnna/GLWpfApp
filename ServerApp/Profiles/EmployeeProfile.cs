using AutoMapper;
using AutoMapper.EquivalencyExpression;
using DataAccess.Entities;
using Shared.Models;
using System.Runtime.CompilerServices;

namespace ServerApp.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dto => dto.ContactMethods, opt => opt.MapFrom(x => x.EmployeeContactMethods)) //(x => x.EmployeeContactMethods.Select(y => y.ContactMethod)))
                //.ForMember(dto => dto.ContactMethods, opt => opt.MapFrom(x => x.ContactMethods.Select(y => y.ContactMethod)))
                .ReverseMap();
            
            CreateMap<EmployeeContactMethod, ContactMethodDTO>()
                .IncludeMembers(src => src.ContactMethod)
                .ForMember(dto => dto.ContactMethodId, opt => opt.MapFrom(src => src.ContactMethod.ContactMethodId))
                //.ForMember(dto => dto.ContactMethodValue, opt => opt.MapFrom(x => x.ContactMethodValue))
                //.ForMember(dto => dto.IsSelected, opt => opt.MapFrom(x => x.IsSelected))
                .ReverseMap();

            CreateMap<ContactMethod, ContactMethodDTO>()
                .ForMember(dto => dto.ContactMethodValue, opt => opt.Ignore())
                .ReverseMap();



            //CreateMap<EmployeeContactMethod, ContactMethodDTO>()
            //    .ForMember(dto => dto.ContactMethodId, opt => opt.MapFrom(x => x.ContactMethodId))
            //    .ForMember(dto => dto.ContactMethodValue, opt => opt.MapFrom(x => x.ContactMethodValue))
            //    .ForMember(dto => dto.IsSelected, opt => opt.MapFrom(x => x.IsSelected))
            //    .ReverseMap();


        }
    }
}
