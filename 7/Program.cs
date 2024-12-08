// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Transactions;

Console.WriteLine("Program One");


using StreamReader reader = new("input.txt");

var p1Ans = 0l;
string? line = reader.ReadLine();
while (line != null)
{
    var target = long.Parse(line.Split(":")[0]);
    var nums = line.Split(":")[1].Trim().Split(" ").Select(long.Parse).ToList();
    
    if(calibrated(target, nums[0], nums.Skip(1).ToList())){
        p1Ans +=target;
    }

    line = reader.ReadLine();

}

Console.WriteLine(p1Ans);

 static bool calibrated(long target, long current, List<long> nums){

    //Last itteration
    if(nums.Count == 1){
        if(current + nums[0] == target || current * nums[0] == target  || long.Parse(current +""+nums[0]) == target){
            return true;
        }
        return false;
    }
    return calibrated(target, current+nums[0], nums.Skip(1).ToList() )|| calibrated(target, current*nums[0], nums.Skip(1).ToList() ) || calibrated(target, long.Parse(current +""+nums[0]), nums.Skip(1).ToList() ) ;

}