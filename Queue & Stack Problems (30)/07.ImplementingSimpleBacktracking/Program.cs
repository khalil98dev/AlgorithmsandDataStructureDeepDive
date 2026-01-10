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
//TaskScheduling
//Problem: Given a set of tasks with a specific order,
//simulate the order of execution using a queue. Example:

//Input: ["Task1", "Task2", "Task3", "Task4"]
//Output: Execute tasks in the order they appear.
//Key Points:

//Enqueue tasks in the given order.

//Dequeue and process them one at a time.

using System.Collections.Immutable;
using System.Threading.Tasks;

public class Program
{

    static void Main(string[] args)
    {
        Stack<string> Day = new Stack<string>();
        Day.Push("Start");
        Day.Push("Go to Gaz Station");
        Day.Push("Go to Super Market");
        Day.Push("Go To Work");
        Day.Push("Go to Cafe");
        Day.Push("Go Home.");
        Console.WriteLine("Backtracking...");
        while (Day.Count>0)
        {
            
            Console.WriteLine("Back to: "+ Day.Pop());   
        }

   




    }

}





