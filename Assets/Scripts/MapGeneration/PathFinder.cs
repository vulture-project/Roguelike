using System;
using System.Collections.Generic;
using UnityEngine;
using Vec2i = UnityEngine.Vector2Int;
using BlueRaja;
using MapGeneration.MapPrimitives;

namespace MapGeneration
{
    public class PathFinder
    {
        private class Grid
        {
            public Node[,] Data;
            public Vec2i Size;

            public Grid(Vec2i sz)
            {
                Data = new Node[sz.x, sz.y];
                Size = sz;
            }

            public bool InBounds(Vec2i v)
            {
                return v.x < Size.x && v.y < Size.y &&
                       v.x >= 0 && v.y >= 0;
            }
        }
        public class Node
        {
            public Vec2i Position { get; private set; }
            public Node Previous { get; set; }
            public float Cost { get; set; }

            public Node(Vec2i position)
            {
                Position = position;
            }
        }

        static readonly Vec2i[] neighbors =
        {
            new Vec2i(1, 0),
            new Vec2i(-1, 0),
            new Vec2i(0, 1),
            new Vec2i(0, -1),
        };

        private Grid gridNode;
        private SimplePriorityQueue<Node, float> queue;
        private HashSet<Node> visited;

        public PathFinder(Vec2i size)
        {
            gridNode = new Grid(size);
            queue = new SimplePriorityQueue<Node, float>();
            visited = new HashSet<Node>();

            for (var x = 0; x < size.x; x++)
            {
                for (var y = 0; y < size.y; y++)
                {
                    gridNode.Data[x, y] = new Node(new Vec2i(x, y));
                }
            }
            ResetNodes();
        }

        private void ResetNodes()
        {
            var size = gridNode.Size;

            for (var x = 0; x < size.x; x++)
            {
                for (var y = 0; y < size.y; y++)
                {
                    var node = gridNode.Data[x, y];
                    node.Previous = null;
                    node.Cost = float.PositiveInfinity;
                }
            }
        }

        private float FindCost(MapPrimitives.Grid grid, Node b, Vec2i endPos)
        {
            // var cost = Vec2i.Distance(b.Position, endPos) / 10;
            var cost = 0;
            // switch (grid.Data[b.Position.x, b.Position.y])
            // {
            //     case CellType.Room:
            //         cost += 10;
            //         break;
            //     case CellType.None:
            //         cost += 10;
            //         break;
            //     case CellType.Tunnel:
            //         cost += 2;
            //         break;
            //     default:
            //         throw new ArgumentOutOfRangeException();
            // }
            
            switch (grid.Data[b.Position.x, b.Position.y])
            {
                case CellType.Room:
                    cost += 10;
                    break;
                case CellType.None:
                    cost += 10;
                    break;
                case CellType.Tunnel:
                    cost += 2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return cost;
        }
        
        private List<Vec2i> ReconstructPath(Node node)
        {
            var stack = new Stack<Vec2i>();
            var res = new List<Vec2i>();

            while (node != null)
            {
                stack.Push(node.Position);
                node = node.Previous;
            }

            while (stack.Count > 0)
            {
                res.Add(stack.Pop());
            }

            return res;
        }

        public List<Vec2i> FindPath(MapPrimitives.Grid grid, Vec2i start, Vec2i end)
        {
            ResetNodes();
            queue.Clear();
            visited.Clear();
            
            gridNode.Data[start.x, start.y].Cost = 0;
            queue.Enqueue(gridNode.Data[start.x, start.y], 0);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                visited.Add(node);

                if (node.Position == end)
                {
                    return ReconstructPath(node);
                }

                foreach (var ofs in neighbors)
                {
                    if (!gridNode.InBounds(node.Position + ofs)) continue;
                    var neighborPos = node.Position + ofs;
                    var neighbor = gridNode.Data[neighborPos.x, neighborPos.y];
                    if (visited.Contains(neighbor)) continue;

                    var neighborCost = node.Cost + FindCost(grid, neighbor, end);

                    if (neighborCost < neighbor.Cost)
                    {
                        neighbor.Previous = node;
                        neighbor.Cost = neighborCost;

                        if (queue.TryGetPriority(node, out float existingPriority))
                        {
                            queue.UpdatePriority(node, neighborCost);
                        }
                        else
                        {
                            queue.Enqueue(neighbor, neighbor.Cost);
                        }
                    }
                }
            }

            return null;
        }
    }
}