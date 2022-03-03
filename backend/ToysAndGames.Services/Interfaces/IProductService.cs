using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysAndGames.DTOs;

namespace ToysAndGames.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAll();
    }
}
