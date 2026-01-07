
using DataStructuire.Graph; 

class Program
{
    static void Main(string[] args)
    {

        var varticies = new List<string>()
    {
        "A","B","C","E","F","G"
    };


        Graph graph = new Graph(varticies, Graph.eGraphType.eUndirected);


        //Add Edjes

        graph.AddEdge("A","B",1);
        graph.AddEdge("B","C",1);
        graph.AddEdge("B","D",1);
        graph.AddEdge("A","E",1);

        graph.Display();

        //Strat TYraversing from A  
        Console.WriteLine("Strat Traversing Breadth First From Vertex A");
        graph.BFS("A");


        Console.WriteLine("Strat Traversing Depth First From Vertex A");

        graph.DFS("A");

    }
}
