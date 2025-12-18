// See https://aka.ms/new-console-template for more information
Console.WriteLine("Program One");


using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();
while (line != null)
{

    line = reader.ReadLine();

}



var keypad = new char[3, 4];

keypad[0, 0] = '7';
keypad[0, 1] = '8';
keypad[0, 2] = '9';
keypad[1, 0] = '4';
keypad[1, 1] = '5';
keypad[1, 2] = '6';
keypad[2, 0] = '1';
keypad[2, 1] = '2';
keypad[2, 2] = '3';
keypad[3, 0] = 'X';
keypad[3, 1] = '0';
keypad[3, 2] = 'A';

Dictionary<char, Dictionary<char, string>> keypad = new Dictionary<char, Dictionary<char, string>>
{
    {
        'A',
        new Dictionary<char, string>(){
    {'A', ""},
    {'0', "<"},
    {'1', "^<<"},
    {'2', ""},
    {'3', ""},
    {'4', ""},
    {'5', ""},
    {'6', ""},
    {'7', ""},
    {'8', ""},
    {'9', ""},



}
    }
};

//Basically a fucking node
class Key
{

    public char value;
    public Dictionary<char, string> sequences;

}