// See https://aka.ms/new-console-template for more information
Console.WriteLine("Program One");


using StreamReader reader = new("input.txt");

string? line = reader.ReadLine();
var lines = new List<string>();
while (line != null)
{
    lines.Add(line);
    line = reader.ReadLine();

}

var A = int.Parse(lines[0]);
var B = int.Parse(lines[1]);
var C = int.Parse(lines[2]);
List<int> program = lines[3].Split().Select(int.Parse).ToList();

//Do the freaking work

var output = new List<int>();
int pointer = 0;

while (pointer < program.Count){

    if(program[pointer] == 0){
        A = A/(program[pointer]^2);
    }

    if(program[pointer]== 1){
        //bitwise or
    }
    if(program[pointer]== 2){
        
    }
    pointer+=2;


}

int comboOp (int combo){
    
    if(combo == 4)return A;
    if(combo == 5)return B;
    if(combo == 6)return C;
    return combo;
}   