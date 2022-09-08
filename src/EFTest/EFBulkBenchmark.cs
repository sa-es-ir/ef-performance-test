using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using Domain;
using Domain.Models;

namespace EFTest;

[Config(typeof(Config))]
public class EFBulkBenchmark
{
    private class Config : ManualConfig
    {
        public Config()
        {
            SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Percentage)
                .WithTimeUnit(Perfolizer.Horology.TimeUnit.Millisecond);

            var baseJob = Job.Default;
            AddJob(baseJob.WithNuGet("Microsoft.EntityFrameworkCore.SqlServer", "7.0.0-preview.7.22376.2")
                .WithId("EF 7.0"));

            AddJob(baseJob.WithNuGet("Microsoft.EntityFrameworkCore.SqlServer", "6.0.0")
                .WithId("EF 6.0")
                .WithBaseline(true));
        }
    }

    [Benchmark]
    public void BulkInsert()
    {
        var dbContext = new ApplicationDbContext();
        var items = Enumerable.Range(0, 10).Select((_, i) => new Blog() { Title = $"Title {i}", Url = $"URL {i}" });

        dbContext.Blogs.AddRangeAsync(items);

        dbContext.SaveChangesAsync();
    }
}