// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Formats.Asn1;
using System.Text;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Program One");


        using StreamReader reader = new("input1.txt");

        var ans = 0;
        string? text = reader.ReadLine();
        while (text != null)
        {
            var list = text.Split(" ").Select(int.Parse).ToList();
            var safe = checkList(list);
            if (safe)
            {
                ans++;
            }
            else
            {
                // Do some fun, basically the same thing again!

                for (int i = 0; i < list.Count(); i++)
                {
                    int val = list[i];
                    list.RemoveAt(i);
                    safe = checkList(list);
                    if (safe) break;
                    list.Insert(i, val);
                }

                if (safe)
                {
                    ans++;
                }

            }

            text = reader.ReadLine();

        }

        Console.WriteLine(ans);

    }
    public static bool checkList(List<int> list)
    {
        var safe = true;
        var asc = list[0] - list[1] < 0;
        for (int i = 1; i < list.Count(); i++)
        {
            var movement = list[i - 1] - list[i];
            if (movement == 0)
            {
                safe = false;
            }
            if (asc)
            {
                if (movement > -1 | movement < -3)
                {
                    safe = false;
                }
            }
            if (!asc)
            {
                if (movement < 1 | movement > 3)
                {
                    safe = false;
                }
            }

        }
        return safe;

    }

}



