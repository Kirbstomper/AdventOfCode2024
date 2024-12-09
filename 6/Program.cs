// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Drawing;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

Console.WriteLine("Program One");

using StreamReader reader = new("input.txt");
var visited = new HashSet<(int, int)>();
(int, int) pos = (0, 0);
(int, int) start_pos = (0, 0);

List<List<char>> map = new List<List<char>>();
var dir = 0; // 0=up  1=right 2=down 3=left

string? text = reader.ReadLine();

while (text != null)
{
    map.Add(text.ToList());
    if (text.Contains("^"))
    {
        pos = (text.IndexOf("^"), map.Count() - 1);
        start_pos = (text.IndexOf("^"), map.Count() - 1);
    }
    text = reader.ReadLine();
}

//Account for being here
visited.Add(pos);

//Walk the road. The witches road, while in the map!
while (pos.Item1 >= 0 && pos.Item1 < map[0].Count && pos.Item2 >= 0 && pos.Item2 < map.Count)
{
    visited.Add(pos);

    //Check in front
    if (dir == 0)
    {
        try
        {
            if (map[pos.Item2 - 1][pos.Item1] == '#')
            {
                dir = 1; //turn
            }
            else
            {
                pos = (pos.Item1, pos.Item2 - 1);
            }
        }
        catch
        {
            pos = (pos.Item1, pos.Item2 - 1);
        }
    }
    else if (dir == 1)
    {
        try
        {
            if (map[pos.Item2][pos.Item1 + 1] == '#')
            {
                dir = 2; //turn
            }
            else
            {
                pos = (pos.Item1 + 1, pos.Item2);
            }
        }
        catch
        {
            pos = (pos.Item1 + 1, pos.Item2);
        }
    }
    else if (dir == 2)
    {
        try
        {
            if (map[pos.Item2 + 1][pos.Item1] == '#')
            {
                dir = 3; //turn
            }
            else
            {
                pos = (pos.Item1, pos.Item2 + 1);
            }
        }
        catch
        {
            pos = (pos.Item1, pos.Item2 + 1);
        }
    }
    else if (dir == 3)
    {
        try
        {
            if (map[pos.Item2][pos.Item1 - 1] == '#')
            {
                dir = 0; //turn
            }
            else
            {
                pos = (pos.Item1 - 1, pos.Item2);
            }
        }
        catch
        {
            pos = (pos.Item1 - 1, pos.Item2);
        }
    }
}

//Using list of squares visited, lets create a map..diffrent each time


var ans = 0;
visited
    .ToList()
    .ForEach(v =>
    {
        var looped = new HashSet<(int, int, int)>();
        pos = start_pos;
        var orig = map[v.Item2][v.Item1];
        if (orig == '.')
        {
            map[v.Item2][v.Item1] = '#';
            dir = 0;

            while (
                pos.Item1 >= 0
                && pos.Item1 < map[0].Count
                && pos.Item2 >= 0
                && pos.Item2 < map.Count
            )
            {
                if (!looped.Add((pos.Item1, pos.Item2, dir)))
                {
                    Console.WriteLine("WE LOOPED BITCH");
                    ans++;
                    break;
                }

                //Check in front
                if (dir == 0)
                {
                    try
                    {
                        if (map[pos.Item2 - 1][pos.Item1] == '#')
                        {
                            dir = 1; //turn
                        }
                        else
                        {
                            pos = (pos.Item1, pos.Item2 - 1);
                        }
                    }
                    catch
                    {
                        pos = (pos.Item1, pos.Item2 - 1);
                    }
                }
                else if (dir == 1)
                {
                    try
                    {
                        if (map[pos.Item2][pos.Item1 + 1] == '#')
                        {
                            dir = 2; //turn
                        }
                        else
                        {
                            pos = (pos.Item1 + 1, pos.Item2);
                        }
                    }
                    catch
                    {
                        pos = (pos.Item1 + 1, pos.Item2);
                    }
                }
                else if (dir == 2)
                {
                    try
                    {
                        if (map[pos.Item2 + 1][pos.Item1] == '#')
                        {
                            dir = 3; //turn
                        }
                        else
                        {
                            pos = (pos.Item1, pos.Item2 + 1);
                        }
                    }
                    catch
                    {
                        pos = (pos.Item1, pos.Item2 + 1);
                    }
                }
                else if (dir == 3)
                {
                    try
                    {
                        if (map[pos.Item2][pos.Item1 - 1] == '#')
                        {
                            dir = 0; //turn
                        }
                        else
                        {
                            pos = (pos.Item1 - 1, pos.Item2);
                        }
                    }
                    catch
                    {
                        pos = (pos.Item1 - 1, pos.Item2);
                    }
                }
            }
            map[v.Item2][v.Item1] = orig;
        }
    });

Console.WriteLine(ans);
