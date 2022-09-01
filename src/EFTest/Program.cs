// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using BenchmarkDotNet.Running;
using Domain;
using Domain.Models;
using EFTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine(BenchmarkRunner.Run<EFSaveChangeBechmark>());
return;

Console.WriteLine("Hello, World!");

Console.WriteLine("*****Slow Method******");
Slow();

Console.WriteLine("*****Fast Method******");
Fast();

var services = new ServiceCollection();

//services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer("");
//});


var app = services.BuildServiceProvider();


//var dbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());

//var randomBlogs = await dbContext.Blogs
//    .OrderBy(_ => Guid.NewGuid())
//    .Take(10)
//    .ToListAsync();


//var groupByNothing = await dbContext.Blogs
//    .GroupBy(_ => 1)
//    .Select(x => new { SumLikes = x.Sum(s => s.Likes) })
//    .FirstOrDefaultAsync();


static void Slow()
{
    using (var ctx = new ApplicationDbContext())
    {
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();
        ctx.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ctx.ChangeTracker.AutoDetectChangesEnabled = false;

        var sw = Stopwatch.StartNew();
        var cycle = 1;
        var counter = 0;
        while (counter < 50)
        {
            PumpIntoDB(ctx, sw, cycle++);
            counter++;
        }
    }
}

static void Fast()
{
    using (var ctx = new ApplicationDbContext())
    {
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();
    }

    var sw = Stopwatch.StartNew();
    var cycle = 1;
    var counter = 0;
    while (counter < 50)
    {
        using (var ctx = new ApplicationDbContext())
        {
            ctx.ChangeTracker.AutoDetectChangesEnabled = false;
            ctx.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            PumpIntoDB(ctx, sw, cycle++);

        }

        counter++;
    }
}

static void PumpIntoDB(ApplicationDbContext ctx, Stopwatch sw, int cycle)
{
    sw.Restart();
    foreach (var i in Enumerable.Range(0, 1000))
    {
        ctx.Blogs.Add(new Blog() { Title = $"dans{i}" });

        ctx.SaveChanges();
    }
    var saveChangesAdd = sw.ElapsedMilliseconds;
    Console.WriteLine($"Cycle {cycle:D4}\tSave:{saveChangesAdd}ms");
}