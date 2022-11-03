using AutoMapper;
using ClientApp.Models;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Profiles
{
    public class CMProfile : Profile
    {
        public CMProfile()
        {
            CreateMap<ContactMethodTypesDTO, ContactMethodTypesDisplayModel>().ReverseMap();
        }
    }
}
