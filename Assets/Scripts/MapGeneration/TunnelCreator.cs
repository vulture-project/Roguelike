using System;
using System.Collections.Generic;
using MapGeneration.Algorithms;
using MapGeneration.MapPrimitives;
using UnityEngine;
using Grid = MapGeneration.MapPrimitives.Grid;
using Vec2 = UnityEngine.Vector2;
using Vec2i = UnityEngine.Vector2Int;

namespace MapGeneration
{
    public class TunnelCreator
    {
        private Grid _grid;
        private Grid _gridCopyForPathFinder;
        private List<Geometry.Rect> _rooms;
        private List<Delaunay.Vertex> _vertices;
        private List<EdgeAdjacent>[] _mst;
        private int _tunnelWidth;


        public TunnelCreator(Grid grid, List<Geometry.Rect> rooms, int tunnelWidth)
        {
            _grid = grid;
            _rooms = rooms;
            _vertices = new List<Delaunay.Vertex>();
            _tunnelWidth = tunnelWidth;
        }
        
        private static List<EdgeAdjacent>[] GetNewGraph(int cnt)
        {
            var graph = new List<EdgeAdjacent>[cnt];
            for (var i = 0; i < graph.Length; ++i)
            {
                graph[i] = new List<EdgeAdjacent>();
            }

            return graph;
        }

        private static void AddMissingEdgesToGraph(List<EdgeAdjacent>[] graph)
        {
            var missingEdges = new List<(int, int, float)>();
            for (var i = 0; i < graph.Length; ++i)
            {
                foreach (var edge in graph[i])
                {
                    missingEdges.Add((edge.v_id, i, edge.weight));
                }
            }

            for (var i = 0; i < missingEdges.Count; ++i)
            {
                var v1 = missingEdges[i].Item1;
                var v2 = missingEdges[i].Item2;
                var weight = missingEdges[i].Item3;
                graph[v1].Add(new EdgeAdjacent(v2, weight));
            }
        }
        
        public void CreateTunnels()
        {
            for (var i = 0; i < _rooms.Count; ++i)
            {
                var vertexId = i;
                var room = _rooms[i];
                var v = new Delaunay.Vertex(room.Pos + new Vec2(room.Width, room.Height) / 2, room, vertexId);
                _vertices.Add(v);
            }

            var delaunay = Delaunay.Triangulate(_vertices);
            var graph = GetNewGraph(_vertices.Count);

            var set = new HashSet<(int, int)>();
            foreach (var edge in delaunay.Edges)
            {
                var v1 = edge.U;
                var v2 = edge.V;
                Debug.Assert(v1.VertexId != -1 && v2.VertexId != -1);
                var id1 = v1.VertexId;
                var id2 = v2.VertexId;
                if (set.Contains((id1, id2)) || set.Contains((id2, id1))) continue;
                graph[id1].Add(new EdgeAdjacent(id2, v1.GetDistance(v2)));
                set.Add((id1, id2));
            }
            AddMissingEdgesToGraph(graph);

            _mst = MinSpanTree.FindMst(graph);
            PutTunnelsOnMap();
        }

        private void PutTunnelsOnMap()
        {
            _gridCopyForPathFinder = new Grid(_grid);
            var finder = new PathFinder(new Vector2Int(_grid.Dim, _grid.Dim));

            for (var v = 0; v < _mst.Length; ++v)
            {
                foreach (var edge in _mst[v])
                {
                    var startRoom = _vertices[v].Room;
                    var endRoom = _vertices[edge.v_id].Room;
                    var startPos = startRoom.Pos + new Vec2i(startRoom.Width, startRoom.Height) / 2;
                    var endPos = endRoom.Pos + new Vec2i(endRoom.Width, endRoom.Height) / 2;
                    PutPathOnMap(finder, startPos, endPos);
                }
            }
        }

        private void PutPathOnMap(PathFinder finder, Vec2i start, Vec2i end)
        {
            // var tmp = end - start;
            // var dir = new Vector2(tmp.x, tmp.y);
            // var len = dir.magnitude;
            // dir.Normalize();
            // var pos = new Vector2(start.x, start.y);
            //

            var path = finder.FindPath(_gridCopyForPathFinder, start, end);
            Debug.Assert(path != null);

            // foreach (var pos in path)
            // {
            //     if (grid.Data[pos.x, pos.y] == CellType.None)
            //     {
            //         grid.Data[pos.x, pos.y] = CellType.Tunnel;
            //     }
            // }

            var offsets = new List<(int, int)>();
            for (var i = 0; i < _tunnelWidth; ++i)
            {
                for (var j = 0; j < _tunnelWidth; ++j)
                {
                    offsets.Add((i - _tunnelWidth / 2, j - _tunnelWidth / 2));
                }
            }

            foreach (var pos in path)
            {
                if (_gridCopyForPathFinder.Data[pos.x, pos.y] == CellType.None)
                {
                    _gridCopyForPathFinder.Data[pos.x, pos.y] = CellType.Tunnel;
                }
            }
            
            foreach (var pos in path)
            {
                if (_grid.Data[pos.x, pos.y] == CellType.None)
                {
                    if (pos == new Vec2i(69, 69) || pos == new Vec2i(77, 69))
                    {
                        Debug.Log("logging pos: " + pos);
                        Debug.Log("start = " + start + " end = " + end);
                    }
                    _grid.Data[pos.x, pos.y] = CellType.Tunnel;
                }
            }
            
            // foreach (var pos in path)
            // {
            //     if (_grid.Data[pos.x, pos.y] == CellType.Room) continue;
            //     foreach (var ofs in offsets)
            //     {
            //         var x = (int)pos.x + ofs.Item1;
            //         var y = (int)pos.y + ofs.Item2;
            //         if (_grid.Data[x, y] == CellType.None)
            //         {
            //             _grid.Data[x, y] = CellType.Tunnel;
            //         }
            //     }
            // }
        }
    }
};