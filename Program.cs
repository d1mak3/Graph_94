/**
 * Цикломатическая сложность считается по V(G) = E - N + 2 * P
 * Где:
 * E - количество дуг
 * N - количество узлов
 * P - Количество компонент связанности
 */

using System;
using System.Collections.Generic;

namespace Graphs_94
{
	class Program
	{
		static int[,] GenerateRandomEdges(int max, int numOfEdges)
		{
			int[,] nodesToConnect = new int[numOfEdges, 2];

			for (int i = 0; i < numOfEdges; ++i)
			{
				Random randomNum = new Random();
				int start = randomNum.Next(1, max);
				int finish = randomNum.Next(1, max);

				int j = 0;
				while(j < numOfEdges - 1)
				{
					for (j = 0; j < numOfEdges; ++j)
					{
						if (nodesToConnect[j, 0] == start && nodesToConnect[j, 1] == finish)
							break;
					}

					if (j < numOfEdges)
					{
						start = randomNum.Next(1, max);
						finish = randomNum.Next(1, max);
					}
				}

				nodesToConnect[i, 0] = start;
				nodesToConnect[i, 1] = finish;
			}

			return nodesToConnect;
		}

		static Node FindNodeByNumber(List<Node> listToHandle, int number)
		{
			foreach (Node n in listToHandle)
				if (n.Number == number)
					return n;
			return null;
		}

		static void Main()
		{
			Graph graph = new Graph();

			Console.WriteLine("Введите количество вершин и количество дуг графа: ");
			string[] input = Console.ReadLine().Split(' ');

			int numOfNodes = Convert.ToInt32(input[0]);
			int numOfEdges = Convert.ToInt32(input[1]);

			if (input.Length > 2 && (numOfNodes * numOfNodes) < numOfEdges)
				throw new Exception("Invalid input");

			List<Node> nodesToPush = new List<Node>();

			for (int i = 1; i < numOfNodes + 1; ++i)
			{
				nodesToPush.Add(new Node(i));
				graph.PushNode(nodesToPush[i - 1]);
			}

			int[,] randomEdges = GenerateRandomEdges(nodesToPush.Count + 1, numOfEdges);			

			for (int i = 0; i < numOfEdges; ++i)
			{
				Node startFoundByNumber = FindNodeByNumber(nodesToPush, randomEdges[i, 0]);
				Node finishFoundByNumber = FindNodeByNumber(nodesToPush, randomEdges[i, 1]);

				graph.ConnectNodes(startFoundByNumber, finishFoundByNumber);
			}

			graph.PrintMatrix();

			Console.WriteLine($"Цикломатическая сложность графа: {graph.CyclomaticComplexity}");
		}
	}
}
