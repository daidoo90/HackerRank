// Case 1
using HackerRank;

var a_indexes = new List<int>
{
    1,4,5
};
var a_values = new List<double>
{
    9,3,1
};

var b_indexes = new List<int>
{
    5,4,4
};
var b_values = new List<double>
{
    2,1,2
};

var result = Solution.Calculate(a_indexes, a_values, b_indexes, b_values);  // Expected 6.5

Console.WriteLine(result);
