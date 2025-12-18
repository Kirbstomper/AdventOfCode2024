// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Timers;

Console.WriteLine("Program One");

using StreamReader reader = new("input.txt");

List<List<char>> map = new List<List<char>>();

string? text = reader.ReadLine();

while (text != null)
{
    map.Add(text.ToList());
    text = reader.ReadLine();
}
Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();
Console.WriteLine("Part 1: " + SolvePartOne(map));
Console.WriteLine("Part 2: " + SolvePartTwo(map));
stopWatch.Stop();

Console.WriteLine("Time Elapsed: " + stopWatch.ElapsedMilliseconds + "ms");


static long SolvePartOne(List<List<char>> map)
{
    long ans = 0;

    //Loop through and check positions

    for (int y = 0; y < map.Count; y++)
    {
        for (int x = 0; x < map[y].Count; x++)
        {
            //check cardinals
            if (map[y][x] == '@')
            {
                var surrounding = 0;

                if (TryGet(map, y, x - 1) == '@') surrounding++;
                if (TryGet(map, y, x + 1) == '@') surrounding++;
                if (TryGet(map, y - 1, x) == '@') surrounding++;
                if (TryGet(map, y + 1, x) == '@') surrounding++;

                //Diag
                if (TryGet(map, y + 1, x - 1) == '@') surrounding++;
                if (TryGet(map, y + 1, x + 1) == '@') surrounding++;
                if (TryGet(map, y - 1, x + 1) == '@') surrounding++;
                if (TryGet(map, y - 1, x - 1) == '@') surrounding++;
                if (surrounding < 4) ans++;
            }
            // Console.Write(map[y][x]);

        }
        // Console.WriteLine();
    }
    return ans;
}


static long SolvePartTwo(List<List<char>> map)
{
    long ans = 0;

    //Loop through and check positions
    var removed = 1;
    while (removed > 0)
    {
        removed = 0;
        for (int y = 0; y < map.Count; y++)
        {
            for (int x = 0; x < map[y].Count; x++)
            {
                //check cardinals
                if (map[y][x] == '@')
                {
                    var surrounding = 0;

                    if (TryGet(map, y, x - 1) == '@') surrounding++;
                    if (TryGet(map, y, x + 1) == '@') surrounding++;
                    if (TryGet(map, y - 1, x) == '@') surrounding++;
                    if (TryGet(map, y + 1, x) == '@') surrounding++;

                    //Diag
                    if (TryGet(map, y + 1, x - 1) == '@') surrounding++;
                    if (TryGet(map, y + 1, x + 1) == '@') surrounding++;
                    if (TryGet(map, y - 1, x + 1) == '@') surrounding++;
                    if (TryGet(map, y - 1, x - 1) == '@') surrounding++;
                    if (surrounding < 4)
                    {
                        ans++;
                        map[y][x] = '.';
                        removed++;
                    }
                }
                //check diags
                //  Console.Write(map[y][x]);

            }
            //  Console.WriteLine();
        }

        /// Console.WriteLine();
        //Console.WriteLine();
        //  Console.WriteLine("---------------------------");

    }
    return ans;
}
static char TryGet(List<List<char>> map, int y, int x)
{
    try
    {
        return map[y][x];
    }
    catch
    {
        return 'u';
    }

}
