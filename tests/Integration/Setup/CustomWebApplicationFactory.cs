using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TrilhaApiDesafio.Context;

namespace TrilhaApiDesafio.Tests.Integration.Setup
{

    public class CustomWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.Remove<DbContextOptions<OrganizadorContext>>();
                services.Remove<DbContextOptions>();

                services.AddDbContext<OrganizadorContext>(options => options.UseInMemoryDatabase("InMemoryDataBase"));
                services.AddScoped<IDbInitializer, DbInitializer>();
            });

            builder.UseEnvironment("Development");
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            var host = base.CreateHost(builder);

            SeedDatabase(host.Services);

            return host;
        }

        void SeedDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                dbInitializer.SeedData();
            }
        }
    }
}

internal static class IServiceCollectionExtensions
{
    public static bool Remove<T>(this IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(
            d => d.ServiceType == typeof(T));

        if (descriptor == null)
        {
            return false;
        }

        services.Remove(descriptor);

        return true;
    }
}