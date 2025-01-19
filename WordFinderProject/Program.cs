// See https://aka.ms/new-console-template for more information
using WordFinderProject;
using System.Diagnostics;

// Get initial memory usage
var initialMemory = Process.GetCurrentProcess().WorkingSet64 / 1024.0 / 1024.0; // Convert to MB
Console.WriteLine($"Initial Memory Usage: {initialMemory:F2} MB");

// Create 64x64 matrix with random characters and some embedded words
var matrix = new string[64];
var random = new Random(42); // Fixed seed for reproducibility
var chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

for (int i = 0; i < 64; i++)
{
    var row = new char[64];
    for (int j = 0; j < 64; j++)
    {
        row[j] = chars[random.Next(chars.Length)];
    }
    matrix[i] = new string(row);
}

// Insert some words at specific positions
matrix[5] = matrix[5].Remove(10, 3).Insert(10, "dog");
matrix[15] = matrix[15].Remove(20, 4).Insert(20, "bird");
matrix[25] = matrix[25].Remove(30, 4).Insert(30, "lion");
matrix[35] = matrix[35].Remove(40, 4).Insert(40, "wolf");
matrix[45] = matrix[45].Remove(50, 5).Insert(50, "tiger");
matrix[6] = matrix[6].Remove(15, 5).Insert(15, "horse");
matrix[16] = matrix[16].Remove(25, 5).Insert(25, "sheep");
matrix[26] = matrix[26].Remove(35, 5).Insert(35, "snake");
matrix[36] = matrix[36].Remove(45, 5).Insert(45, "whale");
matrix[46] = matrix[46].Remove(55, 5).Insert(55, "zebra");

Console.WriteLine("\nSearching for words in matrix...");

var wordFinder = new WordFinder(matrix);
var wordstream = new[] { 
    "dog", "bird", "cat", "lion", "wolf",
    "tiger", "bear", "deer", "duck", "fish",
    "frog", "hawk", "owl", "mouse", "horse",
    "sheep", "goat", "snake", "whale", "zebra",
    "camel", "panda", "koala", "eagle", "shark",
    "moose", "llama", "bison", "otter", "sloth",
    "lemur", "gecko", "iguana" // 33 words total
};

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
