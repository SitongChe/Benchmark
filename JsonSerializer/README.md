# Benchmark

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.1702), VM=Hyper-V
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.302
  [Host]     : .NET 7.0.7 (7.0.723.27404), X64 RyuJIT AVX2
  Job-TVASEF : .NET 7.0.7 (7.0.723.27404), X64 RyuJIT AVX2

Runtime=.NET 7.0  Toolchain=net7.0

|             Method |     Mean | Ratio |   Gen0 | Code Size |   Gen1 |   Gen2 | Allocated | Alloc Ratio |
|------------------- |---------:|------:|-------:|----------:|-------:|-------:|----------:|------------:|
|    TestJsonConvert | 395.7 us |  1.00 | 5.8594 |   2,495 B | 5.3711 | 5.3711 |  445.2 KB |        1.00 |
| TestJsonSerializer | 205.1 us |  0.52 | 5.6152 |   2,849 B | 5.6152 | 5.6152 | 224.75 KB |        0.50 |