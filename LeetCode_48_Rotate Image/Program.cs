// See https://aka.ms/new-console-template for more information
using System.Text.Json;

var solution = new Solution();
var matrix = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
solution.Rotate(matrix);
var jsonString = JsonSerializer.Serialize(matrix);
Console.WriteLine(jsonString);



class Solution
{
    public void Rotate(int[][] matrix)
    {
        if (matrix == null || matrix.Length == 0)
        {
            return;
        }
        int row = matrix.Length;
        int col = matrix[0].Length;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < i; j++)
            {
                swap(matrix, i, j);
            }
        }
        foreach (int[] rowWise in matrix)
        {
            reverse(rowWise, 0, col - 1);
        }
    }

    private void swap(int[][] matrix, int i, int j)
    {
        int temp = matrix[i][j];
        matrix[i][j] = matrix[j][i];
        matrix[j][i] = temp;
    }

    private void reverse(int[] nums, int i, int j)
    {
        while (i < j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
            i++;
            j--;
        }
    }
}
