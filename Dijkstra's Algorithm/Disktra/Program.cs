using DataStructuire.Graph;

List<string> vertices = new List<string> { "A", "B", "C", "D", "E" };

// Create a directed graph
Graph graph = new Graph(vertices, Graph.eGraphType.eDirected);

// Add edges with weights
graph.AddEdge("A", "B", 10);
graph.AddEdge("A", "C", 15);
graph.AddEdge("B", "D", 12);
graph.AddEdge("C", "D", 10);
graph.AddEdge("B", "E", 15);
graph.AddEdge("D", "E", 2);

// Display the graph
graph.Display();

// Run Dijkstra's Algorithm from vertex "A"
var result = graph.Dijkstras("A");



graph.Dijkstra("A");

foreach (var item in result)
{
    Console.WriteLine(item);
}


//Shortesh times 

Console.WriteLine("Shortest pathh fro A to E ");

var path =  result["E"];

Console.WriteLine(path);    




Console.ReadKey();