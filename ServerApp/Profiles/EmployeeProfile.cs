﻿using AutoMapper;
using AutoMapper.EquivalencyExpression;
using DataAccess.Entities;
using Shared.Models;

namespace ServerApp.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<ContactMethod, ContactMethodDTO>().ReverseMap();
        }
    }
}
