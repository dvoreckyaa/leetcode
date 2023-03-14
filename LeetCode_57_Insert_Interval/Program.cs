using System.Text.Json;

var solution = new Solution();

printSolution(new int[][] { new int[] { 1, 3 }, new int[] { 6, 9 } }, new int[] { 2, 5 }, "[[1,5],[6,9]]");
printSolution(new int[][] { }, new int[] { 5, 7 }, "[[5,7]]");
printSolution(new int[][] { new int[] { 1, 5 } }, new int[] { 2, 3 }, "[[1,5]]");
printSolution(new int[][] { new int[] { 1, 5 } }, new int[] { 0, 0 }, "[[0,0],[1,5]]");

void printSolution(int[][] intervals, int[] newInterval, string result)
{
    Console.WriteLine(JsonSerializer.Serialize(intervals));
    var res = JsonSerializer.Serialize(solution.Insert(intervals, newInterval));
    Console.WriteLine(res);
    Console.WriteLine(res == result);
    Console.WriteLine();
}


public class Solution
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        if (intervals.Length == 0)
        {
            return new int[][] { newInterval };
        }
        List<int[]> result = new List<int[]>();

        bool isMerged = false;
        bool isAdded = false;
        for (int i = 0; i < intervals.Length; i++)
        {
            if (isAdded)
            {
                result.Add(intervals[i]);
                continue;
            }

            var h = GetIntersected(newInterval, intervals[i], out bool isIntersected);
            if (!isIntersected)
            {
                if (isMerged ||
                    newInterval[1] < intervals[i][0])
                {
                    result.Add(newInterval);
                    isAdded = true;
                }
                result.Add(intervals[i]);
            }
            else if (newInterval[0] > intervals[i][1])
            {
                isMerged = true;
            }
            else
            {
                isMerged = true;
                newInterval = h;
            }
        }

        if (!isAdded)
        {
            result.Add(newInterval);
        }

        return result.ToArray();
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
}
