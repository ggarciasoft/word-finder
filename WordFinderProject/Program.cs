// See https://aka.ms/new-console-template for more information
using WordFinderProject;
using System.Diagnostics;

// Get initial memory usage
var initialMemory = Process.GetCurrentProcess().WorkingSet64 / 1024.0 / 1024.0; // Convert to MB
Console.WriteLine($"Initial Memory Usage: {initialMemory:F2} MB");

var matrix = new[]
{
    "zxcvdogasdfghjk",
    "qwertyuiopasdfg",
    "zxcvbirdnmqwera",
    "qwertyuiopasdfg",
    "zxcvdogasdfghjk",
    "qwertyuiopasdfg",
    "zxcvbirdnmqwera",
    "qwertyuiopasdfg",
    "zxcvdogasdfghjk",
    "qwertyuiopasdfg",
    "zxcvbnmasdfghjk",
    "qwertyuiopasdfg",
    "zxcvbnmasdfghjk",
    "qwertyuiopasdfg",
    "zxcvbnmasdfghjk"
};

Console.WriteLine("\nSearching for words in matrix...");

var wordFinder = new WordFinder(matrix);
var wordstream = new[] { "dog", "bird", "cat" };

// Get memory usage before search
var beforeSearchMemory = Process.GetCurrentProcess().WorkingSet64 / 1024.0 / 1024.0;
Console.WriteLine($"Memory Usage Before Search: {beforeSearchMemory:F2} MB");

// Measure execution time
var stopwatch = Stopwatch.StartNew();
var result = wordFinder.Find(wordstream).ToList();
stopwatch.Stop();

// Get memory usage after search
var afterSearchMemory = Process.GetCurrentProcess().WorkingSet64 / 1024.0 / 1024.0;

Console.WriteLine($"\nResults found: {result.Count}");
Console.WriteLine("Words found (in order of frequency):");
foreach (var word in result)
{
    Console.WriteLine($"- {word}");
}

Console.WriteLine($"\nPerformance Metrics:");
Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
Console.WriteLine($"Memory Usage After Search: {afterSearchMemory:F2} MB");
Console.WriteLine($"Memory Difference: {(afterSearchMemory - beforeSearchMemory):F2} MB");
Console.WriteLine($"Peak Memory Usage: {(Process.GetCurrentProcess().PeakWorkingSet64 / 1024.0 / 1024.0):F2} MB");
