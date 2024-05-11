using AutoMapper;
using Kolosok.Application.Contracts.Victim;
using Kolosok.Application.Interfaces.Infrastructure;
using Kolosok.Domain.Exceptions.NotFound;
using MediatR;

namespace Kolosok.Application.Features.Victim.Queries;

public class GetVictimByIdQueryHandler : IRequestHandler<GetVictimByIdQuery, VictimResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetVictimByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<VictimResponse> Handle(GetVictimByIdQuery request,
        CancellationToken cancellationToken)
    {
        var victim =
            await _unitOfWork.VictimRepository.GetByFiltersAsync(request.Specifications,
                p => p.Id == request.Id);

        if (victim is null)
        {
            throw new ContactNotFoundException(request.Id);
        }

        var response = _mapper.Map<VictimResponse>(victim);
        return response;
    }
}