// From https://leetcode.com/studyplan/top-interview-150/ top-interview-questions chapter array/string easy to hard


using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Xml;

DateTime start = DateTime.Now;

Console.WriteLine("EASY");
Console.WriteLine();

Console.WriteLine("Task 1: Merge two integer arrays into a single array in non-decreasing order in the time O(m + n)");
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


Console.WriteLine("Task 2: Remove all the numbers from an array that fit the given number val from an array nums the array must contain the leftover elements from start, the empty spaces are at the end and the function should return the number k of left elements");

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


Console.WriteLine($"Task 5: Set the string {s} => 1994");
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

// Task 6: Length of last Word

string sTask5 = "   fly me   to   the moon  ";
sTask5 = " the moon ";


Console.WriteLine("Task 6: Get the length of the last word of the string " + sTask5);
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

Console.WriteLine($"Task 7: Return the most common prefix of {string.Join(" ", sTask6)} => fl");

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


Console.WriteLine("Task 8: Return the first occurrence in a string - haystack = sadbutsad needle = sad => return 0");

string haystack = "sadbutsad";
string needle = "sad";


Func<string, string, int> fTask8 = (haystack, needle) =>
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
Console.WriteLine($"The result: {fTask8(haystack, needle)}");
Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");
Console.WriteLine();


// MEDIUM
Console.WriteLine("MEDIUM");
Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");


int[] task9Arr = new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 };

Console.WriteLine($"Task 9: Remove duplicates from sorted array that appear more than twice nums = [{string.Join(' ', task9Arr)}] => [0,0,1,1,2,3,3] with k = 7 and return k as number of elements left");

Func<int[], int> task9Func = (nums) =>
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
Console.WriteLine($"The result: k = {task9Func(task9Arr)} with numbers [{string.Join(' ', task9Arr)}]");

Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");


Console.WriteLine("Task 10: Rotate the array to the right by k steps - nums [1,2,3,4,5,6,7], k = 3 => [5,6,7,1,2,3,4]");

int[] task10Arr = new[] { 1, 2, 3, 4, 5, 6, 7 };
int task10k = 3;



Action<int[], int> task10Func = (nums, k) =>
{
    k = k % nums.Length;

    if (nums.Length < 2 || k == 0)
        return;


    Action<int[], int, int> reverse = (nums, start, end) =>
    {
        for (int i = 0; i < (end - start) / 2; i++)
        {
            int tmp = nums[i + start];
            nums[i + start] = nums[end - i];
            nums[end - i] = tmp;
        }
    };

    reverse(nums, 0, nums.Length - 1 - k);
    reverse(nums, nums.Length - k, nums.Length - 1);
    reverse(nums, 0, nums.Length - 1);
};

Console.WriteLine();
Console.WriteLine();
task10Func(task10Arr, task10k);
Console.WriteLine($"The result: [{string.Join(" ", task10Arr)}]");
Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");

Console.WriteLine("Task 11: Stock II: One stock can only be held at a time. Which buys and sells give the max. profit? [7,1,5,3,6,4] => 7 Buy day 2, sell day 3, buy day 4, sell day 5");

int[] task11Arr = new[] { 7, 1, 5, 3, 6, 4 };




Func<int[], int> task11Func = (prices) =>
{
    int p = 0;

    if (prices.Length < 2)
    {
        return p;
    }


    int tempBuy = prices[0];
    int cycleProfit = 0;

    for (int i = 0; i < prices.Length - 1; i++)
    {
        if (tempBuy > prices[i + 1])
        {
            tempBuy = prices[i + 1];
            continue;
        }

        while (true)
        {
            if (i < prices.Length - 1)
            {
                if (prices[i + 1] <= prices[i])
                {
                    break;
                }
            }
            else
            {
                break;
            }
            i++;
        }
        cycleProfit = prices[i] - tempBuy;
        p += cycleProfit;
        cycleProfit = 0;
        if (i < prices.Length - 1)
            tempBuy = prices[i + 1];
    }

    return p;
};

Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"The result: {task11Func(task11Arr)}");
Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");
Console.WriteLine("Task 12: Each element in array represents the jump length from the position. Can the end be reached. [2,3,1,1,4] => true; [3,2,1,0,4] => false");
int[] task12Arr1 = new[] { 2, 3, 1, 1, 4 };
int[] task12Arr2 = new[] { 3, 2, 1, 0, 4 };

Func<int[], bool> task12Func = (nums) =>
{
    bool result = true;
    int jumps = 0;


    for (int i = 0; i < nums.Length; i++)
    {
        jumps--;

        if (nums[i] > jumps)
        {
            jumps = nums[i];
        }

        if (jumps == 0 && i != nums.Length - 1)
        {
            result = false;
        }

    }





    return result;
};

Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"The result: {task12Func(task12Arr1)} and {task12Func(task12Arr2)}");
Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");
Console.WriteLine("Task 13: Each element in array represents the jump length from the position. Reach nums[n - 1] with the minimum jumps [2,3,1,1,4] => 2; [3,2,0,1,4] => 2");
int[] task13Arr1 = new[] { 2, 3, 1, 1, 4 };
int[] task13Arr2 = new[] { 2, 3, 0, 1, 4 };

Func<int[], int> task13Func = (nums) =>
{
    int jumps = 0;
    int jumpLength = 0;
    int currPos = 0;

    if (nums.Length > 1)
    {

        for (int i = 0; i < nums.Length - 1; i++)
        {
            jumpLength = Math.Max(jumpLength, i + nums[i]);

            if (jumpLength >= nums.Length - 1)
            {
                jumps++;
                break;
            }
            if (i == currPos)
            {
                currPos = jumpLength;
                jumps++;
            }

        }

    }

    return jumps;
};

Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"The result: {task13Func(task13Arr1)} and {task13Func(task13Arr2)}");
Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");

Console.WriteLine("Task 14: Return the h-index of the citations of a researcher: [3,0,6,1,5] => 3 (3 citations in 3 paper)");
int[] task14Arr1 = new[] { 3, 0, 6, 1, 5 };
int[] task14Arr2 = new[] { 1, 3, 1 };

Func<int[], int> task14Func = (citations) =>
{
    int numberCitations = 0;
    Array.Sort(citations);

    for (int i = citations.Length - 1; i >= 0; i--)
    {
        if (citations.Length - i <= citations[i])
        {
            numberCitations = citations.Length - i;
        }
        else
        {
            break;
        }
    }


    return numberCitations;
};

Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"The result: {task14Func(task14Arr1)} and {task13Func(task14Arr2)}");
Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");

Console.WriteLine("Task 15: A coded class RandomizedSet should give to the test input [], [1], [2], [2], [], [1], [2], [] => null, true, false, true, 2, true, false, 2");
Console.WriteLine();

RandomizedSet sTest = new();

Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"The result: Insert 1 => {sTest.Insert(1)}, Remove 2 => {sTest.Remove(2)}, Insert 2 => {sTest.Insert(2)}, GetRandom => {sTest.GetRandom()}, Remove 1 => {sTest.Remove(1)}, Insert 2 => {sTest.Insert(2)}, GetRandom => {sTest.GetRandom()}");
Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");

Console.WriteLine("Task 16: Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i]. [1,2,3,4] => [24,12,8,6]");
Console.WriteLine();

int[] task16InputArr = { 1, 2, 3, 4, 5, 6 };

Func<int[], int[]> FuncTask16 = (nums) =>
{
    int[] o = new int[nums.Length];
    int num = 1;

    for (int i = 0; i < nums.Length; i++)
    {
        o[i] = num;
        num *= nums[i];
    }
    num = 1;

    for (int i = nums.Length - 1; i >= 0; i--)
    {
        o[i] *= num;
        num *= nums[i];
    }

    return o;
};

Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"The result: [{string.Join(" ", FuncTask16(task16InputArr))}]");
Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");

Console.WriteLine("Task 17: There are n gas stations along a circular route, where the amount of gas at the ith station is gas[i]. You have a car with an unlimited gas tank and it cost[i] of gas to travel from the ith station to its next (i + 1)th station. You begin the journey with an empty tank at one of the gas stations. gas = [1,2,3,4,5] and cost = [3,4,5,1,2] => 3");
Console.WriteLine();

int[] task17InputArrGas = { 1, 2, 3, 4, 5 };
int[] task17InputArrCost = { 3, 4, 5, 1, 2 };

int[] task17InputArrGas2 = { 2, 3, 4 };
int[] task17InputArrCost2 = { 3, 4, 3 };

Func<int[], int[], int> FuncTask17 = (gas, cost) =>
{
    int currTank = 0;
    int totalTank = 0;
    int start = 0;

    for (int i = 0; i < cost.Length; i++)
    {
        currTank += gas[i] - cost[i];
        totalTank += gas[i] - cost[i];

        if (currTank < 0)
        {
            start = i + 1;
            currTank = 0;
        }
    }


    return totalTank > -1 ? start : -1;
};

Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"The result: {FuncTask17(task17InputArrGas, task17InputArrCost)} and {FuncTask17(task17InputArrGas2, task17InputArrCost2)}");
Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");



// Task 18: Int to Roman

int inputTask18 = 1994;


Console.WriteLine($"Task 18: Set the dec {inputTask18} to Roman => MCMXCIV");
Console.WriteLine();



Func<int, string> fTask18 = (num) =>
{

    string s = string.Empty;
    int factor = 1000;

    while (num > 0)
    {
        switch (factor)
        {
            case 1:
                if (num > 3)
                {
                    s += "IV";
                    num -= 4;
                }
                else
                {
                    for (int t = 0; t < num; t++)
                    {
                        s += "I";
                        num -= 1;
                    }
                }
                break;
            case 5:
                if (num > 8)
                {
                    s += "IX";
                    num -= 9;
                }
                else
                {
                    for (int t = 0; t < num / factor; t++)
                    {
                        s += "V";
                        num -= 5;

                    }
                }
                break;
            case 10:
                if (num > 39)
                {
                    s += "XL";
                    num -= 40;
                }
                else
                {
                    for (int t = 0; t < num / factor; t++)
                    {
                        s += "X";
                        num -= 10;
                    }
                }
                break;
            case 50:
                if (num > 89)
                {
                    s += "XC";
                    num -= 90;
                }
                else
                {
                    for (int t = 0; t < num / factor; t++)
                    {
                        s += "L";
                        num -= 50;

                    }
                }
                break;
            case 100:
                if (num > 399)
                {
                    s += "CD";
                    num -= 400;
                }
                else
                {
                    for (int t = 0; t < num / factor; t++)
                    {
                        s += "C";
                        num -= 100;
                    }

                }
                break;
            case 500:
                if (num > 899)
                {
                    s += "CM";
                    num -= 900;
                }
                else
                {
                    for (int t = 0; t < num / factor; t++)
                    {

                        s += "D";
                        num -= 500;
                    }
                }
                break;
            case 1000:
                for (int t = 0; t < num / factor; t++)
                {
                    s += "M";
                    num -= 1000;
                }
                break;

        }

        while (factor > num)
        {
            factor = factor.ToString().StartsWith('1') ? factor / 2 : factor / 5;

        }

    }

    return s;

};

Console.WriteLine($"Result: {fTask18(inputTask18)}");
Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");
Console.WriteLine("Task 19: Reverse the words: the sky is blue => blue is sky the");

string sTask19 = "the sky is blue";

Func<string, string> funcTask19 = (s) =>
{
    string ret = string.Empty;

    List<string> lStr = s.Split(' ').ToList();
    List<string> lRet = new();

    lStr.ForEach(s =>
    {


        string b = s.Trim();
        if (b != string.Empty)
        {
            lRet.Add(b);
        }
    });

    lRet.Reverse();


    return string.Join(" ", lRet);
};

Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"The result: {funcTask19(sTask19)}");
Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");
Console.WriteLine(@"Task 20: Write a string in zig-zag over given rows: ""PAYPALISHIRING""");

// Very hard to understand, try later again

string sTask20 = "PAYPALISHIRING";

Func<string, int, string> funcTask20 = (s, numRows) =>
{
    string ret = "";
    if (numRows == 1)
        ret = s;


    var result = new StringBuilder();
    var perIter = numRows * 2 - 2;
    for (int row = 0; row < numRows; row++)
    {
        int i = 0;
        while ((i + row) < s.Length)
        {
            result.Append(s[i + row]);
            if (row != 0 && row != numRows - 1)
            {
                if ((i + perIter - row) < s.Length)
                {
                    result.Append(s[i + perIter - row]);
                }
            }

            i += perIter;
        }
    }
    ret = result.ToString();

    return ret;
};

Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"The result: {funcTask20(sTask20, 4)}");



Console.WriteLine();
Console.WriteLine("---------------------------------------------------------");
DateTime end = DateTime.Now;
Console.WriteLine();
Console.WriteLine($"All tasks finished in {(end - start).TotalMilliseconds.ToString("#0.00")} ms runtime");

Console.WriteLine();
Console.WriteLine("Press any key to close this window");
Console.ReadKey();
Environment.Exit(0);







// """""""""""""""""""""""""""""""""""""" Used classes """""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
class RandomizedSet
{
    private Dictionary<int, int> dict;
    private List<int> list;
    private Random rand;

    public RandomizedSet()
    {
        dict = new();
        list = new();
        rand = new();
    }

    public bool Insert(int val)
    {
        if (dict.ContainsKey(val))
            return false;

        dict[val] = list.Count;
        list.Add(val);

        return true;
    }

    public bool Remove(int val)
    {
        if (!dict.ContainsKey(val))
            return false;

        int lastElement = list[list.Count - 1];
        int index = dict[val];

        list[index] = lastElement;
        dict[lastElement] = index;
        list.RemoveAt(list.Count - 1);
        dict.Remove(val);
        return true;
    }

    public int GetRandom()
    {
        return list[rand.Next(list.Count)];
    }

}