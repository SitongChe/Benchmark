# Benchmark

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.1702), VM=Hyper-V
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.302
  [Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
  Job-NRATOT : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Runtime=.NET 7.0  Toolchain=net7.0

|          Method |     Mean | Ratio | Code Size | Allocated | Alloc Ratio |
|---------------- |---------:|------:|----------:|----------:|------------:|
|     Interpreter | 6.078 us |  1.00 |   1,853 B |     216 B |        1.00 |
| SourceGenerator | 2.676 us |  0.44 |   1,850 B |     216 B |        1.00 |
