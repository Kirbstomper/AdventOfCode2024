// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Numerics;
using System.Xml.Serialization;

Console.WriteLine("Day  18");


using StreamReader reader = new("input.txt");

var grid = new string[70, 70];
//Dictionary<int, char[,]> map = new Dictionary<int, char[,]>();
var size = 71;
var map = initMap(new char[size, size]);

var line = reader.ReadLine();
List<(int, int)> lines = new List<(int, int)>();
while (line != null)
{
    var input = line.Split(",").Select(int.Parse).ToList();
    lines.Add((input[0], input[1]));

    line = reader.ReadLine();
}

var solved = solve();
for (int i = 0; i < lines.Count; i++)
{
    var inp = lines[i];
    Console.WriteLine(solved);

    Console.WriteLine(inp);
    map[inp.Item1, inp.Item2] = '#';
    if (solved.ToList().Where(n => n.Pos.X == inp.Item1 && n.Pos.Y == inp.Item2).Count() > 0)
    {
        Console.WriteLine("Asss");
        solved = solve();
        if (solved.Length == 0)
        {
            Console.WriteLine("FUCK");
            Console.WriteLine(inp);
            break;
        };

    }


}


Node[] solve()
{
    var nodes = new List<Node>();
    for (int r = 0; r < size; r++)
    {
        for (int c = 0; c < size; c++)
        {
            if (map[r, c] == '.')
            {
                var n = new Node(new Vector2 { X = r, Y = c }, new List<Node>());
                nodes.Add(n);
            }
        }
    }
    Node start = null;
    Node end = null;

    foreach (Node n in nodes)
    {
        if (n.Pos.X == 0 && n.Pos.Y == 0)
            start = n;

        if (n.Pos.X == size - 1 && n.Pos.Y == size - 1)
            end = n;


        var down = nodes.Find(other => n.Pos.X == other.Pos.X && n.Pos.Y + 1 == other.Pos.Y);
        var up = nodes.Find(other => n.Pos.X == other.Pos.X && n.Pos.Y - 1 == other.Pos.Y);
        var left = nodes.Find(other => n.Pos.X - 1 == other.Pos.X && n.Pos.Y == other.Pos.Y);
        var right = nodes.Find(other => n.Pos.X + 1 == other.Pos.X && n.Pos.Y == other.Pos.Y);

        if (down != null)
        {
            n.Neighbors.Add(down);
        }
        if (up != null)
        {
            n.Neighbors.Add(up);
        }
        if (left != null)
        {
            n.Neighbors.Add(left);
        }
        if (right != null)
        {
            n.Neighbors.Add(right);
        }

        // Console.WriteLine(n.Neighbors.Count);
    }



    var ans = findPath(start, end);
    Console.WriteLine(ans.Length - 1);
    Console.Write("Start " + start.Pos.ToString());
    Console.Write("END " + end.Pos.ToString());
    return ans;

}
Node[] findPath(Node start, Node end)
{
    HashSet<Node> visited = new HashSet<Node>();
    Queue<(Node, Node[])> queue = new Queue<(Node, Node[])>();
    queue.Enqueue((start, []));

    while (queue.Count > 0)
    {
        var itt = queue.Dequeue();
        itt.Item2 = itt.Item2.Append(itt.Item1).ToArray();
        //Console.WriteLine(itt.Item1.Pos.X + " , " + itt.Item1.Pos.Y);
        visited.Add(itt.Item1);

        if (itt.Item1 == end)
            return itt.Item2;

        foreach (Node n in itt.Item1.Neighbors)
        {
            if (!visited.Contains(n))
            {
                //   Console.WriteLine(visited.Count);
                queue.Enqueue((n, itt.Item2));
                visited.Add(n);
            }
        }

    }

    return [];
}

char[,] initMap(char[,] arr)
{
    for (int r = 0; r < arr.GetLength(0); r++)
    {
        for (int c = 0; c < arr.GetLength(1); c++)
        {
            arr[r, c] = '.';
        }

    }
    return arr;
}


class Node(Vector2 Pos, List<Node> Neighbors)
{
    public Vector2 Pos = Pos;
    public List<Node> Neighbors = Neighbors;
}



