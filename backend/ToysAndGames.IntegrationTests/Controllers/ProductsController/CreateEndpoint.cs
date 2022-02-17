using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToysAndGames.Api.Models;
using Xunit;

namespace ToysAndGames.IntegrationTests.Controllers.ProductsController;

public class CreateEndpoint : IClassFixture<ToysAndGamesApiFixture>
{
    private readonly HttpClient _httpClient;

    public CreateEndpoint(ToysAndGamesApiFixture factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task Creates_GoodRequest_ReturnsCreatedProduct()
    {
        var newProduct = new ProductRequestDto()
        {
            Company = "new company",
            Description = "new description",
            Image = new byte[] { },
            Name = "new product name",
            Price = 100M,
            AgeRestriction = 20
        };

        var response =
            await _httpClient.PostAsync("Products",
                new StringContent(JsonConvert.SerializeObject(newProduct), Encoding.UTF8, "application/json"));

        var responseData = JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(newProduct.Company, responseData.Company);
        Assert.Equal(newProduct.Description, responseData.Description);
        Assert.Equal(newProduct.Image, responseData.Image);
        Assert.Equal(newProduct.Name, responseData.Name);
        Assert.Equal(newProduct.Price, responseData.Price);
        Assert.Equal(newProduct.AgeRestriction, responseData.AgeRestriction);
    }
}