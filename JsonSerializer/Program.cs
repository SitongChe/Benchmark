using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

[MemoryDiagnoser]
[DisassemblyDiagnoser]
[HideColumns("Error", "StdDev", "Median", "RatioSD")]
public partial class Program
{

    
    static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

    private static Dictionary<string, object> values = new Dictionary<string, object>();

    //[Params(1_000, 10_000, 100_000)]
    public int IterationCount { get; set; } = 100;

    [GlobalSetup]
    public void GlobalSetup()
    {
        for (var i = 0; i < IterationCount; i++)
        {
            values.Add(string.Concat(Enumerable.Repeat("a", i)), string.Concat(Enumerable.Repeat("adsfdastfwedgfdasdfre", i)));
        }
    }

    [Benchmark(Baseline = true)] public string TestJsonConvert() => JsonConvert.SerializeObject(values.Where(kv => kv.Value != null).ToDictionary(kv => kv.Key, kv => kv.Value is DateTime dt ? dt.ToString("yyyy/MM/dd HH:mm:ss") : kv.Value));

    [Benchmark] public string TestJsonSerializer() => System.Text.Json.JsonSerializer.Serialize(values.Where(kv => kv.Value != null).ToDictionary(kv => kv.Key, kv => kv.Value is DateTime dt ? dt.ToString("yyyy/MM/dd HH:mm:ss") : kv.Value));


}