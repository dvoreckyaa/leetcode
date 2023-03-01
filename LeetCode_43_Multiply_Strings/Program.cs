// See https://aka.ms/new-console-template for more information
var solution = new Solution();
//"925101087184894"
//"3896737933784656127"
//"3604876499018802870538090258945538"
var result = solution.Multiply("999", "999");
Console.WriteLine(result);



public class Solution
{
    public string Multiply(string num1, string num2)
    {
        if (num2.Length > num1.Length)
        {
            return Calculate(num2, num1);
        }
        return Calculate(num1, num2);

    }
    

    public string Calculate(string num1, string num2)
    {

        var result = new string('0', num1.Length + num2.Length).ToCharArray();

        for (int i = num2.Length-1; i >= 0; i--)
        {
            Int64 d1 = (int)char.GetNumericValue(num2[i]);
            Int64 valueRemainder = 0;
            Int64 curResultIndex1 = 0;
            for (int j = num1.Length-1; j >=0 ; j--)
            {
                Int64 d2 = (Int64)char.GetNumericValue(num1[j]);
                curResultIndex1 = result.Length - num1.Length + j - (num2.Length - 1 - i);
                Int64 sum = (d1 * d2 + valueRemainder)  + (Int64)char.GetNumericValue(result[curResultIndex1]);

                valueRemainder = sum / 10;
                Int64 remainder = sum % 10;

                result[curResultIndex1] = remainder.ToString()[0];
            }

            if (valueRemainder > 0)
            {
                string strRemainder = valueRemainder.ToString();
                int curDigitnumber = 0;
                Int64 sumRemainder = 0;
                while (sumRemainder > 0 || curDigitnumber < strRemainder.Length)
                {
                    Int64 curResultIndex = curResultIndex1 -  curDigitnumber -1 ;
                    Int64 s1 = strRemainder.Length - curDigitnumber - 1 >= 0
                                 ? (int)char.GetNumericValue(strRemainder[strRemainder.Length - curDigitnumber - 1])
                                 : 0;
                    Int64 s2 = (int)char.GetNumericValue(result[curResultIndex]);
                    Int64 res = s1 + s2 + sumRemainder;
                    sumRemainder = res / 10;
                    Int64 remainder = res % 10;
                    result[curResultIndex] = remainder.ToString()[0];
                    curDigitnumber++;
                }
            }
        }

        int trimCount = 0;
        while (trimCount < result.Length-1              
              && result[trimCount] == '0')
        {
            trimCount++;
        }
        if (trimCount > 0)
        {
            var newResult = new char[result.Length - trimCount];
            Array.Copy(result, trimCount, newResult, 0, newResult.Length);
            return new string(newResult);
        }

        return new string(result);
    }
}
    
