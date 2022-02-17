using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ToysAndGames.Infrastructure;

namespace ToysAndGames.IntegrationTests;

public class ToysAndGamesApiFixture : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<AppDbContext>));

            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            var dbName = Guid.NewGuid().ToString();
            services.AddDbContext<AppDbContext>(options => { options.UseInMemoryDatabase(dbName); });

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<AppDbContext>();

            var logger = scopedServices
                .GetRequiredService<ILogger<ToysAndGamesApiFixture>>();

            db.Database.EnsureCreated();
            try
            {
                // Seed the database with test data.
                SeedData.PopulateTestData(db);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred seeding the " +
                                    "database with test messages. Error: {ex.Message}", ex.Message);
            }
        });
    }
}