// See https://aka.ms/new-console-template for more information
var solution = new Solution();
var result = solution.Jump(new int[] { 2, 1 });
Console.WriteLine(result);



public class Solution
{
    public int Jump(int[] nums)
    {
        return Calculate(nums);
    }

    private int Calculate(int[] nums)
    {
        if (nums.Length == 1)
        {
            return 0;
        }
        int[] jumps = new int[nums.Length];
        Array.Fill(jumps, 0);
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            CalcPath(i, jumps, nums);
        }
        return jumps[0];
    }

    private void CalcPath(int index, int[] jumps, int[] nums)
    {
        jumps[index] = nums.Length;
        for (int i = 1; i <= Math.Min(nums[index], nums.Length - 1 - index); i++)
        {
            if (jumps[index] > jumps[index + i] + 1)
            {
                jumps[index] = jumps[index + i] + 1;
            }
        }
    }
}

