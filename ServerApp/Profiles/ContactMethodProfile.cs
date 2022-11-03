using AutoMapper;
using DataAccess.Entities;
using Shared.Models;

namespace ServerApp.Profiles
{
    public class ContactMethodProfile : Profile
    {
        public ContactMethodProfile()
        {
            CreateMap<ContactMethod, ContactMethodTypesDTO>().ReverseMap();
        }
    }
}
