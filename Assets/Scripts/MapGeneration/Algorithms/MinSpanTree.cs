using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MapGeneration.Algorithms
{
    public struct EdgeAdjacent
    {
        public int v_id;
        public float weight;

        public EdgeAdjacent(int v, float w)
        {
            v_id = v;
            weight = w;
        }
    }

    // public struct Edge
    // {
    //     public int u;
    //     public int v;
    //     public int weight;
    // }

    public class MinSpanTree
    {
        private static bool EdgeExists(List<EdgeAdjacent>[] graph, int v1, int v2, float weight)
        {
            var l = graph[v1];
            foreach (var adjEdge in l)
            {
                if (adjEdge.v_id == v2)
                {
                    weight = adjEdge.weight;
                    return true;
                }
            }

            return false;
        }

        private static void MstInitialize(List<EdgeAdjacent>[] mst)
        {
            for (var i = 0; i < mst.Length; ++i)
            {
                mst[i] = new List<EdgeAdjacent>();
            }
        }
        
        public static List<EdgeAdjacent>[] FindMst(List<EdgeAdjacent>[] graph)
        {
            if (graph.Length < 1) throw new Exception("invalid graph passed to function");

            var mst = new List<EdgeAdjacent>[graph.Length];
            MstInitialize(mst);
            var isVertexInMst = new bool[graph.Length];
            for (var i = 0; i < isVertexInMst.Length; ++i)
            {
                isVertexInMst[i] = false;
            }
            isVertexInMst[0] = true;

            for (var verticesInMstNumber = 1; verticesInMstNumber < graph.Length; ++verticesInMstNumber)
            {
                var edgeMinWeight = 100000.0f;
                var minv1 = -1;
                var minv2 = -1;

                for (var vis_i = 0; vis_i < isVertexInMst.Length; ++vis_i)
                {
                    if (!isVertexInMst[vis_i]) continue;
                    for (var unvis_i = 0; unvis_i < isVertexInMst.Length; ++unvis_i)
                    {
                        if (isVertexInMst[unvis_i]) continue;
                        var weight = 0.0f;
                        if (!EdgeExists(graph, vis_i, unvis_i, weight)) continue;
                        if (weight >= edgeMinWeight) continue;
                        edgeMinWeight = weight;
                        minv1 = vis_i;
                        minv2 = unvis_i;
                    }
                }

                mst[minv1].Add(new EdgeAdjacent(minv2, edgeMinWeight));
                // mst[minv2].Add(new EdgeAdjacent(minv1, edgeMinWeight));
                isVertexInMst[minv2] = true;
            }

            return mst;
        }
    }
}