using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace EFPerformanceTest;


public class StringLikeBenchmark : IHostedService
{
    private readonly ApplicationDbContext _dbContext;

    public StringLikeBenchmark(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task StartWith()
    {
        await _dbContext.Customers.Where(x => x.Name.StartsWith("Cus")).FirstOrDefaultAsync();
    }

    public async Task LikeWith()
    {
        await _dbContext.Customers.Where(x => EF.Functions.Like(x.Name, "Cus%")).FirstOrDefaultAsync();
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await StartWith();
        await LikeWith();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}