using Kolosok.Application.Contracts.BrigadeRescuer;
using Kolosok.Application.Interfaces.Infrastructure;
using MediatR;

namespace Kolosok.Application.Features.BrigadeRescuer.Queries;

public class GetBrigadeRescuerByIdQuery : IRequest<BrigadeRescuerResponse>
{
    public Guid Id { get; set; }
    
    public GetBrigadeRescuerByIdQuery(Guid id)
    {
        Id = id;
    }
    
    public void AddSpecification(params ISpecification<Domain.Entities.BrigadeRescuer>[] specifications)
    {
        Specifications = specifications;
    }
    public ISpecification<Domain.Entities.BrigadeRescuer>[] Specifications { get; private set; }

}