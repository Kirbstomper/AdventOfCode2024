// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Data;
using System.Runtime;
using Microsoft.VisualBasic;

Console.WriteLine("Program One");


using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();
var ans = 0l;
while (line != null)
{

    var a_raw = reader.ReadLine().Split(",").Select(int.Parse).ToArray();
    var b_raw = reader.ReadLine().Split(",").Select(int.Parse).ToArray();
    var targ_raw = reader.ReadLine().Split(",").Select(int.Parse).ToArray();




    var a = new Button(a_raw[0], a_raw[1]);
    var b = new Button(b_raw[0], b_raw[1]);
    var target = new Button(targ_raw[0] + 10000000000000, targ_raw[1] + 10000000000000);

    var a_press = -1l;
    var b_press = -1l;

    for (int i = 0; i < 100000000; i++)
    {

        if (
            ((target.x - (i * b.x)) % a.x == 0) 
            && ((target.y - (i * b.y)) % a.y == 0)
            && ((target.y - (i * b.y)) >= 0)
            && ((target.x - (i * b.x)) >= 0)
            )
        {
            var maybe_a = (target.x - (i * b.x)) / a.x;
            Console.WriteLine((maybe_a * a.x ) + (i * b.x));

            if(maybe_a * a.x +  (i * b.x) == target.x && (maybe_a *a.y + (i * b.y)) == target.y){
            if (b_press == -1 )
            {
                b_press = i;
                a_press = (target.x - (i * b.x)) / a.x;
            }
            else
            {
                //Determine what is cheaper
                var old_cost = a_press * 3 + b_press * 1;
                var new_cost = (target.x - (i * b.x)) / a.x * 3 + i * 1;

                if (old_cost > new_cost)
                {
                    b_press = i;
                    a_press = (target.x - (i * b.x)) / a.x;
                }
            }
            }

        }

    }
    

if(b_press >= 0  ){
 var cost = a_press * 3 + b_press * 1;
    Console.WriteLine("A:" + a_press + " B: "+ b_press + "cost: "+ cost +"    :"+ targ_raw[0]);


    ans+=cost;


}
   
    line = reader.ReadLine();

}



Console.WriteLine(ans);

public record Button(long x, long y);