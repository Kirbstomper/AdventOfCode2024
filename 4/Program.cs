// See https://aka.ms/new-console-template for more information
using System.Globalization;

Console.WriteLine("Day Four");


using StreamReader reader = new("input1.txt");

var ans = 0;
var XMAS = "XMAS";
var BACKWARDS = "SAMX";

var lines = new List<string>();
string? text = reader.ReadLine();

while (text != null)
{
    lines.Add(text);
    text = reader.ReadLine();

}


for (int r = 0; r < lines[0].Length; r++)
{

    for (int c = 0; c < lines[0].Length; c++)
    {

        if (lines[r][c] == 'A')
        {
            //Lines
            try
            {
                var test = new string([lines[r - 1][c - 1], lines[r][c], lines[r + 1][c + 1]]);
                if (test == "MAS" || test == "SAM")
                {
                    var test2 = new string([lines[r + 1][c - 1], lines[r][c], lines[r - 1][c + 1]]);
                    if (test2 == "SAM" || test2 == "MAS")
                        ans++;
                }


            }
            catch
            {


            }


        }
    }

}
Console.WriteLine(ans);
