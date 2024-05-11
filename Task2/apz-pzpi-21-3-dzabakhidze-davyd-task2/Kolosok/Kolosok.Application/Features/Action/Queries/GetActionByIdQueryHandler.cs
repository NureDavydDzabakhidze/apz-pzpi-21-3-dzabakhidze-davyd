using AutoMapper;
using Kolosok.Application.Contracts.Action;
using Kolosok.Application.Contracts.Brigade;
using Kolosok.Application.Features.Brigade.Queries;
using Kolosok.Application.Interfaces.Infrastructure;
using Kolosok.Domain.Exceptions;
using Kolosok.Domain.Exceptions.NotFound;
using MediatR;

namespace Kolosok.Application.Features.Action.Queries;

public class GetActionByIdQueryHandler : IRequestHandler<GetActionByIdQuery, ActionResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetActionByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ActionResponse> Handle(GetActionByIdQuery request, CancellationToken cancellationToken)
    {
        var action = await _unitOfWork.ActionRepository.GetByFiltersAsync(request.Specifications, p => p.Id == request.Id);
        
        if (action is null)
        {
            throw new ActionNotFoundException(request.Id);
        }
        
        var response = _mapper.Map<ActionResponse>(action);
        return response;
    }
}