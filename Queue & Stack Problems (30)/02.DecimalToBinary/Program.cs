// Decimal to Binary 


// 10.02








string DecicimalToBinary(int number)
{
    Stack<int> Binray = new Stack<int>();

    while (number > 0)
    {
        Binray.Push(number % 2);
        number = number / 2;    
    }

    return string.Join(" ", Binray);
}




int number = 10;
Console.WriteLine($"{number} To Binary: {DecicimalToBinary(number)}");



Console.ReadLine();