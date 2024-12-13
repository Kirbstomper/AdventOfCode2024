// See https://aka.ms/new-console-template for more information


Console.WriteLine("Program One");

using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();

List<List<string>> field = new List<List<string>>();
while (line != null)
{

    field.Add(line.ToList().Select(d => d + "").ToList());

    line = reader.ReadLine();
}

Dictionary<string, int> plots = new Dictionary<string, int>();
var ans = 0;
List<(int, int)> edges = new List<(int, int)>();
List<(int, int)> area = new List<(int, int)>();

for (int r = 0; r < field.Count; r++)
{
    for (int c = 0; c < field[r].Count; c++)
    {
        var f = field[r][c];
        edges.Clear();
        area.Clear();

        if (f.Contains("*"))
        {
            continue;
        }
        plots[f] = 0;
        var size = flood(field, r, c, f);

        var sidez = sides(edges, f);
   //Finally lets ends this shitsfas
        foreach (var p in area)
        {
            if (area.Contains((p.Item1 + 1, p.Item2 + 1)))
            {
                //nothing to right
                //nothing to below
                if (!area.Contains((p.Item1 + 1, p.Item2)) && !area.Contains((p.Item1, p.Item2 + 1)))
                {
                    sidez++;
                    sidez++;
                }
            }
             if (area.Contains((p.Item1 + 1, p.Item2 - 1)))
            {
                //nothing to left
                //nothing to below
                if (!area.Contains((p.Item1 + 1, p.Item2)) && !area.Contains((p.Item1, p.Item2 - 1)))
                {
                    sidez++;
                    sidez++;
                }
            }
        }
        ans += plots[f] * sidez;


     
        Console.WriteLine("key: " + f + "  val: " + sidez);

    }


}
Console.WriteLine(ans);

int sides(List<(int, int)> edges, string f)
{


    //if share a row thats a side! 
    HashSet<int> rows = new HashSet<int>();
    HashSet<int> cols = new HashSet<int>();

    //Count corners
    var corners = 0;
    foreach (var e in edges)
    {
        //Console.WriteLine(e);
        //check top left corner

        if (!edges.Contains((e.Item1 - 1, e.Item2 - 1)) && !area.Contains((e.Item1 - 1, e.Item2 - 1)))
        {
            if (!edges.Contains((e.Item1, e.Item2 - 1)) && !edges.Contains((e.Item1 - 1, e.Item2)))
            {


                corners++;
            }
        }
        //topRight corner


        if (!edges.Contains((e.Item1 - 1, e.Item2 + 1)) && !area.Contains((e.Item1 - 1, e.Item2 + 1)))
        {
            if (!edges.Contains((e.Item1, e.Item2 + 1)) && !edges.Contains((e.Item1 - 1, e.Item2)))
            {
                corners++;
            }
        }

        //bottom left
        if (!edges.Contains((e.Item1 + 1, e.Item2 - 1)) && !area.Contains((e.Item1 + 1, e.Item2 - 1)))
        {
            if (!edges.Contains((e.Item1, e.Item2 - 1)) && !edges.Contains((e.Item1 + 1, e.Item2)))
            {
                corners++;
            }
        }


        //bottom right
        if (!edges.Contains((e.Item1 + 1, e.Item2 + 1)) && !area.Contains((e.Item1 + 1, e.Item2 + 1)))
        {
            if (!edges.Contains((e.Item1, e.Item2 + 1)) && !edges.Contains((e.Item1 + 1, e.Item2)))
            {
                corners++;
            }
        }

        //Check if I am an intersection point?

        if (edges.Contains((e.Item1, e.Item2 - 1)) && edges.Contains((e.Item1 - 1, e.Item2)))
        {
            if (!edges.Contains((e.Item1 - 1, e.Item2 - 1)) && !area.Contains((e.Item1 - 1, e.Item2 - 1)))
            {
                corners++;
            }
        }
        //topRight corner
        if (edges.Contains((e.Item1, e.Item2 + 1)) && edges.Contains((e.Item1 - 1, e.Item2)))
        {
            if (!edges.Contains((e.Item1 - 1, e.Item2 + 1)) && !area.Contains((e.Item1 - 1, e.Item2 + 1)))
            {
                corners++;
            }
        }



        //bottom left
        if (edges.Contains((e.Item1, e.Item2 - 1)) && edges.Contains((e.Item1 + 1, e.Item2)))

        {
            if (!edges.Contains((e.Item1 + 1, e.Item2 - 1)) && !area.Contains((e.Item1 + 1, e.Item2 - 1)))

            {
                corners++;
            }
        }


        //bottom right
        if (edges.Contains((e.Item1, e.Item2 + 1)) && edges.Contains((e.Item1 + 1, e.Item2)))

        {
            if (!edges.Contains((e.Item1 + 1, e.Item2 + 1)) && !area.Contains((e.Item1 + 1, e.Item2 + 1)))

            {
                corners++;
            }
        }




    }
    return corners;
}


int flood(List<List<string>> field, int r, int c, string f)
{
    plots[f]++;
    var toAdd = 4;//4 side by default
    int surround = 0;

    area.Add((r, c));

    //Check if anything above
    field[r][c] = f + "*";

    if (r != 0)
    {
        if (field[r - 1][c].Contains(f))
        {
            toAdd--;
            if (field[r - 1][c] == f)
            {

                toAdd += flood(field, r - 1, c, f);
            }
        }
    }

    //check below
    if (r != field.Count - 1)
    {
        if (field[r + 1][c].Contains(f))
        {
            toAdd--;

            if (field[r + 1][c] == f)
            {
                toAdd += flood(field, r + 1, c, f);
            }

        }
    }

    //check left
    if (c != 0)
    {

        if (field[r][c - 1].Contains(f))
        {
            toAdd--;

            if (field[r][c - 1] == f)
            {
                toAdd += flood(field, r, c - 1, f);
            }
        }
    }

    //check right
    if (c != field[r].Count - 1)
    {
        if (field[r][c + 1].Contains(f))
        {
            toAdd--;

            if (field[r][c + 1] == f)
            {
                toAdd += flood(field, r, c + 1, f);
            }
        }
    }

    //check all around if surrounded
    for (int row = -1; row <= 1; row++)
    {
        for (int col = -1; col <= 1; col++)
        {

            if (row != 0 || col != 0)
            {
                try
                {
                    if (field[r + row][c + col].Contains(f))
                    {
                        surround++;
                    }
                }
                catch
                {

                }
            }
        }
    }

    if (surround < 8)
    {
        edges.Add((r, c));
    }
    return toAdd;

}

