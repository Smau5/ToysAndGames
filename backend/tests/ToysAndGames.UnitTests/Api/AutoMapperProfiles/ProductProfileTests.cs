using AutoMapper;

using ToysAndGames.Data.Models;
using ToysAndGames.DTOs;
using Xunit;

namespace ToysAndGames.UnitTests.Api.AutoMapperProfiles;

public class ProductProfileTests
{
    [Fact]
    public void ProductToProductDtoConfiguration_IsValid()
    {
        var configuration = new MapperConfiguration(cfg =>
            cfg.CreateMap<Product, ProductDto>());

        configuration.AssertConfigurationIsValid();
    }
}