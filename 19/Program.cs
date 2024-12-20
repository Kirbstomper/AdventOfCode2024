// See https://aka.ms/new-console-template for more information
using System.Numerics;

Console.WriteLine("Program One");


using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();
var opts = new HashSet<string>(line.Split(", "));
var seen = new Dictionary<string, long>();
line = reader.ReadLine();
line = reader.ReadLine();
BigInteger ans = 0;
while (line != null)
{
    seen.Clear();
    var val = solve(line, opts);
    Console.WriteLine(val);
    ans += val;
    line = reader.ReadLine();

}
Console.WriteLine(ans);


long solve(string target, HashSet<string> options)
{
    if (seen.ContainsKey(target))
    {
        return seen[target];
    }
    long possible = 0;

    if (options.Contains(target))
    {
        possible += 1;
    }
    for (int i = 1; i < target.Length; i++)
    {
        var sub = target.Substring(0, i);
        if (options.Contains(sub))
        {

            possible += solve(target.Substring(i), options);

        }

    }
    seen.Add(target, possible);
    return possible;
}