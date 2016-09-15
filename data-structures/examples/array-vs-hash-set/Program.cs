using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
          // Initialize stopwatch and text
          Stopwatch stopwatch = new Stopwatch();
          string text = System.IO.File.ReadAllText("./peter-pan.txt");

          ////
          // Insertion
          //
          Console.WriteLine("\nInserting");

          // Load words into an array
          stopwatch.Start();
          string[] words = text.Split(' ');
          stopwatch.Stop();
          Console.WriteLine($"It took {stopwatch.Elapsed} to populate the array.");

          // Load words into a HashSet
          HashSet<string> hsWords = new HashSet<string>();
          stopwatch.Reset();
          stopwatch.Start();
          foreach (string word in words)
          {
            if (!hsWords.Contains(word))
            {
              hsWords.Add(word);
            }
          }
          stopwatch.Stop();
          Console.WriteLine($"It took {stopwatch.Elapsed} to populate the array.");


          ////
          // Accessing
          //
          Console.WriteLine("\nAccessing");

          // Finding "END" in the words array
          stopwatch.Reset();
          stopwatch.Start();
          bool hasWord = words.Contains("END");
          stopwatch.Stop();
          Console.WriteLine($"It took {stopwatch.Elapsed} seconds to find END in the array.");

          // Finding "END" in the words HashSet
          stopwatch.Reset();
          stopwatch.Start();
          hsWords.Contains("END");
          stopwatch.Stop();
          Console.WriteLine($"It took {stopwatch.Elapsed} second to find END in the has set.");
        }
    }
}
