using System.Diagnostics;

namespace IEnumerableVsIQueryable.Console.Helpers;

public static class PerformanceHelper
{
    public static void Measure(string title, Action action)
    {
        System.Console.WriteLine();
        System.Console.WriteLine($"========== {title} ==========");

        var stopwatch = Stopwatch.StartNew();

        action();

        stopwatch.Stop();

        System.Console.WriteLine($"Tiempo: {stopwatch.ElapsedMilliseconds} ms");
        System.Console.WriteLine();
    }
}