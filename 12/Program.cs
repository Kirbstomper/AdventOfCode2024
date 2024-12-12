// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Runtime.InteropServices.Marshalling;

Console.WriteLine("Program One");

using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();

List<List<string>> field = new List<List<string>>();
while (line != null)
{

    field.Add(line.ToList().Select(d => d + "").ToList());

    line = reader.ReadLine();
}

Dictionary<string, int> plots = new Dictionary<string, int>();
var ans = 0;
for (int r = 0; r < field.Count; r++)
{
    for (int c = 0; c < field[r].Count; c++)
    {
        var f = field[r][c];

        if (f.Contains("*"))
        {
            continue;
        }
        plots[f] = 0;
        var size = flood(field, r, c, f);
        ans += plots[f] * size;
        Console.WriteLine("key: " + f + "  val: " +plots[f] * size );
    
    }


}


Console.WriteLine(ans);
 int flood(List<List<string>> field, int r, int c, string f)
{
    plots[f]++;
    var toAdd = 4;//4 side by default
                 
                 
    
                  //Check if anything above
    field[r][c] = f + "*";

    if (r != 0)
    {
        if (field[r - 1][c].Contains(f))
        {
            toAdd--;
            if (field[r - 1][c] == f)
            {

                toAdd += flood(field, r - 1, c, f);
            }
        }
    }

    //check below
    if (r != field.Count - 1)
    {
        if (field[r + 1][c].Contains(f))
        {
            toAdd--;
            if (field[r + 1][c] == f)
            {
                toAdd += flood(field, r + 1, c, f);
            }

        }
    }

    //check left
    if (c != 0)
    {

        if (field[r][c - 1].Contains(f))
        {
                    toAdd--;

            if (field[r][c - 1] == f)
            {
                toAdd += flood(field, r, c - 1, f);
            }
        }
    }

    //check right
    if (c != field[r].Count - 1)
    {
        if (field[r][c + 1].Contains(f))
        {
            toAdd--;
            if (field[r][c + 1] == f)
            {
                toAdd += flood(field, r, c + 1, f);
            }
        }
    }

    return toAdd;

}