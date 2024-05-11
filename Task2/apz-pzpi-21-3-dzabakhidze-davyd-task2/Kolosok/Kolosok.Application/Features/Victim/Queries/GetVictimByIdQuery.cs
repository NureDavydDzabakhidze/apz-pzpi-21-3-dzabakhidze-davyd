using Kolosok.Application.Contracts.Victim;
using Kolosok.Application.Interfaces.Infrastructure;
using MediatR;

namespace Kolosok.Application.Features.Victim.Queries;

public class GetVictimByIdQuery : IRequest<VictimResponse>
{
    public Guid Id { get; set; }
    
    public GetVictimByIdQuery(Guid id)
    {
        Id = id;
    }
    
    public void AddSpecification(params ISpecification<Domain.Entities.Victim>[] specifications)
    {
        Specifications = specifications;
    }
    public ISpecification<Domain.Entities.Victim>[] Specifications { get; private set; }
}