// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

Console.WriteLine("Program One");

using StreamReader reader = new("input1.txt");

var stage2 = false;

string? line = reader.ReadLine();

HashSet<string> set = new HashSet<string>();
var ans = 0;
while (line != null)
{   
    if (!stage2) {
        var split = line.Split("|");
        set.Add(split[0]+split[1]);
     }
    else {
        var goodLine = true;
        var split = line.Split(",").ToList();
        for(int i = 1; i<split.Count(); i++ ){
            for(int j =0; j<i; j++){
                if(set.Contains(split[i]+split[j])){
                    goodLine = false;
                    var temp = split[i];
                    split.RemoveAt(i);
                    Console.WriteLine(temp);
                    split.Insert(j, temp);
                }
            }
        }
        if(!goodLine){
    
            ans += int.Parse(split[(split.Count)/2 ]);
        }

     }

    line = reader.ReadLine();
    if (line == "")
    {
        Console.WriteLine("stage 2");
        stage2 = true;
        line = reader.ReadLine();
    }
}
Console.WriteLine(set.Count);
Console.WriteLine(ans);