// See https://aka.ms/new-console-template for more information
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

Console.WriteLine("Program One");


using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();

List<string> input = new List<string>();

while (line != null)
{
    input.AddRange(line.Split(','));
    line = reader.ReadLine();

}


//Console.WriteLine(SolvePartOne(input));
Console.WriteLine(SolvePartTwo(input));
static long SolvePartOne(List<string> instructuions)
{
    long ans = 0;

    foreach (string item in instructuions)
    {
        //Console.WriteLine(item);
        var a = item.Split("-")[0];
        var b = item.Split("-")[1];

        for (long i = long.Parse(a); i <= long.Parse(b); i++)
        {
            if (i.ToString().Substring(0, i.ToString().Length / 2) == i.ToString().Substring(i.ToString().Length / 2))
            {
                ans += i;
            }
        }
    }


    return ans;
}

static long SolvePartTwo(List<string> instructuions)
{
    long ans = 0;

    foreach (string item in instructuions)
    {
        //Console.WriteLine(item);
        var a = item.Split("-")[0];
        var b = item.Split("-")[1];

        for (long i = long.Parse(a); i <= long.Parse(b); i++)
        {
            if (i.ToString().Substring(0, i.ToString().Length / 2) == i.ToString().Substring(i.ToString().Length / 2))
            {
                Console.WriteLine(i);

                ans += i;
            }
            else
            {
                //find what length is divisible by
                var remainder = 2;
                //determine if all sequences of this are the same
                while (remainder <= i.ToString().Length)
                {
                    var matches = Regex.Matches(i.ToString(), i.ToString().Substring(0, i.ToString().Length / remainder));
                    if (matches.Count == remainder)
                    {
                        if (matches.Count * i.ToString().Substring(0, i.ToString().Length / remainder).Length == i.ToString().Length)
                        {
                            Console.WriteLine(i);
                            ans += i;
                            break;
                        }
                    }
                    remainder++;
                }
            }
        }
    }

    return ans;
}
