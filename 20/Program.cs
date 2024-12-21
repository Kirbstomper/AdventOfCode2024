// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Numerics;
using System.Transactions;

Console.WriteLine("Program One");


using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();
Node[,] nodes = new Node[line.Length, line.Length];

Dictionary<int, Dictionary<int, Node>> map = new Dictionary<int, Dictionary<int, Node>>();

for (int i = 0; i < line.Length; i++)
{
    map[i] = new Dictionary<int, Node>();
}
Node start = null;
Node end = null;
var y = 0;
var savings = 100;
var reachable = new List<Node>();
while (line != null)
{
    for (int i = 0; i < line.Length; i++)
    {
        char c = line[i];

        map[i][y] = new Node(c, i, y);
        if (c == 'S')
        {
            start = map[i][y];

        }
        if (c == 'E')
        {
            end = map[i][y];
        }
        if (c != '#')
        {
            reachable.Add(map[i][y]);
        }

    }
    y++;
    line = reader.ReadLine();

}

Console.WriteLine(setupPath(start, end, map));
var paths = new Dictionary<(Node, Node), int>();
var cheats = new HashSet<((int, int), (int, int))>();

var baseline = countPath(start, end, paths);
Console.WriteLine(cheat(start, map));


int setupPath(Node start, Node end, Dictionary<int, Dictionary<int, Node>> map)
{
    var last = start;
    var cur = start;
    var count = 0;
    while (cur != end)
    {
        count++;
        if (cur.X < map.Count())
            if (map[cur.X + 1][cur.Y].val != '#' && map[cur.X + 1][cur.Y] != last)
            {
                cur.next = map[cur.X + 1][cur.Y];
                last = cur;
                cur = cur.next;
                continue;
            }
        if (cur.X > 0)
            if (map[cur.X - 1][cur.Y].val != '#' && map[cur.X - 1][cur.Y] != last)
            {
                cur.next = map[cur.X - 1][cur.Y];
                last = cur;

                cur = cur.next;
                continue;
            }

        if (cur.Y < map.Count)
            if (map[cur.X][cur.Y + 1].val != '#' && map[cur.X][cur.Y + 1] != last)
            {
                cur.next = map[cur.X][cur.Y + 1];
                last = cur;

                cur = cur.next;
                continue;
            }
        if (cur.Y > 0)
            if (map[cur.X][cur.Y - 1].val != '#' && map[cur.X][cur.Y - 1] != last)
            {
                cur.next = map[cur.X][cur.Y - 1];
                last = cur;
                cur = cur.next;
                continue;
            }
    }

    return count;
}

long cheat(Node start, Dictionary<int, Dictionary<int, Node>> map)
{
    var ans = 0;

    foreach (Node node in reachable)
    {
        //YOu are counting points for manhattan distance wrong dumbby
        //Up
        var upTo = countPath(start, node, paths);


        for (int i = 0; i < 21; i++)
        {
            //1,1 to 3,7
            ans += countFrom(node, i, 0, upTo, map, paths);
            ans += countFrom(node, -i, 0, upTo, map, paths);
            ans += countFrom(node, 0, i, upTo, map, paths);
            ans += countFrom(node, 0, -i, upTo, map, paths);
            for (int x = 0; x < 21 - i; x++)
            {
                ans += countFrom(node, x, i, upTo, map, paths);
                ans += countFrom(node, -x, i, upTo, map, paths);
                ans += countFrom(node, -x, -i, upTo, map, paths);
                ans += countFrom(node, x, -i, upTo, map, paths);
            }

            ans += countFrom(node, i, 20 - i, upTo, map, paths);
            ans += countFrom(node, (-20 + i), i, upTo, map, paths);
            ans += countFrom(node, 20 - i, i, upTo, map, paths);
            ans += countFrom(node, i, (-20 + i), upTo, map, paths);

            ans += countFrom(node, -i, 20 - i, upTo, map, paths);
            ans += countFrom(node, (-20 + i), -i, upTo, map, paths);
            ans += countFrom(node, 20 - i, -i, upTo, map, paths);
            ans += countFrom(node, -i, (-20 + i), upTo, map, paths);
        }

        for (int i = 0; i < 11; i++)
        {
            //Diags
            ans += countFrom(node, i, i, upTo, map, paths);
            ans += countFrom(node, -i, i, upTo, map, paths);
            ans += countFrom(node, i, -i, upTo, map, paths);
            ans += countFrom(node, -i, -i, upTo, map, paths);

        }
    }

    //1,8 AND 1,9
    //1,7 is source

    Console.WriteLine(ans);
    return ans;
}



int countFrom(Node node, int X_delta, int Y_delta, int upTo, Dictionary<int, Dictionary<int, Node>> map, Dictionary<(Node, Node), int> paths)
{

    ///THIS IS BUSTED BECAUSE YOU ARE NOT ACCOUNTING FOR EVERY POINT. THERE ARE POINTS BETWEEN POINTS DUMBASS
    try
    {
        if (cheats.Contains(((node.X, node.Y), (node.X + X_delta, node.Y + Y_delta))))
        {
            return 0;
        }
        var amount = countPath(map[node.X + X_delta][node.Y + Y_delta], end, paths) + upTo + Math.Abs(X_delta) + Math.Abs(Y_delta);
        if (baseline - amount >= savings)
        {
            cheats.Add(((node.X, node.Y), (node.X + X_delta, node.Y + Y_delta)));
            Console.WriteLine(baseline - amount);
            return 1;
        }
    }
    catch { }
    return 0;
}
int countPath(Node n, Node e, Dictionary<(Node, Node), int> paths)
{
    if (paths.ContainsKey((n, e)))
    {
        return paths[(n, e)];
    }
    var visted = new HashSet<Node>();
    var count = 0;
    var cur = n;
    while (cur != null && cur != e)
    {
        if (!visted.Add(cur))
        {
            paths[(n, e)] = 10000;
            return 10000;
        }

        count++;
        cur = cur.next;
    }
    if (cur != e)
    {
        paths[(n, e)] = 100000;
        return 100000;
    }
    paths[(n, e)] = count;
    return count;
}

class Node(char val, int x, int y)
{
    public char val = val;
    public Node next;

    public int X = x;
    public int Y = y;

}

