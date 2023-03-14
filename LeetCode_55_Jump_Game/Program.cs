using System.Text.Json;

var solution = new Solution();

printSolution(new int[] { 2, 3, 1, 1, 4 }, true);
printSolution(new int[] { 3, 2, 1, 0, 4 }, false);
printSolution(new int[] { 3, 0, 8, 2, 0, 0, 1 }, true);
printSolution(new int[] { 1, 2, 3 }, true);
printSolution(new int[] { 1, 0, 1, 0 }, false);

void printSolution(int[] nums, bool result)
{
    Console.WriteLine(JsonSerializer.Serialize(nums));
    Console.WriteLine(solution.CanJump(nums) == result);
}


public class Solution
{
    public bool CanJump(int[] nums)
    {
        return DoWork(nums);
    }

    private bool DoWork(int[] nums)
    {
        if (nums.Length == 1)
        {
            return true;
        }
        var lastFilledIndex = nums.Length - 1;
        var lengthArr = new int[nums.Length];
        for (int i = lengthArr.Length - 2; i >= 0; i--)
        {
            if (nums[i] == 0
              || lengthArr[i + 1] == 0 && nums[i] < lastFilledIndex - i)
            {
                continue;
            }

            for (int j = i; j <= Math.Min(i + nums[i], lengthArr.Length - 1); j++)
            {
                if (lengthArr[i] == 0 ||
                     j + lengthArr[j] < lengthArr[i])
                {
                    lengthArr[i] = lengthArr[j] + j;
                    lastFilledIndex = i;
                }
            }

            if (lengthArr[i] == 0
                && i != lengthArr.Length - 2
                && nums[i] > lastFilledIndex - i)
            {
                lengthArr[i] = lastFilledIndex - i;
                lastFilledIndex = i;
            }
        }
        return lengthArr[0] != 0;
    }
}
