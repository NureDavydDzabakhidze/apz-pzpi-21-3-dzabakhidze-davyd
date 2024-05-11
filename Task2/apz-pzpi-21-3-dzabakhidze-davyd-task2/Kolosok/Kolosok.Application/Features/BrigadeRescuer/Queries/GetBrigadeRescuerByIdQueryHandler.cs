using AutoMapper;
using Kolosok.Application.Contracts.BrigadeRescuer;
using Kolosok.Application.Interfaces.Infrastructure;
using Kolosok.Domain.Exceptions;
using Kolosok.Domain.Exceptions.NotFound;
using MediatR;

namespace Kolosok.Application.Features.BrigadeRescuer.Queries;

public class GetBrigadeRescuerByIdQueryHandler : IRequestHandler<GetBrigadeRescuerByIdQuery, BrigadeRescuerResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBrigadeRescuerByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BrigadeRescuerResponse> Handle(GetBrigadeRescuerByIdQuery request, CancellationToken cancellationToken)
    {
        var brigadeRescuer = await _unitOfWork.BrigadeRescuerRepository.GetByFiltersAsync(request.Specifications, p => p.Id == request.Id);
        
        if (brigadeRescuer is null)
        {
            throw new BrigadeNotFoundException(request.Id);
        }
        
        var response = _mapper.Map<BrigadeRescuerResponse>(brigadeRescuer);
        return response;
    }
}