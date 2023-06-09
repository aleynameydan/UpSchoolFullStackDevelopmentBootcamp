using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Addresses.Commands.HardDelete;

public class AddressHardDeleteCommandHandler : IRequestHandler<AddressHardDeleteCommand, Response<int>>
{
    public readonly IApplicationDbContext _applicationDbContext;

    public AddressHardDeleteCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Response<int>> Handle(AddressHardDeleteCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _applicationDbContext.Addresses
            .Where(x => x.Id == Guid.Parse(request.Id))
            .SingleOrDefaultAsync(cancellationToken);

        if (deleted == null)
        {
            throw new Exception();
        }

        _applicationDbContext.Addresses.Remove(deleted);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return new();
    }
}