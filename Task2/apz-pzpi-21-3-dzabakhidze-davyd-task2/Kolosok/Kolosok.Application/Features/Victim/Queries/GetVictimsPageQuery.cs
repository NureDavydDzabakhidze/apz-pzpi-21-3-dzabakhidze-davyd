using Kolosok.Application.Contracts.Victim;
using Kolosok.Application.Interfaces.Infrastructure;
using MediatR;

namespace Kolosok.Application.Features.Victim.Queries;

public class GetVictimsPageQuery: IRequest<IEnumerable<VictimResponse>>
{
    public ISpecification<Domain.Entities.Victim>[] Specifications { get; private set; }

    public SearchFilter Filters { get; set; }

    public GetVictimsPageQuery(SearchFilter filter)
    {
        Filters = filter;
    }

    public void AddSpecification(params ISpecification<Domain.Entities.Victim>[] specifications)
    {
        Specifications = specifications;
    }
}