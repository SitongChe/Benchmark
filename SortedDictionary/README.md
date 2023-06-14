# Benchmark

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.1702), VM=Hyper-V
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.302
  [Host]     : .NET 7.0.7 (7.0.723.27404), X64 RyuJIT AVX2
  Job-AXGWTS : .NET 7.0.7 (7.0.723.27404), X64 RyuJIT AVX2

Runtime=.NET 7.0  Toolchain=net7.0

|                Method | IterationCount |       Mean | Ratio |   Gen0 | Code Size |   Gen1 |   Gen2 | Allocated | Alloc Ratio |
|---------------------- |--------------- |-----------:|------:|-------:|----------:|-------:|-------:|----------:|------------:|
|  TestSortedDictionary |             10 |   5.943 us |  1.00 | 0.0076 |   2,176 B |      - |      - |   5.98 KB |        1.00 |
| TestDictionaryOrderBy |             10 |  11.006 us |  1.85 | 0.0305 |   2,961 B |      - |      - |  12.73 KB |        2.13 |
|  TestDictionarySorted |             10 |   8.080 us |  1.36 | 0.0305 |   3,536 B |      - |      - |  11.97 KB |        2.00 |
|                       |                |            |       |        |           |        |        |           |
   |
|  TestSortedDictionary |             50 |  81.358 us |  1.00 | 0.2441 |   2,176 B |      - |      - | 115.31 KB |        1.00 |
| TestDictionaryOrderBy |             50 |  99.332 us |  1.22 | 0.3662 |   2,961 B |      - |      - | 186.56 KB |        1.62 |
|  TestDictionarySorted |             50 |  98.238 us |  1.21 | 0.3662 |   3,536 B |      - |      - | 184.18 KB |        1.60 |
|                       |                |            |       |        |           |        |        |           |
   |
|  TestSortedDictionary |            100 | 390.362 us |  1.00 | 5.3711 |   2,176 B | 4.8828 | 4.8828 | 446.46 KB |        1.00 |
| TestDictionaryOrderBy |            100 | 494.362 us |  1.27 | 5.8594 |   2,961 B | 4.8828 | 4.8828 | 680.71 KB |        1.52 |
|  TestDictionarySorted |            100 | 493.995 us |  1.27 | 5.8594 |   3,536 B | 4.8828 | 4.8828 | 676.73 KB |        1.52 |