/*
Web Page Request Handling
Problem: Simulate a web server that processes requests in the order they arrive. Example:

Input: Requests arriving at times [Request1, Request2, Request3].
Output: Process the requests in the order they arrive.
Key Points:

Enqueue requests as they arrive.
Dequeue and process requests in FIFO order.*/

public class Program
{

    static void Main(string[] args)
    {

        Queue<string> Requests = new Queue<string>();


        while (Requests.Count < 10)
        {
            Requests.Enqueue($"Request-{Requests.Count + 100}");
        }


        while (Requests.Count > 0)
        {
            // Dequeue the task at the front of the queue
            string currentTask = Requests.Dequeue();
            Console.WriteLine($"Processing Request: {currentTask}");
        }





    }

}





