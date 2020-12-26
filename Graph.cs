using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs_94
{
	class Graph
	{
		List<Node> _nodes = new List<Node>();
		List<Edge> _edges = new List<Edge>();
		string[,] _matrix = new string[0,0];
		int connectedComponent = 0; // Компонента связности

		public void PushNode(Node newNode)
		{
			if (_nodes.Contains(newNode) == false && newNode.Number <= _nodes.Count + 1)
				_nodes.Add(newNode);
		}

		public void ConnectNodes(Node startNode, Node finishNode)
		{
			if (_nodes.Contains(startNode) && _nodes.Contains(finishNode))
				_edges.Add(new Edge(startNode, finishNode));
		}

		private void GenerateMatrix()
		{			
			_matrix = new string[_nodes.Count + 1, _nodes.Count + 1];

			for (int i = 0; i < _nodes.Count + 1; ++i)
			{
				for (int j = 0; j < _nodes.Count + 1; ++j)
				{
					_matrix[i, j] = "0";
				}
			}
			_matrix[0, 0] = " ";

			for (int i = 1; i < _nodes.Count + 1; ++i)
			{
				_matrix[0, i] = $"X{i}";
				_matrix[i, 0] = $"X{i}";
			}

			foreach (Edge e in _edges)
				_matrix[e.StartNode.Number, e.FinishNode.Number] = "1";
		}

		public void PrintMatrix()
		{
			GenerateMatrix();

			for (int i = 0; i < _nodes.Count + 1; ++i)
			{
				for (int j = 0; j < _nodes.Count + 1; ++j)
				{
					if (_matrix[j, i].IndexOf("X") != -1)
						Console.Write(_matrix[i, j] + "  ");
					else
						Console.Write(_matrix[i, j] + "   ");
				}
				Console.WriteLine();
			}
		}		

		private void CountConnectedComponent()
		{
			if (_edges.Count == 1)
			{
				connectedComponent = 1;
				return;
			}
			else if (_edges.Count <= 0)
				return;
			
			else
				connectedComponent = 0;

			GenerateMatrix();
			
			foreach (Edge e in _edges)
			{
				if (e.StartNode.IsChecked == false)
				{					
					connectedComponent += 1;
					FindPath(e.StartNode);		
				}
			}
		}
		
		private void FindPath(Node nodeToCheck)
		{
			if (nodeToCheck.IsChecked == true)
				return;

			nodeToCheck.Check();
					
			foreach(Edge n in _edges)
			{
				if (n.StartNode == nodeToCheck && n.FinishNode.IsChecked == false)
				{					
					FindPath(n.FinishNode);
				}
			}
		}

		public int CyclomaticComplexity
		{
			get
			{
				CountConnectedComponent();
				return _edges.Count - _nodes.Count + (2 * connectedComponent);
			}
		}
	}
}