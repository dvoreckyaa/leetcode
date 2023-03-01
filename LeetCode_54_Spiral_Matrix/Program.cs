
using System.Text.Json;

//[[1,2,3],[4,5,6],[7,8,9]]
//int[][] matrix = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };

//[[1,2,3,4],[5,6,7,8],[9,10,11,12]]
//int[][] matrix = new int[][] { new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 9, 10, 11, 12 } };

//[[3],[2]]
//int[][] matrix = new int[][] { new int[] { 3 }, new int[] { 2 } };

//[[1,2],[3,4]]
//int[][] matrix = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } };11,12,13

//[[2,3,4],[5,6,7],[8,9,10],[11,12,13]]
int[][] matrix = new int[][] { new int[] { 2, 3, 4 }, new int[] { 5, 6, 7 }, new int[] { 8, 9, 10 }, new int[] { 11, 12, 13 } };

var solution = new Solution();
var result = solution.SpiralOrder(matrix);
string jsonString = JsonSerializer.Serialize(result);
Console.WriteLine(jsonString);


public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        return DoSpiralOrder(matrix);
    }

    private IList<int> DoSpiralOrder(int[][] matrix)
    {
        var result = new List<int>();
        int l = 0;
        int r = matrix[0].Length - 1;
        int t = 0;
        int b = matrix.Length - 1;
        int totalCount = matrix[0].Length * matrix.Length;

        if (matrix[0].Length == 1)
        {
            ScanColumn(matrix, l, t, b, result);
            return result;
        }
        else if (matrix.Length == 1)
        {
            ScanRow(matrix, t, l, r, result);
            return result;
        }

        while ((l < r && b > t) || result.Count < totalCount)
        {
            ScanRow(matrix, t, l, r, result);
            t++;

            ScanColumn(matrix, r, t, b, result);
            r--;

            ScanRow(matrix, b, r, l, result);
            b--;

            ScanColumn(matrix, l, b, t, result);
            l++;
        }
        return result;
    }

    private void ScanRow(int[][] matrix, int rowNo, int l, int r, IList<int> list)
    {
        if (list.Count == matrix[0].Length * matrix.Length)
        {
            return;
        }
        if (r > l)
        {
            for (int i = l; i <= r; i++)
            {
                list.Add(matrix[rowNo][i]);
            }
        }
        else
        {
            for (int i = l; i >= r; i--)
            {
                list.Add(matrix[rowNo][i]);
            }
        }
    }

    private void ScanColumn(int[][] matrix, int colNo, int t, int b, IList<int> list)
    {
        if (list.Count == matrix[0].Length * matrix.Length)
        {
            return;
        }
        if (b > t)
        {
            for (int i = t; i <= b; i++)
            {
                list.Add(matrix[i][colNo]);
            }
        }
        else
        {
            for (int i = t; i >= b; i--)
            {
                list.Add(matrix[i][colNo]);
            }
        }
    }
}
