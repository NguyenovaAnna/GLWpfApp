using AutoMapper;
using ClientApp.Models;
using DataAccess.Entities;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Profiles
{
    public class EmpProfile : Profile
    {
        public EmpProfile()
        {
            CreateMap<EmployeeDTO, EmployeeDisplayModel>().ReverseMap();
            CreateMap<ContactMethodDTO, ContactMethodDisplayModel>().ReverseMap();
        }
    }
}
