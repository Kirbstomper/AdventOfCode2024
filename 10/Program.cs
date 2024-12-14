// See https://aka.ms/new-console-template for more information
using System.Net.WebSockets;

Console.WriteLine("Day 10");


using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();

var map = new List<List<int>>();
while (line != null)
{
    map.Add(line.ToList().Select(s => s + "").Select(int.Parse).ToList());
    line = reader.ReadLine();

}

var trailheads = new List<Point>();
var mapped_points = new Point[map.Count, map[0].Count];
for (int x = 0; x < map.Count; x++)
{
    for (int y = 0; y < map[x].Count; y++)
    {
        Point p = new Point { Val = map[x][y], others = new List<Point>() };
        mapped_points[y, x] = p;
    }
}

for (int x = 0; x < map.Count; x++)
{
    for (int y = 0; y < map[x].Count; y++)
    {
        var p = mapped_points[x, y];
        if (p.Val == 0)
        {
            trailheads.Add(p);
        }

        try
        {
            if (mapped_points[x + 1, y].Val == p.Val + 1)
            {
                p.others.Add(mapped_points[x + 1, y]);
            }
        }
        catch { }
        try
        {
            if (mapped_points[x - 1, y].Val == p.Val + 1)
            {
                p.others.Add(mapped_points[x - 1, y]);

            }
        }
        catch { }
        try
        {
            if (mapped_points[x, y + 1].Val == p.Val + 1)
            {
                p.others.Add(mapped_points[x, y + 1]);

            }
        }
        catch { }
        try
        {
            if (mapped_points[x, y - 1].Val == p.Val + 1)
            {
                p.others.Add(mapped_points[x, y - 1]);

            }
        }
        catch { }
    }
}

//Console.WriteLine(trailheads.Count);
//Console.WriteLine(find_score(trailheads[0]));
//Console.WriteLine(trailheads[0].others.Count);
var ans1 = 0;
var ans2 = 0;

foreach (var t in trailheads)
{
    ans2 += find_score_p2(t);
    ans1 += find_score(t, new List<Point>());

}
Console.WriteLine("P1 ans: " + ans1);
Console.WriteLine("P2 ans: " + ans2);

static int find_score(Point p, List<Point> seen)
{
    var score = 0;
    if (p.Val == 9 && !seen.Contains(p))
    {
        seen.Add(p);
        return 1;
    }
    foreach (var o in p.others)
    {
        score += find_score(o, seen);
    }

    return score;

}
static int find_score_p2(Point p)
{
    var score = 0;
    if (p.Val == 9)
    {
        return 1;
    }
    foreach (var o in p.others)
    {
        score += find_score_p2(o);
    }

    return score;

}
class Point
{

    public int Val;
    public List<Point> others;

}