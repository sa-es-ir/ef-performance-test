using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace EFTest;

[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
[RPlotExporter]
[MemoryDiagnoser()]
public class LinqAggregateBenchmark
{
    [Params(1000)]
    public int Length { get; set; }

    private IEnumerable<int> _source;

    [GlobalSetup]
    public void Setup() => _source = Enumerable.Range(1, Length);

    [Benchmark]
    public int Min() => _source.ToList().Min();

    [Benchmark]
    public int Max() => _source.ToList().Max();

    [Benchmark]
    public double Average() => _source.ToList().Average();

    [Benchmark]
    public int Sum() => _source.ToList().Sum();
}