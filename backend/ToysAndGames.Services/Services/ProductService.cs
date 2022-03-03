using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ToysAndGames.DTOs;
using ToysAndGames.Infrastructure;
using ToysAndGames.Services.Interfaces;

namespace ToysAndGames.Services
{
    public class ProductService: IProductService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public ProductService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }


        public async Task<List<ProductDto>> GetAll()
        {
            var products = await _appDbContext.Products.ToListAsync();
            var productsResponse = _mapper.Map<List<ProductDto>>(products);
            return productsResponse;
        }

    }
}