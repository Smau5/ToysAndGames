using AutoMapper;
using ToysAndGames.Data.Models;
using ToysAndGames.DTOs;

namespace ToysAndGames.Api.AutoMapperProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}