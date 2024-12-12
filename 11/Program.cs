// See https://aka.ms/new-console-template for more information
using System.Buffers;
using System.Collections.Specialized;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

Console.WriteLine("Day 11");


using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();

List<String> nums = line.Split(" ").ToList();
Dictionary<string, string> calcs = new Dictionary<string, string>();
Dictionary<string, (string, string)> splits = new Dictionary<string, (string, string)>();
Dictionary<int, bool> even = new Dictionary<int, bool>();
Stack<(string, int, List<string>)> rocks = new Stack<(string, int, List<string>)>(2038686383);

Dictionary<string, string[]> next = new Dictionary<string, string[]>();

long ans = Solve(nums.ToArray(), 0, new Dictionary<string, Dictionary<int, long>>());


//nums.ToList().ForEach(n => Console.WriteLine(n));





static long Solve(string[] nums, int blink, Dictionary<string, Dictionary<int, long>> cache)
{
    var ans = 0L;

    foreach (string s in nums)
    {

        var solved_ans = 0L;

        if (cache.ContainsKey(s))
        {
            if (cache[s].ContainsKey(blink))
            {
                solved_ans += cache[s][blink];
                ans += cache[s][blink];
                continue;
            }

        }
        if (blink == 75)
        {
            //Console.Write(s + " ");
            //record in cache
            ans += 1;
            continue;
        }

        if (s == "0")
        {
            solved_ans += Solve(["1"], blink + 1, cache);

        }
        else if (s.Length % 2 == 0)
        {
            //Console.WriteLine("splitting: " + r);

            var real = (long.Parse(s.Substring(0, s.Length / 2)).ToString(), long.Parse(s.Substring(s.Length / 2)).ToString());

            solved_ans += Solve([real.Item1, real.Item2], blink + 1, cache);
        }
        else
        {
            var str = (long.Parse(s) * 2024).ToString();
            solved_ans += Solve([str], blink + 1, cache);
        }
        if (!cache.ContainsKey(s))
        {
            cache[s] = new Dictionary<int, long>();
        }
        cache[s].Add(blink, solved_ans);
        ans += solved_ans;

    }
    return ans;

}
Console.WriteLine();

Console.WriteLine(ans);