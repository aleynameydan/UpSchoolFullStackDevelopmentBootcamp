using MediatR;

namespace Application.Features.City.Queries.GetAll;

public class CityGetAllQuery:IRequest<List<CityGetAllDto>>
{
    public int CountryId { get; set; }
    public bool? IsDeleted  { get; set; }


    public CityGetAllQuery(int countryId, bool? isIsDeleted)
    {
        CountryId = countryId;
        IsDeleted = isIsDeleted;
    }
    
}