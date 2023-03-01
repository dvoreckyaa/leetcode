// See https://aka.ms/new-console-template for more information
var solution = new Solution();
// [10,1,2,7,6,1,5], target = 8

var result = solution.CombinationSum(new[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
Console.WriteLine(string.Join(Environment.NewLine, result.Select(r => "["+ string.Join(",", r) + "]")));



public class Solution
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {

        var result = new List<IList<int>>();

        Array.Sort(candidates);
        if (candidates.Length == 0 || target < candidates[0]) return result;
        DFS(candidates, target, 0, new List<int>(), result, 0);

        return result;
    }

    private void DFS(int[] candidates, int target, int sum, IList<int> res, IList<IList<int>> result, int startIndex)
    {
        if (target < sum) return;
        if (target == sum)
        {
            Console.WriteLine($"----- {string.Join(", ", res)} ----");
            result.Add(new List<int>(res));
            return;
        }

        for (int i = startIndex; i < candidates.Length; i++)
        {
            Console.WriteLine($"{string.Join(", ", res)}");
            if (sum + candidates[i] > target)
            {
                break;
            }

            // to make sure the output result is always sorted to avoid duplicate
            if (res.Count > 0 && candidates[i] < res[res.Count - 1]) continue;

            res.Add(candidates[i]);
            if (i == startIndex || candidates[i] != candidates[i - 1])
            {
                DFS(candidates, target, sum + candidates[i], res, result, i + 1);
            }
            res.RemoveAt(res.Count - 1);
        }
    }
}
