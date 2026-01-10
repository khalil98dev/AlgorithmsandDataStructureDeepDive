
//Dinars
using System.Runtime.ConstrainedExecution;
using System.Security.AccessControl;

List<int> Coins = new List<int>()
{
    5,10,20,50,100,200,500,1000,2000
};

decimal ammount = 15;

List<decimal> GetMinCoins(List<int> Coins, decimal Ammount)
{
    //Order Desc 
    Coins.Sort((a, b) => b.CompareTo(a));


    List<decimal> resultCoins = new List<decimal>();


    foreach (var coin in Coins)
    {
        while (coin <= Ammount)
        {
            Ammount -= coin;  //-200 => 250 => 50 
            resultCoins.Add(coin);
            if (Ammount == 0)
                break;
        }
    }

    return resultCoins;
}



char answer = 'y'; 
while(answer=='y' || answer=='Y')
{
    Console.Clear();    


    Console.Write("Paid ammount: ");
    decimal PaidAmmount = decimal.Parse(Console.ReadLine());
    Console.WriteLine("Saved!");
    Console.Write("\nTotal Purshaches: ");
    decimal TotalPurc = decimal.Parse(Console.ReadLine());
    Console.WriteLine("Saved!");


    Console.WriteLine("Thinking ... ");
    Thread.Sleep(1000);

    ammount = PaidAmmount - TotalPurc;
    List<decimal> result = GetMinCoins(Coins, ammount);


    Dictionary<decimal, int> RetrtiveCoins = result.GroupBy(x => x).
        ToDictionary(x => x.Key, x => x.Count());

    Console.WriteLine("Result: ");
    Console.WriteLine("**************************************");
    foreach (var item in RetrtiveCoins)
    {
        Console.WriteLine($"*{"",9} [{item.Key,10:N2} DZD] : ({item.Value,-4}){"",0} *");
    }
    Console.WriteLine("**************************************");


    Console.WriteLine("Repeat? (Y/N): "); 
    answer = Console.ReadKey().KeyChar;

}








