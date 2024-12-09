// See https://aka.ms/new-console-template for more information
Console.WriteLine("Day nine");

using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();

int file = 0;
var encoded = new List<string>();

Dictionary<char, int> id_vals = new Dictionary<char, int>();
//Get hard drive
for (int i = 0; i < line.Length; i++)
{
    var val = int.Parse(line[i].ToString());

    if (i % 2 == 0)
    {
        for (int x = 0; x < int.Parse(line[i].ToString()); x++)
            encoded.Add(file.ToString());
        file++;
    }
    else
    {
        for (int x = 0; x < int.Parse(line[i].ToString()); x++)
            encoded.Add(".");
    }
}
var encoded_list = encoded.ToList();
var last_dot = 0;
for (int i = encoded_list.Count - 1; i > 0; i--)
{
    for (int x = last_dot; last_dot < i; last_dot++)
    {
        if (encoded_list[last_dot] == ".")
        {
            encoded_list[last_dot] = encoded_list[i];
            encoded_list[i] = ".";
            break;
        }
    }
}
var ans = 0L;
for (int i = 0; i < encoded_list.Count; i++)
{
    if (encoded_list[i] != ".")
        ans += i * long.Parse(encoded_list[i].ToString());
}
Console.WriteLine(ans);

//encoded_list.ForEach(c => Console.Write(c));
