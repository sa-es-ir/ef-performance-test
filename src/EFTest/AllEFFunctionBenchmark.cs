using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Domain;
using Domain.Models;

namespace EFTest;

[SimpleJob(RuntimeMoniker.Net70)]
public class AllEFFunctionBenchmark
{
    [Params(1000)]
    public int TotalCount { get; set; }

    public List<TestForeach> _list;

    [GlobalSetup]
    public void Setup()
    {
        _list = Enumerable.Range(0, TotalCount).Select(_ => new TestForeach()).ToList();
    }

    [Benchmark]
    public void Foreach()
    {
        foreach (var item in _list)
        {
            item.Name = "new name";
        }
    }

    [Benchmark]
    public void ForEach()
    {
        _list.ForEach(x => x.Name = "new name");
    }

    //[Benchmark]
    //public void Insert()
    //{
    //    var blogs = Enumerable.Range(0, TotalCount)
    //        .Select((_, i) => new Blog()
    //        {
    //            Title = $"title {i}",
    //            Url = $"Url{i}.com",
    //            Text = $"Text {i}",
    //            CreatedAt = DateTime.Now,
    //            Author = new Author() { Name = $"Saeed {i}", CreatedAt = DateTime.Now }
    //        });

    //    using (var context = new ApplicationDbContext())
    //    {
    //        context.Blogs.AddRange(blogs);

    //        context.SaveChanges();
    //    }
    //}

    //[Benchmark]
    //public void UpdateBulk()
    //{
    //    using (var context = new ApplicationDbContext())
    //    {
    //        var items = context.Blogs.OrderBy(x => Guid.NewGuid()).Take(TotalCount).ToList();

    //        for (int i = 0; i < items.Count; i++)
    //        {
    //            items[i].Title = $"*Update title {i}";
    //        }

    //        context.UpdateRange(items);

    //        context.SaveChanges();
    //    }
    //}
}

public class TestForeach
{
    public string Name { get; set; }
}