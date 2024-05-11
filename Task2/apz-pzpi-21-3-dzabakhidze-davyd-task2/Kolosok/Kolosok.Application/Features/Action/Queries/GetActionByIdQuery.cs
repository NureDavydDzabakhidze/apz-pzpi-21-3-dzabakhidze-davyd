using Kolosok.Application.Contracts.Action;
using Kolosok.Application.Contracts.Brigade;
using Kolosok.Application.Interfaces.Infrastructure;
using MediatR;

namespace Kolosok.Application.Features.Action.Queries;

public class GetActionByIdQuery : IRequest<ActionResponse>
{
    public Guid Id { get; set; }
    
    public GetActionByIdQuery(Guid id)
    {
        Id = id;
    }
    
    public void AddSpecification(params ISpecification<Domain.Entities.Action>[] specifications)
    {
        Specifications = specifications;
    }
    public ISpecification<Domain.Entities.Action>[] Specifications { get; private set; }

}