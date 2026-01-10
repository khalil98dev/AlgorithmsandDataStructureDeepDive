
/*
 
 Printer Job Scheduling
Problem: Use a queue to manage printer jobs.
 */
public class Job
{
    public string Name { get; set; }

    public bool Start { get; private set; }
    
    public int Duration { get; set; }
    
    public Job(string name,int Duration)
    {
        this.Name = name;
        this.Duration = Duration;
    }
    public void StartJob()
    {
        this.Start = true;   
    }

}


public class Program
{
    static void Main(string[] args)
    {

        Queue<Job> jobs = new Queue<Job>();

        var job1 = new Job("Print Bill", 2);
        var job2 = new Job("Print Order", 1);
        var job3 = new Job("Print Status", 5);
        var job4 = new Job("Print Stock Status", 3);

        jobs.Enqueue(job1); 
        jobs.Enqueue(job2);
        jobs.Enqueue(job3);
        jobs.Enqueue(job4);


        while (jobs.Count > 0)
        {
            var Currentjob = jobs.Dequeue();
            string NextJob = (jobs.Count != 0) ? jobs.Peek().Name : "Finished";
            Console.WriteLine($"Proccess : {Currentjob.Name} |Next Job: {NextJob}");

            Thread.Sleep(Currentjob.Duration*1000);
            Console.WriteLine($"{Currentjob.Name} Proccessed.");
        }

        Console.WriteLine("All Tasks are Proccessed.");
        Console.ReadLine(); 
    }
}





