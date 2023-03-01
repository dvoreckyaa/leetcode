// See https://aka.ms/new-console-template for more information
using System.Text.Json;

var solution = new Solution();
var matrix = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
var result = solution.GroupAnagrams(matrix);
var jsonString = JsonSerializer.Serialize(result);
Console.WriteLine(jsonString);



public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, string> sortedStrs = new Dictionary<string, string>();
        for (int i = 0; i < strs.Length; i++)
        {
            char[] arr = strs[i].ToCharArray();
            Array.Sort(arr);
            sortedStrs.TryAdd(strs[i], new string(arr));
        }
        var result = new List<IList<string>>();
        Scan(strs, sortedStrs, result);
        return result;
    }

    private void Scan(string[] strs, Dictionary<string, string> sortedStrs, IList<IList<string>> result)
    {
        for (int i = 0; i < strs.Length; i++)
        {
            bool found = false;
            for (int j = 0; j < result.Count; j++)
            {
                if (CompareStr(sortedStrs[result[j][0]], sortedStrs[strs[i]]))
                {
                    result[j].Add(strs[i]);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                var curList = new List<string>
                {
                    strs[i]
                };
                result.Add(curList);
            }
        }
    }

    private bool CompareStr(string str1, string str2)
    {
        /*if (str1.Length != str2.Length)
        {
            return false;
        }
        for (int i = 0; i < str1.Length; i++)
        {
            if (!str2.Contains(str1[i]))
            {
                return false;
            }
        }*/
        return str1 == str2;
    }
}
