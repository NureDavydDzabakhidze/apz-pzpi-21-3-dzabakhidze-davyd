using Kolosok.Application.Contracts.Contacts;
using MediatR;

namespace Kolosok.Application.Features.Auth.Queries;

public class GetUserProfileQuery : IRequest<ContactResponse>
{
    public GetUserProfileQuery(Guid contactId)
    {
        ContactId = contactId;
    }

    public Guid ContactId { get; set; }
}