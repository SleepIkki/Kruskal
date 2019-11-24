using System;
using System.Collections.Generic;
using System.Text;

namespace Kruskal
{
    class GraphEdge
    {
        public int Point1 { get; }
        public int Point2 { get; }
        public int Weight { get; set; }

        public GraphEdge(int p1, int p2, int weight)
        {
            Point1 = p1;
            Point2 = p2;
            Weight = weight;
        }
    }
}
