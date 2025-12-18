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
//Console.WriteLine(SolvePartTwo(input));
SolvePartTwo(input);

static int SolvePartOne(List<string> instructuions)
{
    var index = 50;
    var ans = 0;

    foreach (string item in instructuions)
    {
        var movement = int.Parse(item.Substring(1)) * (item.Substring(0, 1) == "L" ? -1 : 1);
        var newPos = index + movement;
        index = newPos % 100;
        if (index == 0)
        {
            ans++;
        }
    }


    return ans;
}

static int SolvePartTwo(List<string> instructuions)
{
    var index = 50;
    var ans = 0;

    foreach (string item in instructuions)
    {
        var movement = int.Parse(item.Substring(1)) * (item.Substring(0, 1) == "L" ? -1 : 1);
        var newPos = index + movement;
        var oldPos = index;
        newPos = newPos % 100;

        if (newPos < 0)
        {
            newPos = 100 + newPos;
        }

        index = newPos;
        var rotations = Math.Abs(movement) / 100;
        ans += rotations;

        var trueMove = (Math.Abs(movement) - rotations * 100);
        //Given movement was positive
        if (movement > 0)
        {
            if (oldPos + trueMove > 100 && oldPos > newPos)
            {
                ans++;
            }

        }
        if (movement < 0)
        {

            if (oldPos - trueMove < 0 && oldPos != 0)
            {
                ans++;
            }
        }

        if (newPos == 0) ans++;
        Console.WriteLine(index);
        Console.WriteLine("Answer Currently: " + ans);
    }


    return ans;
}