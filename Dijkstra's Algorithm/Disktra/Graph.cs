using System;
using System.Collections.Generic;
using System.Text;


namespace DataStructuire.Graph;

public class Graph
{

    public enum eGraphType { eDirected=0,eUndirected=1}


    private int[,] _adjancencyMatrix;

    private Dictionary<string, int> _vertexDictionary;

    private int _numberOfVerticies; 

    private eGraphType _GraphDirectionType = eGraphType.eUndirected;
    

    public Graph(List<string> verticeis,eGraphType type) {

        _numberOfVerticies = verticeis.Count;

        _vertexDictionary = new Dictionary<string, int>();

        _adjancencyMatrix = new int[_numberOfVerticies, _numberOfVerticies]; 



        for(int i = 0; i < _numberOfVerticies; i++)
        {
            _vertexDictionary[verticeis[i]] = i;
        }

        _GraphDirectionType = type;

    }



    public void AddEdge(string source,string Distination,int Weight)
    {

        if(!_vertexDictionary.ContainsKey(source) || !_vertexDictionary.ContainsKey(Distination))
        {
            Console.WriteLine("source/Distination invalid.");
            return;
        }

        int sourceIndex = _vertexDictionary[source]; 
        int DistinationIndex = _vertexDictionary[Distination];


        _adjancencyMatrix[sourceIndex,DistinationIndex] = Weight;   

        if(_GraphDirectionType == eGraphType.eUndirected)
        {
            _adjancencyMatrix[DistinationIndex, sourceIndex] = Weight;
        }

    }


    public void BFS(string StratVertex)
    {

        if (!_vertexDictionary.ContainsKey(StratVertex))
        {
            Console.WriteLine("The Strat vertex choosen not found!:0.");
            return;
        }


        bool[] visited = new bool[_numberOfVerticies];


        Queue<int> queue = new Queue<int>();


        int StratIndex = _vertexDictionary[StratVertex];
        visited[StratIndex] = true; // Mark as Visited

        Console.WriteLine("\nBreadth-First Search:");

        queue.Enqueue(StratIndex);

        while (queue.Count > 0)
        {

            int CurrentIndex = queue.Dequeue();

            Console.Write($"{GetVertexName(CurrentIndex)} "); // Print the current vertex



            for (int i = 0; i < _numberOfVerticies; i++)
            {
                //>0 that mean has a relation because when it 0 mean there is no relation and the weight equals zero
                if (_adjancencyMatrix[CurrentIndex, i] > 0 && !visited[i])
                {
                    visited[i] = true;
                    queue.Enqueue(i);

                }

            }


            Console.WriteLine();

        }
    }



    public void DFS(string StratVertex)
    {

        if (!_vertexDictionary.ContainsKey(StratVertex))
        {
            Console.WriteLine("The Strat vertex choosen not found!:0.");
            return;
        }


        bool[] visited = new bool[_numberOfVerticies];


        Stack<int> queue = new Stack<int>();


        int StratIndex = _vertexDictionary[StratVertex];
        visited[StratIndex] = true; // Mark as Visited

        Console.WriteLine("\nDepth-First Search:");

        queue.Push(StratIndex);

        while (queue.Count > 0)
        {

            int CurrentIndex = queue.Pop();

            Console.Write($"{GetVertexName(CurrentIndex)} "); // Print the current vertex



            for (int i = 0; i < _numberOfVerticies; i++)
            {
                //>0 that mean has a relation because when it 0 mean there is no relation and the weight equals zero
                if (_adjancencyMatrix[CurrentIndex, i] > 0 && !visited[i])
                {
                    visited[i] = true;
                    queue.Push(i);

                }

            }


            Console.WriteLine();

        }
    }

    private string GetVertexName(int index)
    {
        foreach (var pair in _vertexDictionary)
        {
            if (pair.Value == index)
                return pair.Key;
        }
        return null;
    }


    public void Display()
    {
        Console.WriteLine("Adjacency matrix: ");
        Console.Write("\n   ");

        foreach(string source in _vertexDictionary.Keys)
        {
            Console.Write($"{source}  ");
        }
        

        foreach (string koko in _vertexDictionary.Keys) 
        {

            Console.Write($"\n\n{koko}  ");

            for (int j = 0; j < _numberOfVerticies; j++)
            {
                Console.Write($"{_adjancencyMatrix[_vertexDictionary[koko], j]}  ");
            }

        }

        Console.Write("\n\n");
    }





    public Dictionary<string, string> Dijkstras(string Strat)
    {
        int StratIndex = _vertexDictionary[Strat];

        bool[] Visited = new bool[_numberOfVerticies];

        int[] Distances = new int[_numberOfVerticies];  

        string[] predecessor = new string[_numberOfVerticies]; //for track the Shortests Path


        //Initialize 

        for (int i = 0; i < _numberOfVerticies; i++)
        {
            Visited[i] = false;
            Distances[i] = int.MaxValue;
            predecessor[i] = null; 
        }


        Distances[StratIndex] = 0; 


        for(int count=0;count< _numberOfVerticies-1;count++)
        {
            //Get The Current Vetex shuch as not Visited 
            int minIndex = MinimumIndex(Distances, Visited);
            Visited[minIndex] = true;

            //Update Distances fo all vertcies : 
            for (int v = 0; v < _numberOfVerticies; v++) {


                //Conditions: 
                // The vertex not visited yet
                // Has Edge  _adjancencyMatrix[minIndex, v]>0
                // Check That the Currrent Vetex not Equals to int.MaxValue 
                //Perform Update if the Distance of the Target Vertex is Greater then  Distance of the Current vetex + Weight

                if (!Visited[v] && _adjancencyMatrix[minIndex, v]> 0 &&
                    Distances[minIndex]!=int.MaxValue
                    &&
                    Distances[minIndex] + _adjancencyMatrix[minIndex,v] < Distances[v]
                    )
                {
                    Distances[v] = Distances[minIndex] + _adjancencyMatrix[minIndex, v];
                    predecessor[v] = GetVertexName(minIndex);  //Record the Short path
                }


            }


        }



        //Add Thhe Paths To the array string[

        Dictionary<string,string> paths = new Dictionary<string,string>();


        for (int i = 0; i < _numberOfVerticies; i++)
        {
            string Vertex = GetVertexName(i);
            
            string result = string.Concat($"From [{Strat}] to [{GetVertexName(i)}]: D[{Distances[i]}]"
                , $"| Path = {GetPath(predecessor, i)} ");

            paths.Add(Vertex, result);
        }

        return paths;   
    }



    private string GetPath(string[] predecessor, int CurrentIndex)
    {
        if (predecessor[CurrentIndex] ==null)
            return GetVertexName(CurrentIndex);   

        return GetPath(predecessor, _vertexDictionary[predecessor[CurrentIndex]])+"->" + GetVertexName(CurrentIndex);   
    }



    private int MinimumIndex(int[] Distances,bool[] Visited)
    {
        int minDistance = int.MaxValue;
        int minIndex = -1; 

        for(int i = 0; i < _numberOfVerticies; i++)
        {
            if(!Visited[i] && Distances[i]< minDistance)
            {
                minDistance = Distances[i];
                minIndex = i;   
            }
        }
    
        return minIndex; 
    }

    // Dijkstra's Algorithm using Priority Queue (Min-Heap)
    public void Dijkstra(string startVertex)
    {
        // Validate the starting vertex
        if (!_vertexDictionary.ContainsKey(startVertex))
        {
            Console.WriteLine("Invalid start vertex.");
            return;
        }

        int startIndex = _vertexDictionary[startVertex]; // Get the index of the starting vertex

        // Array to store the shortest distance from the start vertex to each vertex
        int[] distances = new int[_numberOfVerticies];

        // Boolean array to track if a vertex has been visited
        bool[] visited = new bool[_numberOfVerticies];

        // Array to store the predecessor of each vertex in the shortest path
        string[] predecessors = new string[_numberOfVerticies];

        // Initialize distances to infinity and predecessors to null
        for (int i = 0; i < _numberOfVerticies; i++)
        {
            distances[i] = int.MaxValue; // Distance set to "infinity"
            predecessors[i] = null; // No predecessor initially
        }

        distances[startIndex] = 0; // Distance to the starting vertex is 0

        // Priority queue (Min-Heap) to store vertices with their distances
        var priorityQueue = new SortedSet<(int distance, int vertexIndex)>(
            Comparer<(int distance, int vertexIndex)>.Create((x, y) =>
                x.distance == y.distance ? x.vertexIndex.CompareTo(y.vertexIndex) : x.distance.CompareTo(y.distance))
        );

        // Add the starting vertex to the priority queue
        priorityQueue.Add((0, startIndex));

        // Process all vertices in the priority queue
        while (priorityQueue.Count > 0)
        {
            // Extract the vertex with the smallest distance
            var (currentDistance, currentIndex) = priorityQueue.Min;
            priorityQueue.Remove(priorityQueue.Min);

            // Skip the vertex if it's already visited
            if (visited[currentIndex]) continue;
            visited[currentIndex] = true; // Mark the vertex as visited

            // Update the distances for all neighbors of the current vertex
            for (int neighbor = 0; neighbor < _numberOfVerticies; neighbor++)
            {
                // Check if there is an edge and the neighbor is unvisited
                if (_adjancencyMatrix[currentIndex, neighbor] > 0 && !visited[neighbor])
                {
                    // Calculate the new distance to the neighbor
                    int newDistance = distances[currentIndex] + _adjancencyMatrix[currentIndex, neighbor];

                    // If the new distance is shorter, update it
                    if (newDistance < distances[neighbor])
                    {
                        priorityQueue.Remove((distances[neighbor], neighbor)); // Remove the old distance
                        distances[neighbor] = newDistance; // Update to the new distance
                        predecessors[neighbor] = GetVertexName(currentIndex); // Update the predecessor
                        priorityQueue.Add((newDistance, neighbor)); // Add the updated distance to the queue
                    }
                }
            }
        }

        // Print the shortest paths and their distances
        Console.WriteLine("\nShortest paths from vertex " + startVertex + ":");
        for (int i = 0; i < _numberOfVerticies; i++)
        {
            Console.WriteLine($"{startVertex} -> {GetVertexName(i)}: Distance = {distances[i]}, Path = {GetPath(predecessors, i)}");
        }
    }


}
