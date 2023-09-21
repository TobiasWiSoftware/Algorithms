// From leetcode.com top-interview-questions chapter array/string easy to hard


using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
using System.Xml;

Console.WriteLine("EASY");
Console.WriteLine();

Console.WriteLine("Task 1: Merge two integer arrays into a single array in non-decreasing order in the time 0(m + n)");
Console.WriteLine();

Action<int[], int, int[], int> Solution1 = (arr1, m, arr2, n) =>
{
    int i = m - 1;
    int j = n - 1;
    int k = m + n - 1;

    while (j >= 0 && i >= 0)
    {
        if (arr1[i] > arr2[j])
        {
            arr1[k--] = arr1[i--];
        }
        else
        {
            arr1[k--] = arr2[j--];
        }
    }

    while (j >= 0)
    {
        arr1[k--] = arr2[j--];
    }

};



int[] testData1IntArr1 = new int[] { 1, 2, 3, 0, 0, 0 };
int[] testData1IntArr2 = new int[] { 2, 5, 6 };

Console.WriteLine("The result should be: [1,2,2,3,5,6]");
Console.WriteLine();

Solution1(testData1IntArr1, 3, testData1IntArr2, 3);

Console.WriteLine($"The result is [{string.Join(" ", testData1IntArr1)}]");
Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");


Console.WriteLine("Task2: Remove the all number that fit the given number val from a array nums the array must contain the leftover elements from start, the emty space are at the end and the function should return the number k of left elements");

Console.WriteLine();

int[] testDataTask2 = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
int valTask2 = 2;

Console.WriteLine($"The input is {string.Join(' ', testDataTask2)} and the val = {valTask2}");
Console.WriteLine();

Func<int[], int, int> fTask2 = (nums, val) =>
{

    int start = 0;
    int end = nums.Length - 1;

    while (start - 1 != end)
    {
        if (nums[start] != val)
        {
            start++;
        }
        else
        {
            nums[start] = nums[end];
            end--;
        }
    }

    return start;
};

Console.WriteLine($"Result: {fTask2(testDataTask2, valTask2)}");

Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");


Console.WriteLine("Task 3: Majority Element - return the majority element which appears more than n / 2 times. [2,2,1,1,1,2,2] => 2");

Console.WriteLine();

// using the Boyer-Moore Voting Algorithm

int[] numsTask3 = new[] { 2, 2, 1, 1, 1, 2, 2 };

Func<int[], int> funcTask3 = (nums) =>
{

    int candidate = nums[0];
    int count = 0;

    foreach (int item in nums)
    {
        if (count == 0)
        {
            candidate = item;
        }

        if (item == candidate)
        {
            count++;
        }
        else
        {
            count--;
        }

    }


    return candidate;
};

Console.WriteLine($"The result: {funcTask3(numsTask3)}");

Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");

Console.WriteLine("Task 4: Stock Price - at a given array with prices [7,1,5,3,6,4] you want to figure out when to buy and sell best to max. profit");

int[] arrTask4 = new int[] { 7, 1, 5, 3, 6, 4 };


int minPrice = arrTask4.Length > 1 ? arrTask4[0] : 0;

Func<int[], int> funcTask4 = (prices) =>
{
    int diff = 0;
    int start = 0;

    for (int i = 0; i < prices.Length; i++)
    {
        if (i == 0)
            start = prices[i];

        if (prices[i] < start)
        {
            start = prices[i];
        }
        else if (prices[i] - start > diff)
        {
            diff = prices[i] - start;
        }
    }




    return diff;
};

Console.WriteLine();
Console.WriteLine($"The result: {funcTask4(arrTask4)}");
Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");


// Task 5: Roman to int 

string s = "MCMXCIV";


Console.WriteLine($"Set the string {s} => 1994");
Console.WriteLine();



Func<string, int> fTask4 = (s) =>
    {

        int iTask4 = 0;

        for (int i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                case 'I':
                    if (s.Length - 1 > i && (s[i + 1] == 'V' || s[i + 1] == 'X'))
                    {
                        iTask4 -= 1;
                    }
                    else
                    {
                        iTask4 += 1;
                    }
                    break;
                case 'V':
                    iTask4 += 5;
                    break;
                case 'X':
                    if (s.Length - 1 > i && (s[i + 1] == 'L' || s[i + 1] == 'C'))
                    {
                        iTask4 -= 10;
                    }
                    else
                    {
                        iTask4 += 10;
                    }
                    break;
                case 'L':
                    iTask4 += 50;
                    break;
                case 'C':
                    if (s.Length - 1 > i && (s[i + 1] == 'D' || s[i + 1] == 'M'))
                    {
                        iTask4 -= 100;
                    }
                    else
                    {
                        iTask4 += 100;
                    }
                    break;
                case 'D':
                    iTask4 += 500;
                    break;
                case 'M':
                    iTask4 += 1000;
                    break;

            }
        }

        return iTask4;

    };

Console.WriteLine($"Result: {fTask4(s)}");
Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");

// Task 5: Length of last Word

string sTask5 = "   fly me   to   the moon  ";
sTask5 = " the moon ";


Console.WriteLine("Get the length of the last word of the string " + sTask5);
Console.WriteLine();

Func<string, int> fTask5 = (s) =>
{
    int c = 0;

    for (int i = 0; i < s.Length; i++)
    {

        if (i != 0 && s[i - 1] == ' ' && s[i] != ' ')
        {
            c = 0;
        }


        if (s[i] != ' ')
            c++;
    }

    return c;
};

Console.WriteLine($"The result: {fTask5(sTask5)}");
Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");


string[] sTask6 = new string[] { "flower", "flow", "flight" };

Console.WriteLine($"Task 6: Return the most common prefix of {string.Join(" ", sTask6)} => fl");

Console.WriteLine();

Func<string[], string> fTask6 = (strs) =>
{
    string result = "";
    StringBuilder marker = new();
    bool isExit = false;

    List<string> lString = strs.ToList().OrderBy(s => s.Length).ToList();

    if (lString[0].Length > 0)
    {
        for (int i = 0; i < lString[0].Length; i++)
        {
            marker.Append(lString[0][i]);

            foreach (string item in strs)
            {
                if (item[i] != marker[marker.Length - 1])
                {
                    isExit = true;
                    break;
                }
            }

            if (!isExit)
                result = marker.ToString();

        }

    }

    return result;
};

Console.WriteLine($"The result is {fTask6(sTask6)}");
Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");
Console.WriteLine();


Console.WriteLine("Task 7: Return the first occurrence in a string - haystack = sadbutsad needle = sad => return 0");

string haystack = "sadbutsad";
haystack = "mississippi";
string needle = "sad";
needle = "issip";


Func<string, string, int> fTask7 = (haystack, needle) =>
{

    int t = -1;

    for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
    {
        bool found = true;

        for (int j = 0; j < needle.Length; j++)
        {
            if (haystack[i + j] != needle[j])
            {
                found = false;
                break;
            }
        }

        if (found)
        {
            t = i;
            break;
        }
    }

    return t;


};

Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"The result: {fTask7(haystack, needle)}");
Console.WriteLine("---------------------------------------------------------");
Console.WriteLine();


// MEDIUM


int[] task8Arr = new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 };

Console.WriteLine($"Task 8: Remove duplicates from sorted array that appear more than twice nums = [{string.Join(' ', task8Arr)}] => [0,0,1,1,2,3,3] with k = 7 and return k as number of elements left");

Func<int[], int> task8Func = (nums) =>
{
    int k = 1;
    int lastNumber = nums[0];
    int actualCell = 1;
    int markerCount = 1;

    for (int i = 1; i < nums.Length; i++)
    {
        if (lastNumber != nums[i] || lastNumber == nums[i] && markerCount < 2)
        {
            if (lastNumber == nums[i])
                markerCount++;
            else
                markerCount = 1;

            lastNumber = nums[i];
            nums[i] = default;
            nums[actualCell++] = lastNumber;
            k++;

        }
        else
        {
            nums[i] = default;
            markerCount = 0;

            // Remove of all following instances of the number that is already provided
            while (i < nums.Length - 1 && nums[i + 1] == lastNumber)
            {
                nums[i + 1] = default;
                i++;
            }
        }
    }


    return k;
};

Console.WriteLine();
Console.WriteLine($"The result: k = {task8Func(task8Arr)} with numbers [{string.Join(' ', task8Arr)}]");

Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");

Console.WriteLine();

Console.WriteLine("Task 9: Rotate the array to the right by k steps - nums [1,2,3,4,5,6,7] => [5,6,7,1,2,3,4]");

int[] task9Arr = new[] { 1, 2, 3, 4, 5, 6, 7 };
int task9k = 3;



Action<int[], int> task9Func = (nums, k) =>
{
  

};

Console.WriteLine();
Console.WriteLine();
task9Func(task9Arr, task9k);
Console.WriteLine($"The result: [{string.Join(" ", task9Arr)}]");
