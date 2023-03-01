
var solution = new Solution();
var result = solution.MyPow(8.84372, 5);
Console.WriteLine(result);
Console.WriteLine(Math.Pow(8.84372, 5));

public class Solution
{
    public double MyPow(double x, int n)
    {
        return CalcPow(x, n);
    }

    static double CalcPow(double x, int n)
    {
        double temp;
        if (n == 0)
            return 1;
        temp = CalcPow(x, n / 2);

        if (n % 2 == 0)
            return temp * temp;
        else
        {
            if (n > 0)
                return x * temp * temp;
            else
                return (temp * temp) / x;
        }
    }
}
