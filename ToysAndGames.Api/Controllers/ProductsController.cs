using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToysAndGames.Api.Models;
using ToysAndGames.Core;
using ToysAndGames.Infrastructure;

namespace ToysAndGames.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public ProductsController(AppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> Get(int id)
    {
        var product = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetAll()
    {
        var products = await _appDbContext.Products.ToListAsync();

        var productsResponse = _mapper.Map<List<ProductDto>>(products);

        return Ok(productsResponse);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create([FromBody] ProductRequestDto productRequestDto)
    {
        var product = new Product()
        {
            Company = productRequestDto.Company,
            Description = productRequestDto.Description,
            Name = productRequestDto.Name,
            Price = productRequestDto.Price,
            AgeRestriction = productRequestDto.AgeRestriction
        };

        _appDbContext.Products.Add(product);
        await _appDbContext.SaveChangesAsync();

        var createProductResponse = _mapper.Map<ProductDto>(product);

        return Ok(createProductResponse);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductDto>> Update(int id, [FromBody] ProductRequestDto productRequestDto)
    {
        var product = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == id) ?? new Product();

        product.Company = productRequestDto.Company;
        product.Description = productRequestDto.Description;
        product.Name = productRequestDto.Name;
        product.Price = productRequestDto.Price;
        product.AgeRestriction = productRequestDto.AgeRestriction;

        _appDbContext.Products.Update(product);

        await _appDbContext.SaveChangesAsync();

        var updateProductResponse = _mapper.Map<ProductDto>(product);

        return Ok(updateProductResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product is null)
        {
            return NotFound();
        }

        _appDbContext.Products.Remove(product);
        await _appDbContext.SaveChangesAsync();

        return NoContent();
    }
}