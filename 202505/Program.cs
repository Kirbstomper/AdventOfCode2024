// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

Console.WriteLine("Program One");


using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();

List<string> input = new List<string>();

while (line != null)
{
    input.Add(line);
    line = reader.ReadLine();

}

var stopWatch = new Stopwatch();
stopWatch.Start();
Console.WriteLine(SolvePartOne(input));
Console.WriteLine(SolvePartTwo(input));
stopWatch.Stop();
Console.WriteLine("Total Time: " + stopWatch.ElapsedMilliseconds + "ms");

static long SolvePartOne(List<string> instructuions)
{
    long ans = 0;
    List<(BigInteger, BigInteger)> numbers = new List<(BigInteger, BigInteger)>();
    foreach (string item in instructuions)
    {
        if (item.Contains("-"))
        {
            var range = item.Split("-");
            numbers.Add((BigInteger.Parse(range[0]), BigInteger.Parse(range[1])));
        }
        else
        {
            if (!string.IsNullOrWhiteSpace(item))
            {
                var food = BigInteger.Parse(item);
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (food >= numbers[i].Item1 && food <= numbers[i].Item2)
                    {
                        ans++;
                        break;
                    }
                }
            }
        }
    }
    return ans;
}

static BigInteger SolvePartTwo(List<string> instructuions)
{

    BigInteger ans = 0;
    List<(BigInteger, BigInteger)> numbers = new List<(BigInteger, BigInteger)>();

    foreach (string item in instructuions)
    {
        if (item.Contains("-"))
        {
            var range = item.Split("-");
            numbers.Add((BigInteger.Parse(range[0]), BigInteger.Parse(range[1])));
        }
    }

    //Now that we have the ranges, consolidate them....

    var consolidations = 1;

    while (consolidations != 0)
    {
        consolidations = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            for (int x = 0; x < numbers.Count; x++)
            {
                if (i == x) continue;
                //Check if we are in the range for item 1
                var itemOne = numbers[i].Item1;
                if (itemOne >= numbers[x].Item1 && itemOne <= numbers[x].Item2) //In range so could consolidate some
                {
                    var itemTwo = numbers[i].Item2;
                    //check if item 2 is in the range too
                    if (itemTwo <= numbers[x].Item2) //If full set is in the range, we can just remove it all
                    {
                        numbers.RemoveAt(i);
                        consolidations++;
                        i = 0;
                        break;
                    }
                    else // We have to just modify and try again another loop
                    {
                        numbers[i] = (numbers[x].Item2 + 1, numbers[i].Item2);
                        consolidations++;
                        i = 0;
                        break;
                    }
                }
            }
        }
    }

    for (int i = 0; i < numbers.Count; i++)
    {
        ans += numbers[i].Item2 - numbers[i].Item1;
        ans += 1;
    }

    return ans;
}
