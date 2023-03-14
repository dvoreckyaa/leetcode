using System.Collections;
using System.Text.Json;

var solution = new Solution();

printSolution(new int[][] { new int[] { 1, 4 }, new int[] { 4, 5 } }, "[[1,5]]");
printSolution(new int[][] { new int[] { 1, 4 }, new int[] { 5, 6 } }, "[[1,4],[5,6]]");
printSolution(new int[][] { new int[] { 2, 3 }, new int[] { 4, 5 }, new int[] { 6, 7 }, new int[] { 8, 9 }, new int[] { 1, 10 } }, "[[1,10]]");

void printSolution(int[][] nums, string result)
{
    Console.WriteLine(JsonSerializer.Serialize(nums));
    var res = JsonSerializer.Serialize(solution.Merge(nums));
    Console.WriteLine(res);
    Console.WriteLine(res == result);
    Console.WriteLine();
}


public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        if (intervals.Length == 0)
        {
            return intervals;
        }
        Array.Sort(intervals, new SortIntervals());
        var list = new List<int[]>
        {
            intervals[0]
        };
        for (int i = 1; i < intervals.Length; i++)
        {
            var c = GetIntersected(list.Last(), intervals[i], out bool isIntersected);
            if (!isIntersected)
            {
                list.Add(intervals[i]);
            }
            else
            {
                list[list.Count - 1] = c;
            }
        }

        return list.ToArray();
    }

    private int[] GetIntersected(int[] a, int[] b, out bool isIntersected)
    {
        if (a[1] < b[0]
        || b[1] < a[0])
        {
            isIntersected = false;
            return new int[] { };
        }
        isIntersected = true;
        return new int[] { Math.Min(a[0], b[0]), Math.Max(a[1], b[1]) };
    }

    class SortIntervals : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            int[] first = (int[])a;
            int[] second = (int[])b;
            if (first[0] == second[0])
            {
                return first[1] - second[1];
            }
            return first[0] - second[0];
        }
    }
}
