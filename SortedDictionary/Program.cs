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

    [Params(10, 50, 100)]
    public int IterationCount { get; set; } = 100;

    [Benchmark(Baseline = true)] public string TestSortedDictionary()
    {
        var values = new SortedDictionary<string, object>();
        for (var i = 0; i < IterationCount; i++)
        {
            values.Add(string.Concat(Enumerable.Repeat("a", IterationCount - i)), string.Concat(Enumerable.Repeat("adsfdastfwedgfdasdfre", i)));
        }

        return System.Text.Json.JsonSerializer.Serialize(values);
    }

    [Benchmark] public string TestDictionaryOrderBy()
    {
        var values = new Dictionary<string, object>();
        for (var i = 0; i < IterationCount; i++)
        {
            values.Add(string.Concat(Enumerable.Repeat("a", IterationCount - i)), string.Concat(Enumerable.Repeat("adsfdastfwedgfdasdfre", i)));
        }

        return JsonConvert.SerializeObject(values.OrderBy(x => x.Key));
    }

    [Benchmark]
    public string TestDictionarySorted()
    {
        var values = new Dictionary<string, object>();
        for (var i = 0; i < IterationCount; i++)
        {
            values.Add(string.Concat(Enumerable.Repeat("a", IterationCount - i)), string.Concat(Enumerable.Repeat("adsfdastfwedgfdasdfre", i)));
        }

        var sorted = new SortedDictionary<string, object>(values);
        return JsonConvert.SerializeObject(sorted);
    }

}