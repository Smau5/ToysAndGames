using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToysAndGames.DTOs;
using Xunit;

namespace ToysAndGames.IntegrationTests.Controllers.ProductsController;

public class UpdateEndpoint : IClassFixture<ToysAndGamesApiFixture>
{
    private readonly HttpClient _httpClient;

    public UpdateEndpoint(ToysAndGamesApiFixture factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task Update_GoodRequestAndExistingId_ReturnUpdatedProduct()
    {
        var firstProduct = SeedData.Products().First();

        var updatedProduct = new ProductRequestDto()
        {
            Company = "updated company",
            Description = "updated description",
            Name = "updated name",
            Image = new byte[] { },
            Price = 55M,
            AgeRestriction = 80
        };

        var response = await _httpClient.PutAsync($"Products/{firstProduct.Id}",
            new StringContent(JsonConvert.SerializeObject(updatedProduct), Encoding.UTF8, "application/json"));
        
        var responseData = JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());
        
        Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        Assert.Equal(firstProduct.Id,responseData.Id);
        Assert.Equal(updatedProduct.Company,responseData.Company);
        Assert.Equal(updatedProduct.Description,responseData.Description);
        Assert.Equal(updatedProduct.Image,responseData.Image);
        Assert.Equal(updatedProduct.Name,responseData.Name);
        Assert.Equal(updatedProduct.Price,responseData.Price);
        Assert.Equal(updatedProduct.AgeRestriction,responseData.AgeRestriction);
    }

    [Fact (Skip = "Fix put controller method on create")]
    public async Task Update_GoodRequestAndNonExistingId_ReturnCreatedProduct()
    {
        var nonExistingId = 123;

        var updatedProduct = new ProductRequestDto()
        {
            Company = "new company",
            Description = "new description",
            Name = "new name",
            Image = new byte[] { },
            Price = 22M,
            AgeRestriction = 80
        }; 
        
        var response = await _httpClient.PutAsync($"Products/{nonExistingId}",
            new StringContent(JsonConvert.SerializeObject(updatedProduct), Encoding.UTF8, "application/json"));
        
        var responseData = JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync());
        
        Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        Assert.Equal(nonExistingId,responseData.Id);
        Assert.Equal(updatedProduct.Company,responseData.Company);
        Assert.Equal(updatedProduct.Description,responseData.Description);
        Assert.Equal(updatedProduct.Image,responseData.Image);
        Assert.Equal(updatedProduct.Name,responseData.Name);
        Assert.Equal(updatedProduct.Price,responseData.Price);
        Assert.Equal(updatedProduct.AgeRestriction,responseData.AgeRestriction);
    }
}