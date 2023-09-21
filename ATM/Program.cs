// Challenge: Create a ATM program, which gives an output of the needed banknotes and coins, with minimum code

Console.Write("Input amount: ");
decimal input = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine();
Console.WriteLine("Result:");
Console.WriteLine();

int sum = Convert.ToInt32(input * 100);
int dividend = 50000;
int cBills = 0;
int cCoins = 0;
decimal valueCheck = 0;

while(dividend > 0)
{
    Console.WriteLine($"{(sum / dividend).ToString().PadLeft(4)}x {(dividend > 100 ? (dividend / 100).ToString().PadLeft(5) : (dividend / 100.00m).ToString().PadLeft(5))} Euro {(dividend > 499 ? "Bills" : "Coins")}: {(sum / dividend * dividend / 100.00m).ToString("#0.00").PadLeft(8)} Euro");
    valueCheck += (sum / dividend) * dividend / 100m;
    cBills += dividend > 500 ? sum / dividend : 0;
    cCoins += dividend <= 500 ? sum / dividend : 0;
    sum = sum / dividend > 0 ? sum - dividend * (sum / dividend ) : sum;
    dividend = dividend.ToString().StartsWith('5') ? dividend / 5 * 2 : dividend.ToString().StartsWith('2') ? dividend / 2 : dividend / 2;
}

Console.WriteLine("-----------------------");
Console.WriteLine($"{valueCheck.ToString("#0.00").PadLeft(10)} in {cBills} Bills and {cCoins} Coins");
