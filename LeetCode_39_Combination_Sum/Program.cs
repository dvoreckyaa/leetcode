// See https://aka.ms/new-console-template for more information
var solution = new Solution();
//[8,7,4,3]
//11
var result = solution.CombinationSum(new[] { 8, 7, 4, 3 }, 11);
Console.WriteLine(string.Join(Environment.NewLine, result.Select(r => "["+ string.Join(",", r) + "]")));



public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        // idea 1: brute force, generate all possible combination which has 2^N possibilities and check whether
        // each combination's sum equals target. This doesn't work though as one element can be used multi times.

        // idea 2: backtracking, potential optimazition, sort the candidates first. Memorization probably will help
        // but it's a little bit hard to check dup output
        var result = new List<IList<int>>();

        Array.Sort(candidates);
        if (candidates.Length == 0 || target < candidates[0]) return result;

        DFS(candidates, target, 0, new List<int>(), result);

        return result;
    }

    private void DFS(int[] candidates, int target, int sum, IList<int> res, IList<IList<int>> result)
    {
        if (target < sum) return;
        if (target == sum)
        {
            result.Add(new List<int>(res));
            return;
        }

        for (int i = 0; i < candidates.Length; i++)
        {
            if (sum + candidates[i] > target)
            {
                break;
            }

            // to make sure the output result is always sorted to avoid duplicate
            if (res.Count > 0 && candidates[i] < res[res.Count - 1]) continue;

            res.Add(candidates[i]);
            DFS(candidates, target, sum + candidates[i], res, result);
            res.RemoveAt(res.Count - 1);
        }
    }
}
