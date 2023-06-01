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

    private static readonly string s_haystack = "test string that contains some {= Feed. Attribute1 :d} d {= Feed . Attribute2 :$19.95} d {= Feed.Attribute3:b} f {= Feed  .  Attribute4  :a} rem {  COUNTDOWN(2023-09-01 11:11:11) )  }";

    private Regex FuncRegex = new Regex(
@"
            \{\=
                (?<funcname>[^(.]*)                 # Function name
                [(]                                 # Start of (
                    (?<params>.*?(?=(?<!\\)\))*)    # params everything between ( and )
                [)]                                 # End of )
                (?<default>.*)                      # skip all whitespaces between ) and }
            \}",
            RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);

    [GeneratedRegex(@"
            \{\=
                (?<funcname>[^(.]*)                 
                [(]                                 
                    (?<params>.*?(?=(?<!\\)\))*)    
                [)]                                 
                (?<default>.*)                     
            \}",
            RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace)]
    private partial Regex SG();

    [Benchmark(Baseline = true)] public Match Interpreter() => FuncRegex.Match(s_haystack);

    [Benchmark] public Match SourceGenerator() => SG().Match(s_haystack);
}