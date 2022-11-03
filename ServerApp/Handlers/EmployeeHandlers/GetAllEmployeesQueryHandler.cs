using AutoMapper;
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using ServerApp.Queries.EmployeeQueries;
using ServerApp.Services;
using Shared.Models;

namespace ServerApp.Handlers.EmployeeHandlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDTO>>
    {

        private readonly IEmployeeRepository _employeerepo;
        private readonly IMapper _mapper;
        public GetAllEmployeesQueryHandler(IEmployeeRepository employeerepo, IMapper mapper)
        {
            _employeerepo = employeerepo;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDTO>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = _employeerepo.GetAll();
            var employeesDtos = _mapper.Map<List<EmployeeDTO>>(employees);
            return employeesDtos;
        }
    }
}
