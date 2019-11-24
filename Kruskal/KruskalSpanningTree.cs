using System;
using System.Collections.Generic;
using System.Text;

namespace Kruskal
{
    class KruskalSpanningTree
    {
        public List<GraphEdge> NotUsedEdges { get; } = new List<GraphEdge>();
        public List<GraphEdge> SpanningTree { get; } = new List<GraphEdge>();
        List<int> UsedPoints = new List<int>();
        List<int> NotUsedPoints = new List<int>();

        public KruskalSpanningTree(List<GraphEdge> graph)
        {
            NotUsedEdges = graph;
            NotUsedPoints = GetPoints(graph);
        }

        public void Kruskal()
        {
            while (NotUsedPoints.Count > 0)
            {
                GraphEdge minEdge = NotUsedEdges[0];

                for (int i = 0; i < NotUsedEdges.Count; ++i)
                {
                    if (minEdge.Weight > NotUsedEdges[i].Weight)
                        minEdge = NotUsedEdges[i];
                }

                if (!UsedPoints.Contains(minEdge.Point1) || !UsedPoints.Contains(minEdge.Point2))
                {

                    SpanningTree.Add(minEdge);

                    if (!UsedPoints.Contains(minEdge.Point1))
                    {
                        UsedPoints.Add(minEdge.Point1);
                        NotUsedPoints.Remove(minEdge.Point1);
                    }

                    if (!UsedPoints.Contains(minEdge.Point2))
                    {
                        UsedPoints.Add(minEdge.Point2);
                        NotUsedPoints.Remove(minEdge.Point2);
                    }   
                }
                NotUsedEdges.Remove(minEdge);
            }
        }

        public List<int> GetPoints(List<GraphEdge> graph)
        {
            List<int> points = new List<int>();

            for (int i = 0; i < graph.Count; ++i)
            {
                if (points == null || !points.Contains(graph[i].Point1))
                    points.Add(graph[i].Point1);
                if (points == null || !points.Contains(graph[i].Point2))
                    points.Add(graph[i].Point2);
            }

            return points;
        }

        public override string ToString()
        {
            string spanningTree = "";
            for (int i = 0; i < SpanningTree.Count; ++i)
                spanningTree += ("Point1: " + SpanningTree[i].Point1 +
                    "\tPoint2: " + SpanningTree[i].Point2 +
                    "\tWeight: " + SpanningTree[i].Weight) + "\n";
            return spanningTree;
        }
    }
}
