using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs_94
{
	// Дуга графа
	class Edge
	{
		public int startNode { get; }
		public int finishNode { get; }

		public Edge(int newStart, int newFinish)
		{
			startNode = newStart;
			finishNode = newFinish;
		}
	}
}
