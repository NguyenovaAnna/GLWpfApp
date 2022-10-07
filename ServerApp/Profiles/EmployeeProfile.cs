using AutoMapper;
using DataAccess.Entities;
using Shared.Models;

namespace ServerApp.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
