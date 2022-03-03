using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysAndGames.Data.Models;

namespace ToysAndGames.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(Getdata());

          

        }

        private List<Product> Getdata()
        {
            return new List<Product>()
                {
                    new Product(){  Id = 5, Company =""}
                };
        }
    }
}
