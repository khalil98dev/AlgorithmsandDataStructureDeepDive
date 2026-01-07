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



}
