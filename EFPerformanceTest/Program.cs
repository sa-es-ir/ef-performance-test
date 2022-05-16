// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using EFPerformanceTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

Console.WriteLine("Hello, World!");

Host.CreateDefaultBuilder().UseConsoleLifetime()
    .ConfigureLogging(x => x.AddConsole()).ConfigureServices(services =>
    {

        services.AddDbContext<ApplicationDbContext>(op =>
        {
            op.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SuxxeedAnalytixx;Integrated Security=true;MultipleActiveResultSets=true");
            op.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddHostedService<StringLikeBenchmark>();
    }).Build().Run();



//Console.Write(BenchmarkRunner.Run<StringLikeBenchmark>());


