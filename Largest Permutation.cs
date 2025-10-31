using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'largestPermutation' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY arr
     */

    public static List<int> largestPermutation(int k, List<int> arr)
    {
          int n = arr.Count;

        // Create a dictionary to store the index of each value for O(1) lookup
        Dictionary<int, int> indexMap = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
        {
            indexMap[arr[i]] = i;
        }

        for (int i = 0; i < n && k > 0; i++)
        {
            int maxVal = n - i;
            if (arr[i] != maxVal)
            {
                
                int idx = indexMap[maxVal];
                indexMap[arr[i]] = idx;
                indexMap[maxVal] = i;

                int temp = arr[i];
                arr[i] = arr[idx];
                arr[idx] = temp;

                k--;
            }
        }

        return arr;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.largestPermutation(k, arr);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
