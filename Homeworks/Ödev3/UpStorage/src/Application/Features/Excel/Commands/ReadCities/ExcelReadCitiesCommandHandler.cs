using Application.Common.Interfaces;
using Application.Common.Models.Excel;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Excel.Commands.ReadCities;

public class ReadCitiesCommandHandler : IRequestHandler<ExcelReadCitiesCommand,Response<int>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IExcelService _excelService;


    public ReadCitiesCommandHandler(IApplicationDbContext applicationDbContext, IExcelService excelService)
    {
        _applicationDbContext = applicationDbContext;
        _excelService = excelService;
    }

    public async Task<Response<int>> Handle(ExcelReadCitiesCommand request, CancellationToken cancellationToken)
    {
        var cityDtos = _excelService.ReadCities(MapCommandToExcelBase64Dto(request));

        var cities = cityDtos.Select(x => x.MapToCity()).ToList();

        await _applicationDbContext.Cities.AddRangeAsync(cities, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        //iki kere count ile döndüğümüz için cities kısmını list diye tutuyoruz.
        return new Response<int>($"{cities.Count} were added to the db successfully.",cities.Count);
    }

    private ExcelBase64Dto MapCommandToExcelBase64Dto(ExcelReadCitiesCommand command)
    {
        return new ExcelBase64Dto()
        {
            File = command.ExcelBase64File
        };
    }
}