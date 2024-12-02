// See https://aka.ms/new-console-template for more information
Console.WriteLine("Program One");


using StreamReader reader = new("input1.txt");

string? text = reader.ReadLine();
while (text != null)
{

    text = reader.ReadLine();

}
