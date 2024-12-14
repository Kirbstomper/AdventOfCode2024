// See https://aka.ms/new-console-template for more information
using System.Numerics;
using System.Runtime.InteropServices;

Console.WriteLine("Program One");
Vector2 roomSize = new Vector2 { X = 101, Y = 103 };
var quads = new int[] { 0, 0, 0, 0 };

using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();
while (line != null)
{

    var rob_parse = line.Split(",").Select(int.Parse).ToArray();

    Robot r = new Robot { Pos = new Vector2 { X = rob_parse[0], Y = rob_parse[1] }, Vel = new Vector2 { X = rob_parse[2], Y = rob_parse[3] } };
    calc_pos(r, 100, roomSize);
    if (r.Pos.X < (int)(roomSize.X / 2))
    {
        if (r.Pos.Y < (int)(roomSize.Y / 2))
        {
            quads[0]++;
        }
        if (r.Pos.Y > (int)(roomSize.Y / 2))
        {
            quads[1]++;
        }

    }
    if (r.Pos.X > (int)(roomSize.X / 2))
    {
        if (r.Pos.Y < (int)(roomSize.Y / 2))
        {
            quads[2]++;
        }
        if (r.Pos.Y > (int)(roomSize.Y / 2))
        {
            quads[3]++;
        }

    }

    line = reader.ReadLine();

}
Console.WriteLine(quads[0] * quads[1] * quads[2] * quads[3]);

static void calc_pos(Robot r, int secs, Vector2 roomSize)
{
    var moved_x = r.Vel.X * secs;
    var moved_y = r.Vel.Y * secs;


    r.Pos.X = mod((int)(r.Pos.X + moved_x), (int)roomSize.X);


    r.Pos.Y = mod((int)(r.Pos.Y + moved_y), (int)roomSize.Y);

}
static int mod(int x, int m)
{
    return (x % m + m) % m;
}
class Robot
{
    public Vector2 Pos = new Vector2 { X = 1, Y = 2 };
    public Vector2 Vel = new Vector2 { X = 1, Y = 2 };

}

