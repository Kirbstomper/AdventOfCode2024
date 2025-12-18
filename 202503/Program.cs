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


//Console.WriteLine(SolvePartOne(input));
Console.WriteLine(SolvePartTwo(input));

static BigInteger SolvePartOne(List<string> instructuions)
{
    BigInteger ans = 0;

    foreach (string item in instructuions)
    {
        Console.WriteLine(item);
        var batteries = item.ToCharArray().Select(i => int.Parse(i.ToString())).ToList();
        var indexLow = 0;
        var indexHigh = batteries.Count - 1;

        for (int i = 0; i < batteries.Count() - 1; i++)
        {
            if (batteries[i] > batteries[indexLow])
            {
                indexLow = i;
            }
        }
        for (int i = indexLow + 1; i < batteries.Count() - 1; i++)
        {
            if (batteries[i] > batteries[indexHigh])
            {
                indexHigh = i;
            }
        }
        Console.WriteLine(batteries[indexLow] + "" + batteries[indexHigh]);
        ans += BigInteger.Parse((batteries[indexLow] + "" + batteries[indexHigh]));

    }


    return ans;
}

static BigInteger SolvePartTwo(List<string> instructuions)
{
    BigInteger ans = 0;
    foreach (string item in instructuions)
    {
        // Console.WriteLine(item);
        var batteries = item.ToCharArray().Select(i => int.Parse(i.ToString())).ToList();
        string final = "";
        var lastindex = 0;

        for (int b = 11; b >= 0; b--)
        {

            var currentIndex = lastindex;

            for (int i = lastindex; i < batteries.Count() - b; i++)
            {

                if (batteries[i] > batteries[currentIndex])
                {
                    currentIndex = i;
                }

            }
            lastindex = currentIndex + 1;
            final += batteries[currentIndex];

        }
        Console.WriteLine(final);
        ans += BigInteger.Parse(final);
    }
    return ans;

}