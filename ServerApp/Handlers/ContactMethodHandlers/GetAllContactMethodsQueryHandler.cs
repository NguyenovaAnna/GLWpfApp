using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using ServerApp.Queries.ContactMethodQueries;
using Shared.Models;

namespace ServerApp.Handlers.ContactMethodHandlers
{
    public class GetAllContactMethodsQueryHandler : IRequestHandler<GetAllContactMethodsQuery, List<ContactMethodTypesDTO>>
    {
        private readonly IContactMethodRepository _contactMethodRepo;
        private readonly IMapper _mapper;

        public GetAllContactMethodsQueryHandler(IContactMethodRepository contactMethodRepo,IMapper mapper)
        {
            _contactMethodRepo = contactMethodRepo;
            _mapper = mapper;
        }

        public Task<List<ContactMethodTypesDTO>> Handle(GetAllContactMethodsQuery request, CancellationToken cancellationToken)
        {
            var contactMethods = _contactMethodRepo.GetAll();
            var contactMethodTypesDTO = _mapper.Map<List<ContactMethodTypesDTO>>(contactMethods);
            return Task.FromResult(contactMethodTypesDTO);
        }
    }
}
