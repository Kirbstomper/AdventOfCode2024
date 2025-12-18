// See https://aka.ms/new-console-template for more information
using System.Numerics;
using System.Runtime.InteropServices;

Console.WriteLine("Program One");


using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();

List<string> input = new List<string>();

while (line != null)
{
    input.Add(line);
    line = reader.ReadLine();

}


Console.WriteLine(SolvePartOne(input));
Console.WriteLine(SolvePartTwo(input));

static BigInteger SolvePartOne(List<string> instructuions)
{
    BigInteger ans = 0;
    List<(BigInteger, BigInteger)> points = new List<(BigInteger, BigInteger)>();
    foreach (string item in instructuions)
    {
        var pos = item.Split(",").Select(BigInteger.Parse).ToList();
        points.Add((pos[0], pos[1]));
    }



    foreach (var item in points)
    {
        foreach (var other in points)
        {
            var x = (item.Item1 - other.Item1) > 0 ? (item.Item1 - other.Item1) : (item.Item1 - other.Item1) * -1;
            var y = (item.Item2 - other.Item2) > 0 ? (item.Item2 - other.Item2) : (item.Item2 - other.Item2) * -1;
            var size = (x + 1) * (y + 1);
            if (size >= ans)
            {
                ans = size;
                Console.WriteLine(item + " " + other);
            }
        }
    }
    return ans;
}

static BigInteger SolvePartTwo(List<string> instructuions)
{
    BigInteger ans = 0;
    foreach (string item in instructuions)
    {
        // Console.WriteLine(item);

    }
    return ans;

}