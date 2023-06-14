# Benchmark
learning from Performance Improvements in .NET 7 - .NET Blog (microsoft.com)
https://devblogs.microsoft.com/dotnet/performance_improvements_in_net_7/

to run a benchmark comparing performance on .NET 6 and .NET 7, do:
dotnet run -c Release -f net6.0 --filter '**' --runtimes net6.0 net7.0

Or to run just on .NET 7:
dotnet run -c Release -f net7.0 --filter '**' --runtimes net7.0!
