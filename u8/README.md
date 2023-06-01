# Benchmark

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.1702), VM=Hyper-V
Intel Xeon Platinum 8370C CPU 2.80GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.302
  [Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
  Job-XWUDUM : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Runtime=.NET 7.0  Toolchain=net7.0

|       Method |       Mean | Ratio | Code Size | Allocated | Alloc Ratio |
|------------- |-----------:|------:|----------:|----------:|------------:|
| WithEncoding | 17.8803 ns |  1.00 |      96 B |      32 B |        1.00 |
|       Withu8 |  0.3256 ns |  0.02 |      24 B |         - |        0.00 |
