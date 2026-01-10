/*
 Ticketing System Simulation
Problem: Simulate a ticketing system where customers are served in the order they arrive. When a customer’s ticket is processed, the next ticket is queued for service.

Output:

Ticket 101 issued.

Ticket 102 issued.

Ticket 103 issued.

Ticket 104 issued.

Ticket 105 issued.


Ticketing System Simulation Started...

Processing Ticket: 101

Remaining Tickets: 102, 103, 104, 105

Processing Ticket: 102

Remaining Tickets: 103, 104, 105

Processing Ticket: 103

Remaining Tickets: 104, 105

Processing Ticket: 104

Remaining Tickets: 105

Processing Ticket: 105

No more tickets in the queue.

Ticketing System Simulation Ended.
 */

using System.Collections.Immutable;

public class Program
{

    static void Main(string[] args)
    {

        Queue<int> Tickts = new Queue<int>();


        Console.WriteLine("Ticketing System Simulation Started...");
        
        //Issue Tickets
        while (Tickts.Count < 10)
        {
            Tickts.Enqueue(Tickts.Count+100);
            Console.WriteLine($"Ticket {Tickts.Count + 100} issued.");

        }


        while (Tickts.Count > 0)
        {
            Console.WriteLine();
            var current = Tickts.Dequeue();
            Console.WriteLine($"Processing Ticket {current}...");
            Console.WriteLine($"Remaining Tickets:  {string.Join(",", Tickts)}.");
            Thread.Sleep(1000);

            Console.WriteLine($"Ticket {current} Processed.");

        }





    }

}