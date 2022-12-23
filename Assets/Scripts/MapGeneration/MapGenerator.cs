using System;
using System.Collections.Generic;
using UnityEngine;
using Grid = MapGeneration.MapPrimitives.Grid;
using Vec2 = UnityEngine.Vector2;
using Vec2i = UnityEngine.Vector2Int;
using Vec3 = UnityEngine.Vector3;
using MapGeneration.MapPrimitives;

using Core;
using Factories;
using MapGeneration.Algorithms;
using Unity.AI.Navigation;

namespace MapGeneration
{
    public class MapGenerator : Singleton<MapGenerator>
    {
        // FIXME: ArrangeRooms is need to be fixed, mapDensityScale > 0.4 crashes program
        [SerializeField] private float _mapDensityScale; // value from 0 to 1
        [SerializeField] private uint _levelNum = 20; // value from 1 to inf
        [SerializeField] private uint _roomMinDim = 40;
        [SerializeField] private uint _roomMaxDim = 50;
        [SerializeField] private uint _tunnelWidth = 5;
        [SerializeField] private int _seed = 10;

        // walls are ought to be 1 meter, floors are 1 by 1 meter
        [SerializeField] private GameObject _roomWall;
        [SerializeField] private GameObject _tunnelWall;
        [SerializeField] private GameObject _roomFloor;
        [SerializeField] private GameObject _tunnelFloor;
        [SerializeField] private GameObject _planePlane;

        private Grid _grid;
        private List<Geometry.Rect> _rooms;
        
        private HealPotionFactory _healPotionFactory;
        private ManaPotionFactory _manaPotionFactory;
        private WizardFactory _wizardFactory;
        private SkeletonFactory _skeletonFactory;
        private SpiderFactory _spiderFactory;
        public void Init()
        {
            SetInstance(this);
            _healPotionFactory = HealPotionFactory.Instance();
            _manaPotionFactory = ManaPotionFactory.Instance();
            _wizardFactory = WizardFactory.Instance();
            _skeletonFactory = SkeletonFactory.Instance();
            _spiderFactory = SpiderFactory.Instance();
        }
        
        // public class HelloWorld
        // {
        //     struct S
        //     {
        //         public int a;
        //         public int b;
        //     }
        //
        //     class MM
        //     {
        //         public S s;
        //
        //         public MM(S s_)
        //         {
        //             s = s_;
        //         }
        //
        //         public (S s, MM) Lol()
        //         {
        //             s.a = 1;
        //             s.b = 1;
        //             return (s, this);
        //         }
        //     }
        //     public static void Main(string[] args)
        //     {
        //         Console.WriteLine(Math.Round(2.9, MidpointRounding.AwayFromZero));
        //     }
        // }

        public void Generate()
        {
            Debug.Assert(_mapDensityScale is >= 0 and <= 1);
            Debug.Assert(_levelNum > 0);
            Debug.Assert(_roomMinDim <= _roomMaxDim);

            Debug.Log("Map creation started");
            var numOfRooms = _levelNum;
            (_grid, _rooms) = RoomsArranger.ArrangeRooms(_mapDensityScale, numOfRooms, _roomMinDim / _tunnelWidth, _roomMaxDim / _tunnelWidth, _seed);
            Debug.Log("Rooms arranging finished");
            
            var tunnelCreator = new TunnelCreator(_grid, _rooms, (int)_tunnelWidth);
            tunnelCreator.CreateTunnels();
            Debug.Log("Tunnels creation finished");

            CreateGameObjects();
            Debug.Log("Map creation finished");

            var plane = Instantiate(_planePlane, new Vec3(0.5f, 0, 0.5f), Quaternion.identity);
            plane.transform.localScale = new Vec3(_grid.Dim, 1, _grid.Dim);
            var m = plane.GetComponent<NavMeshSurface>();
            m.BuildNavMesh();

            var spawnRoom = _rooms[0];

            var position = spawnRoom.Pos + new Vector2Int(spawnRoom.Width / 2, spawnRoom.Height / 2);
            _wizardFactory.Spawn(new Vector3(position.x * _tunnelWidth, 0, position.y * _tunnelWidth));
            
            // _healPotionFactory.Spawn(new Vector3(2f, 0f, 2f));
            // _manaPotionFactory.Spawn(new Vector3(-2f, 0f, 2f));
        }


        private GameObject WhichWallToInstantiate(CellType cellVal)
        {
            return _roomWall;
            // return cellVal switch
            // {
            //     CellType.Room => _roomWall,
            //     CellType.Tunnel => _tunnelWall,
            //     _ => throw new Exception("should not be here")
            // };
        }
        
        private GameObject WhichFloorToInstantiate(CellType cellVal)
        {
            return _roomFloor;
            // return cellVal switch
            // {
            //     CellType.Room => _roomFloor,
            //     CellType.Tunnel => _tunnelFloor,
            //     _ => throw new Exception("should not be here")
            // };
        }
        
        private void InstantiateWall(int x1, int y1, int x2, int y2, CellType cellVal)
        {
            Debug.Assert(x1 == x2 || y1 == y2);
            var pos1 = new Vec2i(x1, y1);
            var pos2 = new Vec2i(x2, y2);

            if (pos1.x > pos2.x)
                (pos1, pos2) = (pos2, pos1);
            if (pos1.y > pos2.y)
                (pos1, pos2) = (pos2, pos1);

            var rotation = pos1.x == pos2.x ? Quaternion.identity : Quaternion.Euler(0, 90, 0);

            Instantiate(WhichWallToInstantiate(cellVal),
                new Vec3(_tunnelWidth * pos1.x, 0, _tunnelWidth * pos1.y), rotation);
            
            // if (pos1.x != pos2.x)
            // {
            //     for (var i = 0; i < _tunnelWidth; ++i)
            //     {
            //         Instantiate(WhichWallToInstantiate(cellVal),
            //             new Vec3(_tunnelWidth * pos1.x + i, 0, _tunnelWidth * pos1.y), rotation);
            //     }
            // }
            // else
            // {
            //     for (var i = 0; i < _tunnelWidth; ++i)
            //     {
            //         Instantiate(WhichWallToInstantiate(cellVal),
            //             new Vec3(_tunnelWidth * pos1.x, 0, _tunnelWidth * pos1.y + i), rotation);
            //     }
            // }
        }
        
        // public static Vec2 Rotate(Vector2 v, float degrees) {
        //     var sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        //     var cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
        //     var tx = v.x;
        //     var ty = v.y;
        //     v.x = (cos * tx) - (sin * ty);
        //     v.y = (sin * tx) + (cos * ty);
        //     return v;
        // }

        private void InstantiateDiagonalWall(Vec2 pos1, Vec2 pos2)
        {
            var dir = pos2 - pos1;
            var len = (int)(Mathf.Round(dir.magnitude) + 0.1);
            dir.Normalize();
            var pos = pos1;
            
            for (var i = 0; i < len; ++i)
            {
                var angle = Vec2.Angle(dir, Vec2.up);
                if (pos2.x < pos1.x)
                    angle = -angle;
                
                var rot = Quaternion.Euler(0, angle, 0);
                Instantiate(_tunnelWall, new Vec3(_tunnelWidth * pos.x, 0, _tunnelWidth * pos.y), rot);
                pos += dir;
            }
        }
        
        private void GraphDump(List<EdgeAdjacent>[] graph, List<Delaunay.Vertex> vertices)
        {
            for (var i = 0; i < graph.Length; ++i)
            {
                var v1 = vertices[i];
                foreach (var edge in graph[i])
                {
                    var v2 = vertices[edge.v_id];
                    InstantiateDiagonalWall(v1.Position, v2.Position);
                }
            }
        }
        
        // private void DumpMst(List<EdgeAdjacent>[] mst, List<Delaunay.Vertex> vertices)
        // {
        //     for (var i = 0; i < mst.Length; ++i)
        //     {
        //         var v1 = vertices[i];
        //         foreach (var edge in mst[i])
        //         {
        //             
        //         }
        //     }
        // }

        private void GenerateBorder()
        {
            for (var x = 0; x < _grid.Dim; ++x)
            {
                for (var y = 0; y < _grid.Dim; ++y)
                {
                    if (x == 0 || y == 0 || x == _grid.Dim - 1 || y == _grid.Dim - 1)
                        Instantiate(_tunnelFloor, new Vec3(_tunnelWidth * x, 0, _tunnelWidth * y),
                            Quaternion.identity);
                }
            }
        }
        //
        // private enum Dir
        // {
        //     Right,
        //     Down,
        //     Left,
        //     Up
        // };
        //
        // private class NextPosFinder
        // {
        //     private int _x;
        //     private int _y;
        //     private Dir _tileDir;
        //     private Dir _traverseDir;
        //     private readonly Grid _grid;
        //
        //     public NextPosFinder(Grid grid)
        //     {
        //         _traverseDir = Dir.Up;
        //         _grid = grid;
        //         var gridDim = _grid.Dim;
        //         for (var y = 0; y < gridDim; ++y)
        //         {
        //             for (var x = 0; x < gridDim; ++x)
        //             {
        //                 if (_grid.Data[x, y] != CellType.None)
        //                 {
        //                     _x = x;
        //                     _y = y;
        //                     if (x == 0)
        //                     {
        //                         
        //                     }
        //                 }
        //             }
        //         }
        //     }
        //
        //     public (Vec2i, Dir) GetNextPos()
        //     {
        //         var returnCell = new Vec2i(_x, _y);
        //         if (_traverseDir == Dir.Right)
        //         {
        //             ++_x;
        //             if (_x >= _grid.Dim || _grid.Data[_x, _y] == CellType.None)
        //             {
        //                 _traverseDir = Dir.Down;
        //                 --_x;
        //                 --_y;
        //                 if ()
        //             }
        //         }
        //     }
        // };

        private void CreateGameObjects()
        {
            var gridDim = _grid.Dim;
            // var nextTile = new NextTileGiver(_grid);
            for (var x = 0; x < gridDim; ++x)
            {
                for (var y = 0; y < gridDim; ++y)
                {
                    var cellVal = _grid.At(x, y);
                    if (cellVal == CellType.None) continue;
                    
                    var up = _grid.At(x, y + 1);
                    var down = _grid.At(x, y - 1);
                    var left = _grid.At(x - 1, y);
                    var right = _grid.At(x + 1, y);
            
                    if (up == CellType.None)
                    {
                        InstantiateWall(x, y + 1, x + 1, y + 1, cellVal);
                    }
                    if (down == CellType.None)
                    {
                        InstantiateWall(x, y, x + 1, y, cellVal);
                    }
                    if (left == CellType.None)
                    {
                        InstantiateWall(x, y, x, y + 1, cellVal);
                    }
                    if (right == CellType.None)
                    {
                        InstantiateWall(x + 1, y, x + 1, y + 1, cellVal);
                    }
                    Instantiate(WhichFloorToInstantiate(cellVal), new Vec3(_tunnelWidth * x, 0, _tunnelWidth * y), Quaternion.identity);
                }
            }

            GenerateBorder();
        }
    }
}