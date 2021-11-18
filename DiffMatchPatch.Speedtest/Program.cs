// Copyright 2010 Google Inc.
// All Right Reserved.

using DiffMatchPatch;
using System;
using System.Collections.Generic;

/// <summary>
/// https://github.com/google/diff-match-patch/tree/master/csharp
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
            Run("Speedtest1.txt", "Speedtest2.txt");
    }
    public static void Run(string file1, string file2)
    {
        string text1 = System.IO.File.ReadAllText(file1);
        string text2 = System.IO.File.ReadAllText(file2);

        diff_match_patch dmp = new diff_match_patch();
        dmp.Diff_Timeout = 0;

        // Execute one reverse diff as a warmup.
        dmp.diff_main(text2, text1);
        GC.Collect();
        GC.WaitForPendingFinalizers();

        DateTime ms_start = DateTime.Now;
        List<Diff> diffs = dmp.diff_main(text1, text2);
        DateTime ms_end = DateTime.Now;

        //foreach(var diff in diffs)
        //{
        //    Console.WriteLine(diff);
        //}
        Console.WriteLine("Elapsed time: " + (ms_end - ms_start));
    }
}