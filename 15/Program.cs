// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

Console.WriteLine("Program One");


using StreamReader reader = new("input.txt");
var readingInput = false;
string? line = reader.ReadLine();
var inputs = "";
var map = new List<List<char>>();
var robot_pos = (0, 0);
var lines = 0;
while (line != null)
{

    if (line.Length == 0)
    {
        readingInput = true;
        line = reader.ReadLine();
    }

    if (!readingInput)
    {
        //populate map
        map.Add(string.Join("", line.ToList().Select(c =>
        {
            if (c == '#')
                return "##";
            if (c == 'O')
                return "[]";
            if (c == '@')
                return "@.";
            return "..";
        }).ToList()).ToList());

        if (map[lines].Contains('@'))
        {
            robot_pos = (lines, map[lines].IndexOf('@'));
        }
        lines++;
    }
    else
    {
        inputs = inputs + line;
        //add to input
    }

    line = reader.ReadLine();

}

foreach (var l in map)
{
    l.ForEach(Console.Write);
    Console.WriteLine();
}
Console.WriteLine(inputs);


//now move around

foreach (var i in inputs)
{
    move(map, i, robot_pos);
}

var ans = 0;

for (int y = 0; y < map.Count; y++)
{

    for (int x = 0; x < map[y].Count; x++)
    {
        if (map[y][x] == '[')
        {
            var distFromEdge = x;
            // var len = map[y].Count;
            // //check closeness to edge 
            // if (x > (len / 2) + 1)
            // {
            //     distFromEdge = x + 1;
            // }

            Console.WriteLine((100 * y) + distFromEdge);
            ans += (100 * y) + x;
        }

    }

}
foreach (var l in map)
{
    l.ForEach(Console.Write);
    Console.WriteLine();
}
Console.WriteLine(ans);
Console.WriteLine(map.Count());
Console.WriteLine(map[0].Count);

bool move(List<List<char>> map, char dir, (int, int) pos)
{
    var canMove = true;
    var delta_y = 0;
    var delta_x = 0;
    var isRobot = map[pos.Item1][pos.Item2] == '@';


    if (dir == '^')
    {
        delta_y = -1;
    }

    if (dir == 'v')
    {

        delta_y = 1;
    }
    if (dir == '<')
    {

        delta_x = -1;
    }
    if (dir == '>')
    {

        delta_x = 1;
    }


    if (map[pos.Item1 + delta_y][pos.Item2 + delta_x] == '#')
    {
        return false;
    }
    if (map[pos.Item1 + delta_y][pos.Item2 + delta_x] == '[')
    {
        var boxMove = false;
        if (dir == '^' || dir == 'v')
        {
            //check if both boxes can move up [ then ]
            boxMove = check_move(map, dir, (pos.Item1 + delta_y, pos.Item2 + delta_x)) && check_move(map, dir, (pos.Item1 + delta_y, pos.Item2 + 1 + delta_x));
            if (boxMove)
            {
                move(map, dir, (pos.Item1 + delta_y, pos.Item2 + delta_x));
                move(map, dir, (pos.Item1 + delta_y, pos.Item2 + 1 + delta_x));
            }
            canMove = boxMove;
        }

        if (dir == '<' || dir == '>')
        {
            //move as normal basically?
            canMove = move(map, dir, (pos.Item1 + delta_y, pos.Item2 + delta_x));
        }


    }
    if (map[pos.Item1 + delta_y][pos.Item2 + delta_x] == ']')
    {
        var boxMove = false;
        if (dir == '^' || dir == 'v')
        {
            //check if both boxes can move up ] then [
            boxMove = check_move(map, dir, (pos.Item1 + delta_y, pos.Item2 + delta_x)) && check_move(map, dir, (pos.Item1 + delta_y, pos.Item2 - 1 + delta_x));
            if (boxMove)
            {
                move(map, dir, (pos.Item1 + delta_y, pos.Item2 + delta_x));
                move(map, dir, (pos.Item1 + delta_y, pos.Item2 - 1 + delta_x));
            }
            canMove = boxMove;
        }

        if (dir == '<' || dir == '>')
        {
            //move as normal basically?
            canMove = move(map, dir, (pos.Item1 + delta_y, pos.Item2 + delta_x));
        }


    }

    if (canMove)
    {
        //swap
        var temp = map[pos.Item1 + delta_y][pos.Item2 + delta_x];
        map[pos.Item1 + delta_y][pos.Item2 + delta_x] = map[pos.Item1][pos.Item2];
        map[pos.Item1][pos.Item2] = temp;

        if (isRobot)
        {
            robot_pos = (pos.Item1 + delta_y, pos.Item2 + delta_x);
        }
    }

    return canMove;
}


bool check_move(List<List<char>> map, char dir, (int, int) pos)
{
    var canMove = true;
    var delta_y = 0;
    var delta_x = 0;
    var isRobot = map[pos.Item1][pos.Item2] == '@';


    if (dir == '^')
    {
        delta_y = -1;
    }

    if (dir == 'v')
    {

        delta_y = 1;
    }
    if (dir == '<')
    {

        delta_x = -1;
    }
    if (dir == '>')
    {

        delta_x = 1;
    }


    if (map[pos.Item1 + delta_y][pos.Item2 + delta_x] == '#')
    {
        return false;
    }
    if (map[pos.Item1 + delta_y][pos.Item2 + delta_x] == '[')
    {
        var boxMove = false;
        if (dir == '^' || dir == 'v')
        {
            //check if both boxes can move up [ then ]
            boxMove = check_move(map, dir, (pos.Item1 + delta_y, pos.Item2 + delta_x)) && check_move(map, dir, (pos.Item1 + delta_y, pos.Item2 + 1 + delta_x));
            canMove = boxMove;
        }

        if (dir == '<' || dir == '>')
        {
            //move as normal basically?
            canMove = move(map, dir, (pos.Item1 + delta_y, pos.Item2 + delta_x));
        }


    }
    if (map[pos.Item1 + delta_y][pos.Item2 + delta_x] == ']')
    {
        var boxMove = false;
        if (dir == '^' || dir == 'v')
        {
            //check if both boxes can move up ] then [
            boxMove = check_move(map, dir, (pos.Item1 + delta_y, pos.Item2 + delta_x)) && check_move(map, dir, (pos.Item1 + delta_y, pos.Item2 - 1 + delta_x));

            canMove = boxMove;
        }

        if (dir == '<' || dir == '>')
        {
            //move as normal basically?
            canMove = move(map, dir, (pos.Item1 + delta_y, pos.Item2 + delta_x));
        }


    }

    return canMove;
}

//Print the output

//Calculate the end