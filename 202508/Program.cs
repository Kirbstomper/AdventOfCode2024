// See https://aka.ms/new-console-template for more information
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

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
Console.WriteLine(SolvePartTwo(input));
static long SolvePartOne(List<string> instructuions)
{
    long ans = 0;
    List<Box> boxes = new List<Box>();
    int junct = 0;
    foreach (string item in instructuions)
    {
        var it = item.Split(",").Select(int.Parse).ToList();
        boxes.Add(new Box { X = it[0], Y = it[1], Z = it[2], junct = junct });
        junct++;
    }

    //Find  neighbor
    List<(Box, Box, double)> links = new List<(Box, Box, double)>();
    for (int i = 0; i < boxes.Count; i++)
    {
        Box neighbor = null;
        double dist = 0;
        for (int x = 0; x < boxes.Count; x++)
        {
            if (x == i)
            {
                continue;
            }
            if (neighbor == null)
            {
                neighbor = boxes[x];
                dist = CalcDistance(boxes[i], neighbor);
            }
            else
            {
                if (CalcDistance(boxes[i], boxes[x]) <= dist)
                {
                    neighbor = boxes[x];
                    dist = CalcDistance(boxes[i], neighbor);
                }
            }
        }

        links.Add((boxes[i], neighbor, dist));

        if (neighbor.junct != null)
        {
            boxes[i].junct = neighbor.junct;
        }
        else
        {
            boxes[i].junct = junct;
            neighbor.junct = junct;
            junct++;

        }
    }

    var curs = new Dictionary<Box, int?>();
    //loop through everything, get neighbor, if neighbor is on cuircuit? Join it
    // If not, create new circuit

    var curcount = 0;
    //De duplicate
    for (int i = 0; i < links.Count(); i++)
    {
        for (int x = 0; x < links.Count(); x++)
        {
            if (links[x].Item1 == links[i].Item2 && links[x].Item2 == links[i].Item1)
            {
                links.Remove(links[x]);
                i = 0;
                break;
            }
        }
    }
    links.Sort((n, o) => n.Item3.CompareTo(o.Item3));

    var count = 0;
    foreach (var item in links)
    {

        if (item.Item2.junct != null)
        {
            item.Item1.junct = item.Item2.junct;
        }
        else
        {
            item.Item1.junct = junct;
            item.Item2.junct = junct;
        }

        Console.WriteLine(item + "    " + item.Item1.junct);

        // Console.WriteLine(item.Item1.junct);
    }
    return ans;
}

static long SolvePartTwo(List<string> instructuions)
{
    long ans = 0;

    foreach (string item in instructuions)
    {

    }

    return ans;
}


static double CalcDistance(Box a, Box b)
{

    return (Math.Sqrt((Math.Pow((a.X - b.X), 2) + (Math.Pow((a.Y - b.Y), 2) + (Math.Pow((a.Z - b.Z), 2))))));
}
class Box()
{

    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public int? junct { get; set; }

    public override string ToString()
    {
        return $" {X}, {Y}, {Z}, {junct}";
    }
};
