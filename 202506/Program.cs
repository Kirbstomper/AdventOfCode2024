// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

Console.WriteLine("Program One");


using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();

List<string> input = new List<string>();

while (line != null)
{
    input.Add(line);
    line = reader.ReadLine();

}

var stopWatch = new Stopwatch();
stopWatch.Start();
//Console.WriteLine(SolvePartOne(input));
Console.WriteLine(SolvePartTwo(input));
stopWatch.Stop();
Console.WriteLine("Total Time: " + stopWatch.ElapsedMilliseconds + "ms");

static long SolvePartOne(List<string> instructuions)
{
    long ans = 0;
    List<List<long>> nums = new List<List<long>>();
    foreach (string item in instructuions)
    {
        try
        {
            nums.Add(item.Split(" ").Select(x => long.Parse(x)).ToList());
        }
        catch
        {

        }

        /// do math

    }
    var signs = instructuions[instructuions.Count - 1].Split(" ");
    Console.WriteLine("COUNTING" + signs.Count());
    for (int i = 0; i < signs.Count(); i++)
    {
        var sign = instructuions[instructuions.Count - 1].Split(" ")[i];
        if (sign == "+")
        {
            Console.WriteLine("ADD");
            long adding = 0;
            for (int r = 0; r < nums.Count; r++)
            {
                adding += nums[r][i];
            }
            ans += adding;
        }
        if (sign == "*")
        {
            Console.WriteLine("mult");
            long multing = 1;
            for (int r = 0; r < nums.Count; r++)
            {
                multing *= nums[r][i];
            }
            ans += multing;
        }
    }
    return ans;
}

static BigInteger SolvePartTwo(List<string> instructuions)
{
    long ans = 0;


    //Now lets create the actual nums array
    List<List<long>> nums = new List<List<long>>();

    for (int i = 0; i < instructuions[0].Length; i++) //for each element in each equal string
    {
        var sign = instructuions[instructuions.Count - 1][i];
        if (sign == '+')
        {
            //Console.WriteLine("ADD");
            long adding = 0;
            while (true)
            {
                string temp = "";

                for (int x = 0; x < instructuions.Count - 1; x++)
                {
                    temp += instructuions[x][i];
                }
                //Console.WriteLine(temp);
                try
                {
                    adding += long.Parse(temp);
                    i++;
                }
                catch { break; }

                if (i > instructuions[0].Count() - 1) break;
            }
            ; //Until a character

            ans += adding;

        }
        if (sign == '*')
        {
           // Console.WriteLine("mult");
            long multing = 1;

            while (true)
            {
                string temp = "";

                for (int x = 0; x < instructuions.Count - 1; x++)
                {
                    temp += instructuions[x][i];
                }
               // Console.WriteLine(temp);

                try
                {
                    multing *= long.Parse(temp);
                    i++;
                }

                catch { break; }
                if (i > instructuions[0].Count() - 1) break;

            }
            //Until a character

            ans += multing;
        }
    }
    return ans;
}
