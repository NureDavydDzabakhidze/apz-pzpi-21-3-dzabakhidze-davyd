using Kolosok.Application.Contracts.BrigadeRescuer;
using Kolosok.Application.Contracts.Contacts;

namespace Kolosok.Application.Contracts.Victim;

public class VictimResponse : BaseResponse
{
    public ContactResponse Contact { get; set; }
    public BrigadeRescuerResponse BrigadeRescuer { get; set; }
        
    // public ICollection<DiagnosisResponse> Diagnoses { get; set; }
}