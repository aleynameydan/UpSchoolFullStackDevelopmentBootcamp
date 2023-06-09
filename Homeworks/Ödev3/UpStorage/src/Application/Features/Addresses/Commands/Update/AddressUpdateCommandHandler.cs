using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Addresses.Commands.Update;

public class AddressUpdateCommandHandler : IRequestHandler<AddressUpdateCommand,Response<int>>
{
    public readonly IApplicationDbContext _applicationDbContext;

    public AddressUpdateCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Response<int>> Handle(AddressUpdateCommand request, CancellationToken cancellationToken)
    {
        var updated = await _applicationDbContext.Addresses
            .Where(x => x.Id == Guid.Parse(request.Id))
            .SingleOrDefaultAsync(cancellationToken);

        if (updated == null)
        {
            throw new Exception();
        }

        updated.Name = request.Name;
        updated.UserId = request.UserId;
        updated.CountryId = request.CountryId;
        updated.CityId = request.CityId;
        updated.District = request.District;
        updated.PostCode = request.PostCode;
        updated.AddressLine1 = request.AddressLine1;
        updated.AddressLine2 = request.AddressLine2;

        _applicationDbContext.Addresses.Update(updated);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return new();
    }
}