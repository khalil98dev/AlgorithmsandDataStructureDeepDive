/*
 Problem: Simulate vehicles waiting at a traffic signal.

Vehicles are processed in the order they arrive (FIFO), and after processing, the next vehicle moves up.

Vehicles arrive in the following order:

"Car 1";
"Truck 1"
"Bike 1"
"Bus 1"



Output:

Traffic Signal Simulation Started...


Car 1 has passed the signal.

Vehicles waiting: Truck 1, Bike 1, Bus 1

Truck 1 has passed the signal.

Vehicles waiting: Bike 1, Bus 1

Bike 1 has passed the signal.

Vehicles waiting: Bus 1

Bus 1 has passed the signal.

No vehicles waiting.

Traffic Signal Simulation Ended.*/

enum eTrffic { Red=0,Green=1,Yellow=3 }


public class Program
{
   static eTrffic TraficChanger(Stack<eTrffic> Source, Queue<eTrffic> Reverse)
    {
        if(Source.Count>0)
        {
            Reverse.Enqueue(Source.Pop());  

            if(Source.Count==0)
            {
                return Reverse.Peek();
            }

            return Source.Peek();
        }else
        {
            Source.Push(Reverse.Dequeue()); 
            if(Source.Count==0)
            {
                return Source.Peek();
            }
            return Reverse.Peek();
        }

    }

    static void Main(string[] args)
    {
        Queue<string> Vehicles = new Queue<string>();
        Stack<eTrffic> source= new Stack<eTrffic>();
        Queue<eTrffic> reverse = new Queue<eTrffic>();

    

        Vehicles.Enqueue("Car 1");
        Vehicles.Enqueue("Truck 1");
        Vehicles.Enqueue("Bike 1");
        Vehicles.Enqueue("Bus 1");

        //Initialize
        source.Push(eTrffic.Red);
        source.Push(eTrffic.Yellow);
        source.Push(eTrffic.Green);



       
        while (Vehicles.Count > 0)
        {
            var result = TraficChanger(source, reverse);

            Console.WriteLine("Trafic is: "+ result.ToString());

            if(result == eTrffic.Green)
            {
                var passed = Vehicles.Dequeue();
                Console.WriteLine($"Vehicle Passed: {passed}");
                if (Vehicles.Count ==0 )
                {
                    Console.WriteLine("All Vehicles Passed!");
                    return;
                }
                var waiting = Vehicles.Peek();
                Console.WriteLine($"Vehicle Waiting: {waiting}");

                Console.WriteLine("\n");
            }else if(result == eTrffic.Red)
            {
                Thread.Sleep(2000);
               
                result = TraficChanger(source, reverse);

            }
            else
            {
                Thread.Sleep(500);
                result = TraficChanger(source, reverse);
            }
            

        }
    }
}
        