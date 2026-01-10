//Back Browser 
//When we need a recurions we use Stack 

using System.Diagnostics.Metrics;

Stack<int> pages = new Stack<int>();    
Stack<int> History = new Stack<int>();    

pages.Push(0);  
pages.Push(1);
pages.Push(2);
pages.Push(3);
pages.Push(4);
pages.Push(5);
pages.Push(6);

//Print Full History




while(true)
{
    ConsoleKeyInfo move = Console.ReadKey(true);
    Console.Clear();
    foreach (var item in pages)
    {
        Console.Write(item + " ");
    }


    Console.WriteLine("\nPress <- Or -> To Move in History\n\n");

    if(move.Key == ConsoleKey.LeftArrow)
    {
        //Go back 

        if (pages.Count > 0)
        {
            var value = pages.Pop();
            History.Push(value);
            Console.WriteLine($"Current: {value}");
        }
    }
    else if(move.Key == ConsoleKey.RightArrow)
    {
        if(History.Count>0)
        {
            //move forward
            var value = History.Pop();
            pages.Push(value);
            Console.WriteLine($"Current: {value}");
        }
        



    }
    else
    {
        Console.WriteLine("Please just work with arrow left-right");
        Console.WriteLine("Press <- Or -> To Move in History\n\n");
         move = Console.ReadKey(true);
    }

}





