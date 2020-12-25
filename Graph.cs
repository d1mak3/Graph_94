using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs_94
{
	class Graph
	{
		List<int> _numbersOfNodes = new List<int>();
		List<Edge> _edges = new List<Edge>();

		public void PushNode(int newNode)
		{
			_numbersOfNodes.Add(newNode);
		}

		public void ConnectNodes(int startNode, int finishNode)
		{
			_edges.Add(new Edge(startNode, finishNode));
		}

		public void PrintMatrix()
		{
			string[,] matrix = new string[_numbersOfNodes.Count + 1, _numbersOfNodes.Count + 1];
			
			for (int i = 0; i < _numbersOfNodes.Count + 1; ++i)
			{
				for (int j = 0; j < _numbersOfNodes.Count + 1; ++j)
				{
					matrix[i, j] = "0";
				}
			}
			matrix[0, 0] = " ";

			for (int i = 1; i < _numbersOfNodes.Count + 1; ++i)
			{
				matrix[0, i] = $"X{i}";
				matrix[i,0] = $"X{i}";
			}

			foreach (Edge e in _edges)
				matrix[e.startNode, e.finishNode] = "1";

			for (int i = 0; i < _numbersOfNodes.Count + 1; ++i)
			{
				for (int j = 0; j < _numbersOfNodes.Count + 1; ++j)
				{
					if (matrix[j,i].IndexOf("X") != -1)
						Console.Write(matrix[i, j] + "  ");
					else
						Console.Write(matrix[i, j] + "   ");
				}
				Console.WriteLine();
			}
		}
	}
}
