using Application.Features.City.Commands.Add;
using Application.Features.City.Queries.GetAll;
using Application.Features.Excel.Commands.ReadCities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers;

public class CitiesController : ApiControllerBase
{

    [ValidationFilter]
    [HttpPost]
    public async Task<IActionResult> AddAsync(CityAddCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPost("GetAll")]
    public async Task<IActionResult> GetAllAsync(CityGetAllQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await Mediator.Send(new CityGetAllQuery(id, null)));
    }

}