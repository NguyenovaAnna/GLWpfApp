using DataAccess.Entities;
using MediatR;
using Shared.Models;

namespace ServerApp.Queries.ContactMethodQueries
{
    public record GetAllContactMethodsQuery() : IRequest<List<ContactMethodTypesDTO>>;
}
