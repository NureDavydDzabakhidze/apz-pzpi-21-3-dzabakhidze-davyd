using Kolosok.Application.Contracts.Contacts;

namespace Kolosok.Application.Contracts.BrigadeRescuer;

public class BrigadeRescuerResponse : BaseResponse
{
    public ContactResponse Contact { get; set; }
    public string Position { get; set; }
    public string Specialization { get; set; }
    public Guid BrigadeId { get; set; }
}