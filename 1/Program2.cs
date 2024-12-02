// See https://aka.ms/new-console-template for more information
Console.WriteLine("Program Two");


using StreamReader reader = new("input1.txt");

string? text = reader.ReadLine();
var left = new List<int>();
var right = new List<int>();
while (text != null)
{
    var line = text.Split("   ");

    left.Add(int.Parse(line[0]));
    right.Add(int.Parse(line[1]));

    text = reader.ReadLine();
}

//Do something!
left.Sort();
right.Sort();

var answer = 0;
for (int i = 0; i < left.Count(); i++)
{
    for (int x = 0; x < right.Count(); x++)
    {
        if (right[x] == left[i])
            answer += left[i];
    }
}

Console.WriteLine(answer);