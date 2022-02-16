using AutoMapper;
using ToysAndGames.Api.Models;
using ToysAndGames.Core;

namespace ToysAndGames.Api.AutoMapperProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}