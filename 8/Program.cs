// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.VisualBasic;

Console.WriteLine("Day Eight");

using StreamReader reader = new("input.txt");
Dictionary<char, List<(int, int)>> ants = new Dictionary<char, List<(int, int)>>(); //Map of anttenae pos
HashSet<(int, int)> nodes = new HashSet<(int, int)>(); //map of annode pos
string? line = reader.ReadLine();
int xbound = line.Length;
int ybound = 0;

while (line != null)
{
    //adding to the map values
    var split = line.Trim().Select(c => c).ToList();
    for (int i = 0; i < split.Count; i++)
    {
        char c = split[i];
        if (c != '.')
        {
            if (!ants.ContainsKey(c))
            {
                ants[c] = new List<(int, int)>();
            }
            ants[c].Add((i, ybound));
        }
    }
    ybound += 1;

    line = reader.ReadLine();
}

//Calculate nodes

foreach (char x in ants.Keys)
{
    //Nested for loop, calculate ant
    Console.WriteLine(ants[x].Count);
    ants[x].ForEach(x => Console.WriteLine(x));

    for (int a = 0; a < ants[x].Count; a++)
    {
        if (ants[x].Count == 1)
            break;
        for (int otherA = 1; otherA < ants[x].Count; otherA++)
        {
            Console.WriteLine("pair: " + ants[x][a] + " || " + ants[x][otherA]);

            //Calculate the annode
            var xdiff = ants[x][a].Item1 - ants[x][otherA].Item1;
            var ydiff = ants[x][a].Item2 - ants[x][otherA].Item2;

            for(int i = 1; i<1000; i++){
            nodes.Add((ants[x][a].Item1 + xdiff*i, ants[x][a].Item2 + ydiff*i));
            nodes.Add((ants[x][otherA].Item1 - xdiff*i, ants[x][otherA].Item2 - ydiff*i));
            nodes.Add((ants[x][a].Item1 - xdiff*i, ants[x][a].Item2 - ydiff*i));
            nodes.Add((ants[x][otherA].Item1 + xdiff*i, ants[x][otherA].Item2 + ydiff*i));
            }
            nodes.Add((ants[x][a].Item1 + xdiff, ants[x][a].Item2 + ydiff));
            nodes.Add((ants[x][otherA].Item1 - xdiff, ants[x][otherA].Item2 - ydiff));

             nodes.Add((ants[x][a].Item1 + xdiff*2, ants[x][a].Item2 + ydiff*2));
            nodes.Add((ants[x][otherA].Item1 - xdiff*2, ants[x][otherA].Item2 - ydiff*2));

              nodes.Add((ants[x][a].Item1 + xdiff*3, ants[x][a].Item2 + ydiff*3));
            nodes.Add((ants[x][otherA].Item1 - xdiff*3, ants[x][otherA].Item2 - ydiff*3));
        }

        ants[x].Remove(ants[x][a]);
        a--;
    }
}
var ans = 0;

using StreamReader reader2 = new("input_text.txt");
line = reader2.ReadLine();
int y = 0;
HashSet<(int, int)> test = new HashSet<(int, int)>(); //map of annode pos

while (line != null)
{
    var split = line.Trim().Select(c => c).ToList();
    for (int i = 0; i < split.Count; i++)
    {
        char c = split[i];
        if (c != '.')
        {
            test.Add((i, y));
        }
    }
    y++;
   // Console.WriteLine("line:" +y);
    line = reader2.ReadLine();
    //Console.WriteLine(line);
}

//Count the nodes within map bounds
foreach ((int, int) a in nodes)
{   
    if (a.Item1 >= 0 && a.Item1 < xbound && a.Item2 >= 0 && a.Item2 < ybound)
    {
        
    ans++;
        
    }
}

test.ToList().ForEach(x => Console.WriteLine(x));
Console.WriteLine(ans);