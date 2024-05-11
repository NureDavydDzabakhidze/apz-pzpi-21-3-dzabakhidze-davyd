using Kolosok.Domain.Entities;

namespace Kolosok.Infrastructure.Specifications;

public class GetVictimFullInformationSpecification : BaseSpecification<Victim>
{
    public GetVictimFullInformationSpecification()
    {
        AddIncludes(p => p.Diagnoses);
        AddIncludes(p => p.Contact);
        AddIncludes(p => p.BrigadeRescuer);
    }
}