using Kolosok.Domain.Entities;

namespace Kolosok.Infrastructure.Specifications;

public class GetBrigadeRescuerFullInformationSpecification : BaseSpecification<BrigadeRescuer>
{
    public GetBrigadeRescuerFullInformationSpecification()
    {
        AddIncludes(p => p.Brigade);
        AddIncludes(p => p.Contact);
    }
}