// See https://aka.ms/new-console-template for more information
using System.Collections.ObjectModel;
using System.Numerics;
using System.Runtime.InteropServices;

Console.WriteLine("Program One");
Vector2 roomSize = new Vector2 { X = 101, Y = 103 };
var quads = new int[] { 0, 0, 0, 0 };
var seconds = 0;
using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();

List<Robot> robots = new List<Robot>();
while (line != null)
{

    var rob_parse = line.Split(",").Select(int.Parse).ToArray();

    Robot r = new Robot { Pos = new Vector2 { X = rob_parse[0], Y = rob_parse[1] }, Vel = new Vector2 { X = rob_parse[2], Y = rob_parse[3] } };
    robots.Add(r);
    line = reader.ReadLine();

}

//part 1()

Console.WriteLine("p1: " + danger_level(robots, roomSize, 100, new List<Vector2>()));
var lowest = int.MaxValue;
while (true)
{
    var new_robs = new List<Vector2>();
    var d_level = danger_level(robots, roomSize, seconds, new_robs);
    seconds++;
    if (lowest > d_level)
    {
        lowest = d_level;
        Console.WriteLine(lowest);
        Console.WriteLine(seconds);
        //Print the grid to console to see
        printGrid(new_robs, roomSize);

    }

}


//get danger level

static int danger_level(List<Robot> r_list, Vector2 roomSize, int seconds, List<Vector2> newRob)
{
    var quads = new int[] { 0, 0, 0, 0 };

    foreach (var rob in r_list)
    {
        var r = calc_pos(rob, seconds, roomSize);
        newRob.Add(r);
        if (r.X < (int)(roomSize.X / 2))
        {
            if (r.Y < (int)(roomSize.Y / 2))
            {
                quads[0]++;
            }
            if (r.Y > (int)(roomSize.Y / 2))
            {
                quads[1]++;
            }

        }
        if (r.X > (int)(roomSize.X / 2))
        {
            if (r.Y < (int)(roomSize.Y / 2))
            {
                quads[2]++;
            }
            if (r.Y > (int)(roomSize.Y / 2))
            {
                quads[3]++;
            }

        }

    }
    var ans = quads[0] * quads[1] * quads[2] * quads[3];
    return ans;

}

static Vector2 calc_pos(Robot r, int secs, Vector2 roomSize)
{
    var moved_x = r.Vel.X * secs;
    var moved_y = r.Vel.Y * secs;


    return new Vector2(mod((int)(r.Pos.X + moved_x), (int)roomSize.X), mod((int)(r.Pos.Y + moved_y), (int)roomSize.Y));

}
static int mod(int x, int m)
{
    return (x % m + m) % m;
}


static void printGrid(List<Vector2> points, Vector2 room)
{
    char[,] grid = new char[(int)room.X, (int)room.Y];
    for (int x = 0; x < (int)room.X; x++)
    {
        for (int y = 0; y < (int)room.Y; y++)
        {
            grid[x, y] = '.';
        }
    }
    foreach (var p in points)
    {
        grid[(int)p.X, (int)p.Y] = '*';
    }

    for (int y = 0; y < (int)room.Y; y++)
    {
        for (int x = 0; x < (int)room.X; x++)
        {
            Console.Write(grid[x, y]);
        }
        Console.WriteLine();
    }

    Console.WriteLine();
    Console.WriteLine();

}
class Robot
{
    public Vector2 Pos = new Vector2 { X = 1, Y = 2 };
    public Vector2 Vel = new Vector2 { X = 1, Y = 2 };

}

