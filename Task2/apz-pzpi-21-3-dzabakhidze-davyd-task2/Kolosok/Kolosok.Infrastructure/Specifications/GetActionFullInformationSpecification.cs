using Action = Kolosok.Domain.Entities.Action;

namespace Kolosok.Infrastructure.Specifications;

public class GetActionFullInformationSpecification : BaseSpecification<Action>
{
    public GetActionFullInformationSpecification()
    {
        AddIncludes(p => p.BrigadeRescuer);
        AddIncludes(p => p.Victim);
    }
}