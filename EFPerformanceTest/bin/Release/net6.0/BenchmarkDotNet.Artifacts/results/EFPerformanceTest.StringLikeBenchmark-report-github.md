``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19041.264 (2004/May2020Update/20H1)
Intel Core i7-4500U CPU 1.80GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.202
  [Host] : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT  [AttachedDebugger]

Job=.NET 6.0  Runtime=.NET 6.0  

```
|    Method | Mean | Error |
|---------- |-----:|------:|
| StartWith |   NA |    NA |

Benchmarks with issues:
  StringLikeBenchmark.StartWith: .NET 6.0(Runtime=.NET 6.0)
