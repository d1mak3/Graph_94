namespace Graphs_94
{
	// Дуга графа
	class Edge
	{
		public Node StartNode { get; }
		public Node FinishNode { get; }

		public Edge(Node newStart, Node newFinish)
		{
			StartNode = newStart;
			FinishNode = newFinish;
		}
	}
}
