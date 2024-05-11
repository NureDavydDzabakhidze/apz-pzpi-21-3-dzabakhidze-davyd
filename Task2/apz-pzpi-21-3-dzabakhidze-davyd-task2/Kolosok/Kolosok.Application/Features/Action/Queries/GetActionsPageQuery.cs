using Kolosok.Application.Contracts.Action;
using Kolosok.Application.Contracts.Brigade;
using Kolosok.Application.Interfaces.Infrastructure;
using MediatR;

namespace Kolosok.Application.Features.Action.Queries;

public class GetActionsPageQuery : IRequest<IEnumerable<ActionResponse>>
{
    public ISpecification<Domain.Entities.Action>[] Specifications { get; private set; }

    public SearchFilter Filters { get; set; }

    public GetActionsPageQuery(SearchFilter filter)
    {
        Filters = filter;
    }

    public void AddSpecification(params ISpecification<Domain.Entities.Action>[] specifications)
    {
        Specifications = specifications;
    }
}