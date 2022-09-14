using System.Collections;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace EFTest;

[MemoryDiagnoser(false)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
public class LinqOrderByBenchmark
{
    [Params(1000)]
    public int Length { get; set; }

    private IEnumerable<int> _source;

    [GlobalSetup]
    public void Setup() => _source = new[] { 1, 2, 3, 4 };

    [Benchmark]
    public void OrderBy_Net6() => _source.ToArray();

    [Benchmark]
    public void OrderBy_Net7() => _source.Order();

    [Benchmark]
    public void OrderByDescending_Net6() => _source.ToList().Average();

    [Benchmark]
    public void OrderByDescending_Net7() => _source.ToList().Sum();
}