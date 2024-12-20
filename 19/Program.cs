// See https://aka.ms/new-console-template for more information
Console.WriteLine("Program One");


using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();
var opts = line.Split(", ");
line = reader.ReadLine();
line = reader.ReadLine();
var ans = 0;
while (line != null)
{
    var val = solve(line, opts);
    Console.WriteLine(val);
    ans += val;
    line = reader.ReadLine();

}
Console.WriteLine(ans);


int solve(string target, string[] options)
{
    var possible = 0;
    if (options.Contains(target))
    {
        return 1;
    }
    for (int i = 1; i < target.Length; i++)
    {
        var sub = target.Substring(0, i);
        if (options.Contains(sub))
        {

            possible += solve(target.Substring(i), options);

        }

    }
    return possible;
}