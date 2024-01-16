using DotNet.Testcontainers.Builders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;
using TimeKeeper.Data;

namespace TimeKeeper.Tests;

public class TimeKeeperFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgre = new PostgreSqlBuilder()
        .WithImage("postgres:latest")
        // .WithPortBinding(1433, true)
        .WithDatabase("vgdb")
        .WithUsername("postgres")
        .WithPassword("postgres")
        // .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(1433))
        .Build();
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var descriptor = services.SingleOrDefault(s => 
                s.ServiceType == typeof(DbContextOptions<AppDbContext>));

            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(_postgre.GetConnectionString());
            });
        });
    }

    public async Task InitializeAsync()
    {
        await _postgre.StartAsync();
        using var scope = Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await dbContext.Database.MigrateAsync();
    }

    public new Task DisposeAsync()
    {
        return _postgre.StopAsync();
    }
}
