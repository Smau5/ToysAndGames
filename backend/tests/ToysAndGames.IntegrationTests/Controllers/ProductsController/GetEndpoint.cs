using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToysAndGames.DTOs;
using Xunit;

namespace ToysAndGames.IntegrationTests.Controllers.ProductsController;

public class GetEndpoint : IClassFixture<ToysAndGamesApiFixture>
{
    private readonly HttpClient _httpClient;

    public GetEndpoint(ToysAndGamesApiFixture factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task Get_ExistingId_ReturnProduct()
    {
        var firstProduct = SeedData.Products().First();

        var response = await _httpClient.GetAsync($"Products/{firstProduct.Id}");

        var responseData = JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());
        
        Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        Assert.Equal(firstProduct.Company,responseData.Company);
        Assert.Equal(firstProduct.Description,responseData.Description);
        Assert.Equal(firstProduct.Image,responseData.Image);
        Assert.Equal(firstProduct.Name,responseData.Name);
        Assert.Equal(firstProduct.Price,responseData.Price);
        Assert.Equal(firstProduct.AgeRestriction,responseData.AgeRestriction);
    }

    [Fact]
    public async Task Get_NonExistingId_ReturnNotFound()
    {

        var nonExistingId = 3024;

        var response = await _httpClient.GetAsync($"Products/{nonExistingId}");

        
        Assert.Equal(HttpStatusCode.NotFound,response.StatusCode);
    }
}