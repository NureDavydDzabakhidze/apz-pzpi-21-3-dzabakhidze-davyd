using AutoMapper;
using Kolosok.Application.Contracts.Contacts;
using Kolosok.Application.Interfaces.Infrastructure;
using Kolosok.Domain.Exceptions.NotFound;
using MediatR;

namespace Kolosok.Application.Features.Auth.Queries;

public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, ContactResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserProfileQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ContactResponse> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        var contact = await _unitOfWork.ContactRepository.GetByFiltersAsync(null,
            e => e.Id == request.ContactId);

        if (contact is null)
        {
            throw new ContactNotFoundException(request.ContactId);
        }

        var contactResponse = _mapper.Map<ContactResponse>(contact);
        return contactResponse;
    }
}