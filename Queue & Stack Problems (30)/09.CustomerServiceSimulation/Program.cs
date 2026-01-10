/*
 Customer Service Simulation
Problem: Simulate a customer service system where customers are served in the order they arrive. Example:

Input: Customers arriving at different times.
Output: Serve customers in a first-come, first-served order.
Key Points:

Use a queue to maintain the order of customer arrivals.
Dequeue customers when they are served.

using System.Collections.Immutable;
using System.Threading.Tasks;*/

public class Program
{

    static void Main(string[] args)
    {

        Queue<string> Orders = new Queue<string>();


        while (Orders.Count < 10)
        {
            Orders.Enqueue($"Order-{Orders.Count + 100}");
        }


        while (Orders.Count > 0)
        {
            // Dequeue the task at the front of the queue
            string currentTask = Orders.Dequeue();
            Console.WriteLine($"Processing Order: {currentTask}");
        }





    }

}





