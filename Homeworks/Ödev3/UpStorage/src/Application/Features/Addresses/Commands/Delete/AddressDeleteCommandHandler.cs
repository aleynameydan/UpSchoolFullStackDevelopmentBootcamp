using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Addresses.Commands.Delete;

public class AddressDeleteCommandHandler : IRequestHandler<AddressDeleteCommand,Response<int>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public AddressDeleteCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Response<int>> Handle(AddressDeleteCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _applicationDbContext.Addresses
            .Where(x => x.Id == Guid.Parse(request.Id))
            .SingleOrDefaultAsync(cancellationToken);

        if (deleted == null)
        {
            throw new Exception();
        }

        deleted.IsDeleted = true;

        _applicationDbContext.Addresses.Update(deleted);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return new();
    }
}