// See https://aka.ms/new-console-template for more information
using System.Globalization;

Console.WriteLine("Program One");


using StreamReader reader = new("input1.txt");

string? text = reader.ReadLine();
var ans = 0;


while (text != null)
{
    ans = ans + text.Split(",").Select(int.Parse).ToList()[0] * text.Split(",").Select(int.Parse).ToList()[1];

    text = reader.ReadLine();

}

Console.WriteLine(ans);