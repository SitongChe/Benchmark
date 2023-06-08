using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Win32;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.IO.MemoryMappedFiles;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Net.Sockets;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

[MemoryDiagnoser(displayGenColumns: false)]
[DisassemblyDiagnoser]
[HideColumns("Error", "StdDev", "Median", "RatioSD")]
public partial class Program
{

    
    static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);


    //example 1 0.44 ratio
    private const string ReportColumnGroup = "ReportColumn";
    private static readonly string s_haystack = " sdf Entity.ReportColumn test string that contains some {= Feed. Attribute1 :d} d {= Feed . Attribute2 :$19.95} d {= Feed.Attribute3:b} f {= Feed  .  Attribute4  :a} rem {  COUNTDOWN(2023-09-01 11:11:11) )  }";

    private static Regex reportColumnRegex = new Regex($@"(\w+\.)?(?<{ReportColumnGroup}>\w+)");
    [GeneratedRegex($@"(\w+\.)?(?<{ReportColumnGroup}>\w+)")]
    private static partial Regex ReportColumnRegex();

    [Benchmark(Baseline = true)] public string Interpreter() => reportColumnRegex.Replace(s_haystack, " ");

    [Benchmark] public string SourceGenerator() => ReportColumnRegex().Replace(s_haystack, " ");

    //example 2  0.37 ratio
    private static readonly string emails = " sitche@microsoft.com";

    private static Regex emailMatch = new Regex(
        @"^(([^<>()[\]\\.,;:\s@""]+(\.[^<>()[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$",
        RegexOptions.IgnoreCase);
    [GeneratedRegex(
        @"^(([^<>()[\]\\.,;:\s@""]+(\.[^<>()[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$",
        RegexOptions.IgnoreCase)]
    private static partial Regex EmailMatch();

    [Benchmark] public bool Interpreter2() => emailMatch.IsMatch(emails);

    [Benchmark] public bool SourceGenerator2() => EmailMatch().IsMatch(emails);


}
