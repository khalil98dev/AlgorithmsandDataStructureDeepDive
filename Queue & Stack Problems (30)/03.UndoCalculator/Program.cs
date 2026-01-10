
//Undo Operations in a Calculator
//Problem: Implement undo functionality in a calculator.

Stack<int> koko = new Stack<int> ();

koko.Push (1);
koko.Push (2);
koko.Push (3);



int Undo(Stack<int> Results)
{
    Results.Pop();
    return Results.Peek();
}



Console.WriteLine($"{Undo(koko)}");




