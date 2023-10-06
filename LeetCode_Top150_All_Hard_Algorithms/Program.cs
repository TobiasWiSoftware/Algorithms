// This project contains solutions to all tasks listed as "hard" on https://leetcode.com/studyplan/top-interview-150/. Solving these tasks requires coding skills at an international level, especially when completed in under 60 minutes.



// LeetCode Top150 Algorithms - level "hard"

Console.WriteLine("1.1 chapter array - Task 135. Candy");
Console.WriteLine();
Console.WriteLine("There are n children standing in a line. Each child is assigned a rating value given in the integer array ratings.\r\n\r\nYou are giving candies to these children subjected to the following requirements:\r\n\r\n    Each child must have at least one candy.\r\n    Children with a higher rating get more candies than their neighbors.\r\n\r\nReturn the minimum number of candies you need to have to distribute the candies to the children.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: ratings = [1,0,2]\r\nOutput: 5\r\nExplanation: You can allocate to the first, second and third child with 2, 1, 2 candies respectively.\r\n\r\nExample 2:\r\n\r\nInput: ratings = [1,2,2]\r\nOutput: 4\r\nExplanation: You can allocate to the first, second and third child with 1, 2, 1 candies respectively.\r\nThe third child gets 1 candy because it satisfies the above two conditions.\r\n");
Console.WriteLine();
Console.WriteLine();

Func<int[], int> fTask135Candy = (ratings) =>
{
    int[] aCandy = new int[ratings.Length];

    for (int i = 0; i < ratings.Length; i++)
    {
        if (i > 0)
        {
            if (ratings[i - 1] < ratings[i])
            {
                aCandy[i] = aCandy[i - 1];
            }
        }
        aCandy[i]++;
    }

    for (int i = ratings.Length - 2; i > -1; i--)
    {
        if (i == 0)
        {
            if (aCandy[i] < aCandy[i + 1] && ratings[i] > ratings[i + 1])
            {
                aCandy[i] = aCandy[i] + 1;
            }
        }


        if (ratings[i + 1] < ratings[i] && aCandy[i] <= aCandy[i + 1])
        {
            aCandy[i] = Math.Max(aCandy[i] + 1, aCandy[i + 1] + 1);
        }


    }




    return aCandy.Sum();
};

int[] arrTask135CandyTest1 = { 1, 0, 2 };
int[] arrTask135CandyTest2 = { 1, 2, 2 };
int[] arrTask135CandyTest3 = { 1, 3, 2, 2, 1 };
int[] arrTask135CandyTest4 = { 1, 2, 87, 87, 87, 2, 1 };
int[] arrTask135CandyTest5 = { 29, 51, 87, 87, 72, 12 };

Console.WriteLine($"Solution => {fTask135Candy(arrTask135CandyTest1)} and {fTask135Candy(arrTask135CandyTest2)} and {fTask135Candy(arrTask135CandyTest3)} and {fTask135Candy(arrTask135CandyTest4)} and {fTask135Candy(arrTask135CandyTest5)}");
Console.WriteLine();
Console.WriteLine("----------------------------------------------------------------------------------------------------------------");

Console.WriteLine("1.2 chapter array - Task 68. Text Justification");
Console.WriteLine();
Console.WriteLine("Given an array of strings words and a width maxWidth, format the text such that each line has exactly maxWidth characters and is fully (left and right) justified.");
Console.WriteLine();
Console.WriteLine();

// Algo like in word justified, much cases, complicated. Time attempt at first try about 4,5 h, without hints
// Beats 67,29% in runtime and 70,22 % in Memory with space complexity O(n) and runtime up to O(n³) - only in case that all words are in one line

Func<string[], int, IList<string>> fTask68TextJustification = (words, maxWidth) =>
{
    IList<string> list = new List<string>();
    int currLength = 0;
    int newStart = 0;
    int i = 0;

    for (i = 0; i < words.Length; i++)
    {
        currLength += words[i].Length;

        if (currLength + ++newStart < maxWidth // + newStart for min. one space
        || currLength + newStart == maxWidth && i == words.Length - 1) // except. for the case that at the and is only one char and last line - must not be right align then
        {
            if (i < words.Length - 1)
            {
                continue;
            }
            else
            {
                i -= newStart;
                i++; // for last line in if clause on bottom
                break; // cancel case for currline < maxWidth and last line
            }
        }
        else
        {
            if (currLength + newStart - 1 > maxWidth)
            {
                currLength -= words[i].Length;
                i--;
                newStart--;
            }


            // catching empty spaces

            int spaces = maxWidth - currLength; //(currLength - (newStart - 1)) because one ' ' is already calc. for each word != last word
            bool isOnlyWord = words[i].Length == currLength;



            List<string> line = new();
            bool isFirstRound = true;

            if (isOnlyWord && words[i].Length == maxWidth) // Exception when word fills exact the line width
            {
                line.Add(words[i]);
            }
            while (spaces > 0)
            {
                int wordIndex = 0;
                for (int t = i - newStart + 1; t < i + 1; t++)
                {
                    if (isFirstRound)
                    {
                        string w = words[t];
                        if (t < i || isOnlyWord)
                        {
                            w += " ";
                            spaces--;
                        }
                        line.Add(w);
                    }
                    else if ((spaces > 0 && t < i) || isOnlyWord)
                    {
                        line[wordIndex] = line[wordIndex] + " ";
                        spaces--;
                    }
                    else if (spaces == 0)
                    {
                        break;
                    }
                    wordIndex++;
                }
                isFirstRound = false;
            }
            list.Add(string.Join("", line));
            newStart = 0;
            currLength = 0;
        }
    }

    // Edge case last line < maxWidt


    if (i < words.Length)
    {
        string line = string.Empty;

        for (; i < words.Length; i++)
        {
            line += words[i] + " ";
        }


        for (int t = line.Length; t < maxWidth; t++)
        {
            line += " ";
        }

        list.Add(line);
    }

    return list;
};

string[] arrTask68Test1 = { "This", "is", "an", "example", "of", "text", "justification." };
string[] arrTask68Test2 = { "What", "must", "be", "acknowledgment", "shall", "be" };
string[] arrTask68Test3 = { "Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do" };
string[] arrTask68Test4 = { "Listen", "to", "many,", "speak", "to", "a", "few." };
string[] arrTask68Test5 = { "a", "b", "c", "d", "e", "f" };

List<List<string>> lResult1 = new() { fTask68TextJustification(arrTask68Test1, 16).ToList(), fTask68TextJustification(arrTask68Test2, 16).ToList(), fTask68TextJustification(arrTask68Test3, 20).ToList(), fTask68TextJustification(arrTask68Test4, 6).ToList(), fTask68TextJustification(arrTask68Test5, 6).ToList() };

string sTask68Result = string.Empty;
sTask68Result += "\n";

foreach (List<string> item in lResult1)
{
    sTask68Result += "[\n";

    foreach (string text in item)
    {
        sTask68Result += @"""" + text + @"""" + "\n";
    }

    if (lResult1.IndexOf(item) < lResult1.Count - 1)
        sTask68Result += "]\n" + "\n" + "\n";
}

sTask68Result += "]";

Console.WriteLine(sTask68Result);
Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
Console.WriteLine();


