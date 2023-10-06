// Challenge: Create a ATM program, which gives an output of the needed banknotes and coins, with minimum code

using System.Reflection.PortableExecutable;
using System.Text;

Random rand = new();

decimal input = rand.Next(1, 1000000) / 100;
Console.Write($"Input amount: {input}");
Console.WriteLine();
Console.WriteLine("Result:");
Console.WriteLine();

int sum = Convert.ToInt32(input * 100);
int dividend = 50000;
int cBills = 0;
int cCoins = 0;
decimal valueCheck = 0;

while (dividend > 0)
{
    Console.WriteLine($"{(sum / dividend).ToString().PadLeft(4)}x {(dividend > 100 ? (dividend / 100).ToString().PadLeft(5) : (dividend / 100.00m).ToString().PadLeft(5))} Euro {(dividend > 499 ? "Bills" : "Coins")}: {(sum / dividend * dividend / 100.00m).ToString("#0.00").PadLeft(8)} Euro");
    valueCheck += (sum / dividend) * dividend / 100m;
    cBills += dividend > 500 ? sum / dividend : 0;
    cCoins += dividend <= 500 ? sum / dividend : 0;
    sum = sum / dividend > 0 ? sum - dividend * (sum / dividend) : sum;
    dividend = dividend.ToString().StartsWith('5') ? dividend / 5 * 2 : dividend / 2;
}

Console.WriteLine("------------------------------------------------------------------------------------------------------------");
Console.WriteLine($"{valueCheck.ToString("#0.00").PadLeft(10)} in {cBills} Bills and {cCoins} Coins");
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Task: Find the amicable numbers up to 10 000");
Console.WriteLine();
Console.WriteLine("The results: ");
Console.WriteLine();

int su = 0;
int n2 = 0;


for (int i = 1; i < 10000; i++)
{

    for (int t = 1; t < i / 2 + 1; t++)
    {
        if (i % t == 0)
        {
            su += t;
        }
    }

    n2 = su;
    su = 0;

    for (int t = 1; t < n2 / 2 + 1; t++)
    {
        if (n2 % t == 0)
        {
            su += t;
        }
    }

    if (su == i && n2 != 0 && i != n2 && i > n2)
    {
        Console.WriteLine($"The amicable numbers are ({i}, {n2})");
    }

    n2 = 0;
    su = 0;
}

Console.WriteLine();
Console.WriteLine("------------------------------------------------------------------------------------------------------------");
Console.WriteLine();
Console.WriteLine("Task: Draw a Christmas star on the console");
Console.WriteLine();

List<int> sizes = new();

while (sizes.Count < 3)
{
    int i = rand.Next(20, 35);

    if (i % 2 == 0)
        sizes.Add(i);
}

foreach (int item in sizes)
{
    string[,] map = new string[(item * 4 / 3 + 1), item * 2 + 1];

    for (int i = 0; i < map.GetLength(0); i++) // height
    {
        int starCount = 0;
        for (int t = 0; t < map.GetLength(1); t++)
        {
            int x = map.GetLength(1) - i * 2 + 1 - t * 2 - 1;
            bool isMiddle = x == 1;

            if (isMiddle)
            {
                starCount = i * 2 + 1;
            }


            if (starCount == 0)
            {
                map[i, t] = " ";
            }
            else
            {
                map[i, t] = "ӿ";
                starCount--;
            }
        }

        if (i + 1 > item / 3)
        {
            int startPoint = i - item / 3 + 1;
            for (int t = 0; t < map.GetLength(1); t++)
            {
                if (t < startPoint - 1 || t > map.GetLength(1) - startPoint)
                {
                    if (map[i, t] != "ӿ")
                    {
                    map[i, t] = " ";
                    }
                }
                else
                {
                    map[i, t] = "ӿ";
                }
            }
        }
    }

    int counter = 0;

    Console.WriteLine($"Star height {map.GetLength(0)} and star width {map.GetLength(1)}");
    Console.WriteLine();

    for (int i = 0; i < map.GetLength(0); i++)
    {
        for (int t = 0; t < map.GetLength(1); t++)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.Write(map[i, t]);
        }
        Console.WriteLine();
    }

}



