// See https://aka.ms/new-console-template for more information
using System.Buffers;
using System.Globalization;

Console.WriteLine("Day 11");


using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();

List<String> nums = line.Split(" ").ToList();
Dictionary<string, string> calcs = new Dictionary<string, string>();
Dictionary<string, (string, string)> splits = new Dictionary<string, (string, string)>();
Dictionary<int, bool> even = new Dictionary<int, bool>();

Stack<(long, int)> rocks = new Stack<(long, int)>();

int ans = 0;


for (int x = 0; x < 75; x++)
{
    for (int i = 0; i < nums.Count(); i++)
    {
        if (nums[i] == "0")
        {
            nums[i] = "1";
            continue;
        }
        if (!even.ContainsKey(nums[i].Length))
        {
            even[nums[i].Length] = nums[i].Length % 2 == 0;
        }
        if (even[nums[i].Length])
        {

            if (!splits.ContainsKey(nums[i]))
            {
                var toSplit = nums[i];
                splits[nums[i]] = (long.Parse(toSplit.Substring(0, toSplit.Length / 2)).ToString(), long.Parse(toSplit.Substring(toSplit.Length / 2)).ToString());

            }
            var real = splits[nums[i]];
            nums[i] = real.Item2;
            nums.Add(real.Item1);
            i++;
        }
        else
        {
            if (!calcs.ContainsKey(nums[i]))
            {
                calcs[nums[i]] = (long.Parse(nums[i]) * 2024).ToString();
            }
            nums[i] = calcs[nums[i]];
        }

    }
    Console.WriteLine(x);
    Console.WriteLine(nums.Count);
}
//nums.ToList().ForEach(n => Console.WriteLine(n));


Console.WriteLine(nums.Count);