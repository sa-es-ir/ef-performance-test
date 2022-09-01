using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTest;

[SimpleJob(RuntimeMoniker.Net70)]
[SimpleJob(RuntimeMoniker.Net60)]
[RPlotExporter]
[MemoryDiagnoser()]
public class EFSaveChangeBechmark
{
    [Params(20000)]
    public int RowCount;

    [Benchmark()]
    public void Slow()
    {
        using (var ctx = new ApplicationDbContext())
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            ctx.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ctx.ChangeTracker.AutoDetectChangesEnabled = false;

            foreach (var i in Enumerable.Range(0, RowCount))
            {
                ctx.Blogs.Add(new Blog() { Title = $"Title_{i}" });

                ctx.SaveChanges();
            }
        }
    }

    [Benchmark()]
    public void Fast()
    {
        using (var ctx = new ApplicationDbContext())
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
        }

        foreach (var i in Enumerable.Range(0, RowCount))
        {
            using var ctx = new ApplicationDbContext();
            ctx.ChangeTracker.AutoDetectChangesEnabled = false;
            ctx.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            ctx.Blogs.Add(new Blog() { Title = $"Title_{i}" });

            ctx.SaveChanges();
        }
    }
}