// See https://aka.ms/new-console-template for more information
using System.Buffers;
using System.Globalization;
using Microsoft.VisualBasic;

Console.WriteLine("Day 11");


using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();

List<String> nums = line.Split(" ").ToList();
Dictionary<string, string> calcs = new Dictionary<string, string>();
Dictionary<string, (string, string)> splits = new Dictionary<string, (string, string)>();
Dictionary<int, bool> even = new Dictionary<int, bool>();

Stack<(string, int)> rocks = new Stack<(string, int)>(2038686383);

int ans = 0;
//Add initial to stack
foreach (string s in nums)
{
    rocks.Push((s, 0));
}


while (rocks.Count != 0)
{

    var r = rocks.Pop();

    if (r.Item2 == 50)
    {
        // Console.Write(r.Item1 + " ");
        ans++;
        continue;
    }

    if (r.Item1 == "0")
    {
        rocks.Push(("1", r.Item2 + 1));
        continue;
    }
    if (!even.ContainsKey(r.Item1.Length))
    {
        even[r.Item1.Length] = r.Item1.Length % 2 == 0;
    }
    if (even[r.Item1.Length])
    {
        //Console.WriteLine("splitting: " + r);
        if (!splits.ContainsKey(r.Item1))
        {
            splits[r.Item1] = (long.Parse(r.Item1.Substring(0, r.Item1.Length / 2)).ToString(), long.Parse(r.Item1.Substring(r.Item1.Length / 2)).ToString());

        }
        var real = splits[r.Item1];
        rocks.Push((real.Item2, r.Item2 + 1));
        rocks.Push((real.Item1, r.Item2 + 1));
    }
    else
    {
        if (!calcs.ContainsKey(r.Item1))
        {
            calcs[r.Item1] = (long.Parse(r.Item1) * 2024).ToString();
        }
        rocks.Push((calcs[r.Item1], r.Item2 + 1));
    }
}

//nums.ToList().ForEach(n => Console.WriteLine(n));


Console.WriteLine();

Console.WriteLine(ans);