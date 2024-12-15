﻿// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Runtime.InteropServices;

Console.WriteLine("Program One");


using StreamReader reader = new("input.txt");
var readingInput = false;
string? line = reader.ReadLine();
var inputs = "";
var map = new List<List<char>>();
var robot_pos = (24, 24);
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
        map.Add(line.ToList());
    }
    else
    {
        inputs = inputs + line;
        //add to input
    }

    line = reader.ReadLine();

}

Console.WriteLine(inputs);


//now move around

foreach (var i in inputs)
{
    move(map, i, robot_pos);


    Console.WriteLine();
    Console.WriteLine("map: ");


}

var ans = 0;

for (int y = 0; y < map.Count; y++)
{

    for (int x = 0; x < map.Count; x++)
    {
        if (map[y][x] == 'O')
        {
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

bool move(List<List<char>> map, char dir, (int, int) pos)
{
    var canMove = true;
    var delta_y = 0;
    var delta_x = 0;
    var isRobot = map[pos.Item1][pos.Item2] == '@';


    if (dir == '^')
    {
        if (pos.Item1 == 1)
        {

            return false;
        }
        delta_y = -1;
    }

    if (dir == 'v')
    {
        if (pos.Item1 == map.Count - 2)
        {
            return false;
        }
        delta_y = 1;
    }
    if (dir == '<')
    {
        if (pos.Item2 == 1)
        {

            return false;
        }
        delta_x = -1;
    }
    if (dir == '>')
    {
        if (pos.Item2 == map[0].Count - 2)
        {
            return false;
        }
        delta_x = 1;
    }


    if (map[pos.Item1 + delta_y][pos.Item2 + delta_x] == '#')
    {
        return false;
    }
    if (map[pos.Item1 + delta_y][pos.Item2 + delta_x] == 'O')
    {
        canMove = move(map, dir, (pos.Item1 + delta_y, pos.Item2 + delta_x));

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

//Print the output

//Calculate the end