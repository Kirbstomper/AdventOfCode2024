// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
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

var sw = new Stopwatch();

sw.Start();
Console.WriteLine(SolvePartOne(input));
Console.WriteLine(SolvePartTwo(input));
sw.Stop();
Console.WriteLine("Time: " + sw.ElapsedMilliseconds + "ms");

static BigInteger SolvePartOne(List<string> instructuions)
{
    BigInteger ans = 0;
    var drops = new Dictionary<int, int>(); // dict of splits
                                            //Initialize drops

    for (int x = 0; x < instructuions[0].Count(); x++)
    {
        drops[x] = 0;
    }
    foreach (string item in instructuions)
    {
        for (int i = 0; i < item.Length; i++)
        {
            if (item[i] == 'S')
            {
                drops[i]++; //start
            }
            if (item[i] == '^')
            {
                if (drops[i] > 0)
                {
                    ans++;
                    drops[i]--;
                    drops[i - 1] = 1;
                    drops[i + 1] = 1;
                }
            }
        }

    }


    return ans;
}

static BigInteger SolvePartTwo(List<string> instructuions)
{
    BigInteger ans = 0;
    var drops = new Dictionary<int, BigInteger>(); // dict of splits
                                                   //Initialize drops

    for (int x = 0; x < instructuions[0].Count(); x++)
    {
        drops[x] = 0;
    }
    foreach (string item in instructuions)
    {
        for (int i = 0; i < item.Length; i++)
        {
            if (item[i] == 'S')
            {
                drops[i]++; //start
            }
            if (item[i] == '^')
            {
                if (drops[i] > 0)
                {
                    //   ans += (1 * drops[i]); //For each previous one a timeline split occurs?
                    drops[i - 1] += drops[i];
                    drops[i + 1] += drops[i];
                    drops[i] = 0; //future secureed
                }
            }
        }
    }
    foreach (var item in drops)
    {
        ans += item.Value;
    }
    return ans;
}
