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

        if (lines[r][c] == 'X' || lines[r][c] == 'S')
        {
            //Lines
            try
            {
                var test = new string([lines[r][c], lines[r][c + 1], lines[r][c + 2], lines[r][c + 3]]);
                if (test == XMAS || test == BACKWARDS)
                {
                    ans++;
                }

            }
            catch
            {


            }
            //Diag
            try
            {
                var test = new string([lines[r][c], lines[r - 1][c + 1], lines[r - 2][c + 2], lines[r - 3][c + 3]]);
                if (test == XMAS || test == BACKWARDS)
                {
                    ans++;
                }
            }
            catch
            {


            }
            try
            {
                var test = new string([lines[r][c], lines[r + 1][c + 1], lines[r + 2][c + 2], lines[r + 3][c + 3]]);
                if (test == XMAS || test == BACKWARDS)
                {
                    ans++;
                }
            }
            catch
            {


            }

            //Up and down

            try
            {
                var test = new string([lines[r][c], lines[r + 1][c], lines[r + 2][c], lines[r + 3][c]]);
                if (test == XMAS || test == BACKWARDS)
                {
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
