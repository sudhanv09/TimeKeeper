using Microsoft.Extensions.DependencyInjection;
using TimeKeeper.Data;
using TimeKeeper.Services;

namespace TimeKeeper.Tests;

public class BaseTest : IClassFixture<TimeKeeperFactory>
{
    private readonly IServiceScope _scope;
    protected readonly AppDbContext _dbContext;
    protected readonly IReserveService _reserve;
    protected readonly IInfoService _info;

    protected BaseTest(TimeKeeperFactory factory)
    {
        _scope = factory.Services.CreateScope();
        _dbContext = _scope.ServiceProvider.GetRequiredService<AppDbContext>();
        _reserve = _scope.ServiceProvider.GetRequiredService<IReserveService>();
        _info = _scope.ServiceProvider.GetRequiredService<IInfoService>();
    }

    public void Dispose()
    {
        _scope?.Dispose();
        _dbContext?.Dispose();
    }
}