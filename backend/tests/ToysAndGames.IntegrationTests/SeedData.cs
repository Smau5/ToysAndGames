using System.Collections.Generic;
using ToysAndGames.Core;
using ToysAndGames.Infrastructure;

namespace ToysAndGames.IntegrationTests;

public static class SeedData
{
    public static List<Product> Products()
    {
        var id = 1;

        var products = new List<Product>()
        {
            new Product()
            {
                Id = id++,
                Name = "Star war lego",
                Company = "Lego",
                Description = "Lego Star Wars is a Lego theme that incorporates the Star Wars saga and franchise.",
                Image = new byte[] { },
                Price = 20.5M,
                AgeRestriction = 12
            },
            new Product()
            {
                Id = id++,
                Name = "Dimension Force Booster",
                Company = "Konami",
                Description =
                    "This 100-card set includes multiple brand-new themes as well as new cards for older strategies.",
                Image = new byte[] { },
                Price = 10M,
                AgeRestriction = 12
            }
        };
        return products;
    }
    public static void PopulateTestData(AppDbContext dbContext)
    {
        dbContext.Products.AddRange(Products());

        dbContext.SaveChanges();
    }
}