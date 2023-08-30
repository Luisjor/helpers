using System;
using System.Linq;

class Program
{
    static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Swap arr[j] and arr[j+1]
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    public static string FindNeedle(object[] haystack)
    {
        return $"found the needle at position {Array.IndexOf(haystack, "needle")}";
    }

    public static string HighAndLow(string numbers)
    {
        var numberArray = numbers.Split(' ').Select(int.Parse);
        int highest = numberArray.Max();
        int lowest = numberArray.Min();

        return $"{highest} {lowest}";
    }

    static bool IsPalindrome(string str)
    {
        return str.ToLower() == new string(str.Reverse().ToArray()).ToLower();
    }

    static bool SquareEachElementAndCompareArray(int[] a, int[] b)
    {
        var squaredA = a.Select(x => x * x).ToArray();
        Array.Sort(squaredA);
        Array.Sort(b);

        return squaredA.SequenceEqual(b);
    }

    static void Main(string[] args)
    {
        //BubbleSort
        int[] array = { 64, 34, 25, 12, 22, 11, 90 };
        Console.WriteLine("Original array: " + string.Join(", ", array));

        BubbleSort(array);

        Console.WriteLine("Sorted array: " + string.Join(", ", array));

        //IsPalindrome
        string input = "ana";

        if (IsPalindrome(input))
        {
            Console.WriteLine("The string is a palindrome.");
        }
        else
        {
            Console.WriteLine("The string is not a palindrome.");
        }

        //SquareEachElementAndCompareArray
        int[] a = { 121, 144, 19, 161, 19, 144, 19, 11 };
        int[] b = { 121, 14641, 20736, 361, 25921, 361, 20736, 361 };

        bool result = Comp(a, b);
        Console.WriteLine("Arrays have same elements squared: " + result);
    }
}

