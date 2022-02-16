using AutoMapper;
using ToysAndGames.Api.AutoMapperProfiles;
using ToysAndGames.Api.Models;
using ToysAndGames.Core;
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