# Benchmark
learning from Performance Improvements in .NET 7 - .NET Blog (microsoft.com)![image](https://github.com/SitongChe/Benchmark/assets/12755002/8f7359a8-d4b0-427f-ba68-84874b61b486)


to run a benchmark comparing performance on .NET 6 and .NET 7, do:
dotnet run -c Release -f net6.0 --filter '**' --runtimes net6.0 net7.0

Or to run just on .NET 7:
dotnet run -c Release -f net7.0 --filter '**' --runtimes net7.0![image](https://github.com/SitongChe/Benchmark/assets/12755002/79075b13-0048-4ce0-b3e3-870d66d44d27)
