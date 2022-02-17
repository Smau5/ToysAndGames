using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToysAndGames.Api.Models;
using Xunit;

namespace ToysAndGames.IntegrationTests.Controllers.ProductsController;

public class DeleteEndpoint : IClassFixture<ToysAndGamesApiFixture>
{
    private readonly HttpClient _httpClient;

    public DeleteEndpoint(ToysAndGamesApiFixture factory)
    {
        
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task Delete_SuccessfulDelete_ReturnNoContent()
    {
        var firstProduct = SeedData.Products().First();
        
        var response = await _httpClient.DeleteAsync($"Products/{firstProduct.Id}");
        
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

        var getAllResponse = await _httpClient.GetAsync("Products");

        var responseData = JsonConvert.DeserializeObject<List<ProductDto>>(await getAllResponse.Content.ReadAsStringAsync());
        
        Assert.True(responseData.Count < SeedData.Products().Count);
    }

    [Fact]
    public async Task Delete_NonExistingProductId_ReturnNotFound()
    {
        var nonExistingProductId = 20329;
        
        var response = await _httpClient.DeleteAsync($"Products/{nonExistingProductId}");
        
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
}