// See https://aka.ms/new-console-template for more information
using System.Data;


Console.WriteLine("Program One");


using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();
long ans = 0;

while (line != null)
{

    var a_raw = reader.ReadLine().Split(",").Select(long.Parse).ToArray();
    var b_raw = reader.ReadLine().Split(",").Select(long.Parse).ToArray();
    var targ_raw = reader.ReadLine().Split(",").Select(long.Parse).ToArray();


    targ_raw[0] = targ_raw[0] + 10000000000000;
    targ_raw[1] = targ_raw[1] + 10000000000000;

    double y = (targ_raw[1] * (double)a_raw[0] - targ_raw[0] * (double)a_raw[1])
                    / (b_raw[1] * (double)a_raw[0] - b_raw[0] * (double)a_raw[1]);
    double x = (targ_raw[0] - y * b_raw[0]) / a_raw[0];
    
    Console.WriteLine(x);

    Console.WriteLine(y);

    if (double.IsInteger(x) && double.IsInteger(y))
    {
        Console.WriteLine("addin");
        ans += ((long)x * 3) + (long)y;
    }

    line = reader.ReadLine();

}
Console.WriteLine(ans);

// Get to row e

public record Button(long x, long y);
