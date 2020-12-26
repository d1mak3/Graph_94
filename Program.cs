/**
 * Цикломатическая сложность считается по V(G) = E - N + 2 * P
 * Где:
 * E - количество дуг
 * N - количество узлов
 * Количество компонент связанности
 */

using System;
using System.Collections.Generic;

namespace Graphs_94
{
	class Program
	{
		static void Main()
		{
			Graph graph = new Graph();
			List<Node> nodes = new List<Node>();

			for (int i = 1; i <= 5; ++i)
			{
				nodes.Add(new Node(i));
			}

			foreach (Node n in nodes)
				graph.PushNode(n);

			graph.ConnectNodes(nodes[0], nodes[1]);
			graph.ConnectNodes(nodes[1], nodes[2]);
			graph.ConnectNodes(nodes[2], nodes[0]);
			graph.ConnectNodes(nodes[0], nodes[2]);
			graph.ConnectNodes(nodes[3], nodes[4]);


			graph.PrintMatrix();

			Console.WriteLine($"Цикломатическая сложность графа: {graph.CyclomaticComplexity}");
		}
	}
}
