using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToysAndGames.Api.Models;
using Xunit;

namespace ToysAndGames.IntegrationTests.Controllers.ProductsController;

public class GetAllEndpoint : IClassFixture<ToysAndGamesApiFixture>
{
    private readonly HttpClient _httpClient;

    public GetAllEndpoint(ToysAndGamesApiFixture factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task GetAll_ReturnTwoProducts()
    {

        var response = await _httpClient.GetAsync("Products");

        var reponseData = JsonConvert.DeserializeObject<List<ProductDto>>(await response.Content.ReadAsStringAsync());
        
        
        Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        Assert.Equal(SeedData.Products().Count, reponseData.Count);
    }
}