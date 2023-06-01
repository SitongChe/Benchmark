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

    private byte[] _data = Enumerable.Repeat((byte)123, 29).Append((byte)42).ToArray();

    [Benchmark(Baseline = true)]
    [Arguments((byte)42)]
    public bool Find(byte value) => Contains(_data, value); // just the fallback path in its own method

    [Benchmark]
    [Arguments((byte)42)]
    public bool FindVectorized(byte value) => Contains_Vectorized(_data, value); // the implementation we just wrote

    static bool Contains(ReadOnlySpan<byte> haystack, byte needle)
    {
        for (int i = 0; i < haystack.Length; i++)
        {
            if (haystack[i] == needle)
            {
                return true;
            }
        }

        return false;
    }

    static unsafe bool Contains_Vectorized(ReadOnlySpan<byte> haystack, byte needle)
    {
        if (Vector128.IsHardwareAccelerated && haystack.Length >= Vector128<byte>.Count)
        {
            ref byte current = ref MemoryMarshal.GetReference(haystack);

            Vector128<byte> target = Vector128.Create(needle);
            ref byte endMinusOneVector = ref Unsafe.Add(ref current, haystack.Length - Vector128<byte>.Count);
            do
            {
                if (Vector128.EqualsAny(target, Vector128.LoadUnsafe(ref current)))
                {
                    return true;
                }

                current = ref Unsafe.Add(ref current, Vector128<byte>.Count);
            }
            while (Unsafe.IsAddressLessThan(ref current, ref endMinusOneVector));

            if (Vector128.EqualsAny(target, Vector128.LoadUnsafe(ref endMinusOneVector)))
            {
                return true;
            }
        }
        else
        {
            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle)
                {
                    return true;
                }
            }
        }

        return false;
    }
}