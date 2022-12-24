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
using Random = System.Random;

namespace MapGeneration
{
    public class MapGenerator : Singleton<MapGenerator>
    {
        [SerializeField] private float _mapDensityScale = 0.2f; // value from 0 to 1
        [SerializeField] private int _columnsMaxNum = 8;
        [SerializeField] private uint _skeletonsNumMax = 5;
        [SerializeField] private uint _spidersNumMax = 5;
        [SerializeField] private uint _orkNumMax = 5;
        [SerializeField] private uint _lichNumMax = 5;
        [SerializeField] private uint _levelNum = 20; // value from 1 to inf
        [SerializeField] private uint _roomMinDim = 40;
        [SerializeField] private uint _roomMaxDim = 50;
        [SerializeField] private uint _tunnelWidth = 5;
        [SerializeField] private int _seed = 10;

        // walls are ought to be 1 meter, floors are 1 by 1 meter
        [SerializeField] private GameObject _roomWall;
        [SerializeField] private GameObject _roomWallWithTorch;
        [SerializeField] private GameObject _tunnelWallWithTorch;
        [SerializeField] private GameObject _tunnelWall;
        [SerializeField] private GameObject _roomFloor;
        [SerializeField] private GameObject _tunnelFloor;
        [SerializeField] private GameObject _column0;
        [SerializeField] private GameObject _column1;
        [SerializeField] private GameObject _navMeshPlane;
        [SerializeField] private GameObject _roomPrefab;

        [SerializeField] private GameObject _room;
        
        private Grid _grid;
        private List<Geometry.Rect> _rooms;
        private Random _randomGenerator;
        private int _wallCnt;
        
        private HealPotionFactory _healPotionFactory;
        private ManaPotionFactory _manaPotionFactory;
        private SpeedPotionFactory _speedPotionFactory;
        private WizardFactory _wizardFactory;
        private SkeletonFactory _skeletonFactory;
        private SpiderFactory _spiderFactory;
        private OrkFactory _orkFactory;
        private LichFactory _lichFactory;
        
        public void Init()
        {
            SetInstance(this);
            _healPotionFactory = HealPotionFactory.Instance();
            _manaPotionFactory = ManaPotionFactory.Instance();
            _speedPotionFactory = SpeedPotionFactory.Instance();
            _wizardFactory = WizardFactory.Instance();
            _skeletonFactory = SkeletonFactory.Instance();
            _spiderFactory = SpiderFactory.Instance();
            _orkFactory = OrkFactory.Instance();
            _lichFactory = LichFactory.Instance();
        }

        public void Generate()
        {
            Debug.Assert(_mapDensityScale is >= 0 and <= 1);
            Debug.Assert(_levelNum > 0);
            Debug.Assert(_roomMinDim <= _roomMaxDim);

            _randomGenerator = new Random(_seed);
            _wallCnt = 0;

            var numOfRooms = _levelNum;
            (_grid, _rooms) = RoomsArranger.ArrangeRooms(_mapDensityScale, numOfRooms, _roomMinDim / _tunnelWidth, _roomMaxDim / _tunnelWidth, _randomGenerator);
            
            var tunnelCreator = new TunnelCreator(_grid, _rooms, (int)_tunnelWidth);
            tunnelCreator.CreateTunnels();

            InstantiateWallsAndFloors();
            TranslateRoomCoordinates();
            InstantiateInterior();
            AddNavMesh();
            SpawnHeroes();
        }
        
        private Vec3 TranslateCoordinate(Vec2 pos)
        {
            return new Vec3(pos.x * _tunnelWidth, 0, pos.y * _tunnelWidth);
        }

        private Vec3 TranslateCoordinate(Vec2i pos)
        {
            return new Vec3(pos.x * _tunnelWidth, 0, pos.y * _tunnelWidth);
        }
        
        private Vec3 GetVec3(Vec2i pos)
        {
            return new Vec3(pos.x, 0, pos.y);
        }
        
        private void TranslateRoomCoordinates()
        {
            foreach (var room in _rooms)
            {
                room.Pos *= (int)_tunnelWidth;
                room.Width *= (int)_tunnelWidth;
                room.Height *= (int)_tunnelWidth;
            }
        }
        
        private void SpawnHeroes() {
            var spawnRoom = _rooms[0];
            var position = spawnRoom.Pos + new Vec2i(spawnRoom.Width / 2, spawnRoom.Height / 2);
            var wizard = _wizardFactory.Spawn(new Vec3(position.x, 0, position.y));
            var curRoom = Instantiate(_roomPrefab, Vector3.zero, Quaternion.identity);
            // _skeletonFactory.Spawn(wizard.transform.position = new Vector3(5f, 0f, 5f), curRoom, wizard);
            // _orkFactory.Spawn(new Vec3(position.x + 5, 0, position.y + 5), curRoom, wizard);
            
            foreach (var room in _rooms)
            {
                var curRoomPrefab = Instantiate(_roomPrefab, Vector3.zero, Quaternion.identity);
                
                var skeletonsNum = _randomGenerator.Next(0, (int)_skeletonsNumMax + 1);
                for (var i = 0; i < skeletonsNum; ++i)
                {
                    var pos = room.Pos + new Vec2i(_randomGenerator.Next(0, room.Width),
                        _randomGenerator.Next(0, room.Height));
                    _skeletonFactory.Spawn(new Vec3(pos.x, 0, pos.y), curRoomPrefab, wizard);
                }
                
                var spidersNum = _randomGenerator.Next(0, (int)_spidersNumMax + 1);
                for (var i = 0; i < spidersNum; ++i)
                {
                    var pos = room.Pos + new Vec2i(_randomGenerator.Next(0, room.Width),
                        _randomGenerator.Next(0, room.Height));
                    _spiderFactory.Spawn(new Vec3(pos.x, 0, pos.y), curRoomPrefab, wizard);
                }
                
                var lichNum = _randomGenerator.Next(0, (int)_lichNumMax + 1);
                for (var i = 0; i < lichNum; ++i)
                {
                    var pos = room.Pos + new Vec2i(_randomGenerator.Next(0, room.Width),
                        _randomGenerator.Next(0, room.Height));
                    _lichFactory.Spawn(new Vec3(pos.x, 0, pos.y), curRoomPrefab, wizard);
                }
                
                var orkNum = _randomGenerator.Next(0, (int)_orkNumMax + 1);
                for (var i = 0; i < orkNum; ++i)
                {
                    var pos = room.Pos + new Vec2i(_randomGenerator.Next(0, room.Width),
                        _randomGenerator.Next(0, room.Height));
                    _orkFactory.Spawn(new Vec3(pos.x, 0, pos.y), curRoomPrefab, wizard);
                }
            }
        }

        private void AddNavMesh() {
            var plane = Instantiate(_navMeshPlane, new Vec3(0.5f, 0, 0.5f), Quaternion.identity);
            plane.transform.localScale = new Vec3(_grid.Dim, 1, _grid.Dim);
            var m = plane.GetComponent<NavMeshSurface>();
            m.BuildNavMesh();
        }

        private GameObject WhichWallToInstantiate(CellType cellVal)
        {
            switch (cellVal)
            {
                case CellType.Room:
                    return (_wallCnt++ % 4 == 0 ? _roomWall : _roomWallWithTorch);
                case CellType.Tunnel:
                    return (_wallCnt++ % 4 == 0 ? _tunnelWall : _tunnelWallWithTorch);
                default: throw new Exception("should not be here");
            }
        }
        
        private GameObject WhichFloorToInstantiate(CellType cellVal)
        {
            return cellVal switch
            {
                CellType.Room => _roomFloor,
                CellType.Tunnel => _tunnelFloor,
                _ => throw new Exception("should not be here")
            };
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

            Instantiate(WhichWallToInstantiate(cellVal), TranslateCoordinate(pos1), rotation);
        }

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
                Instantiate(_tunnelWall, TranslateCoordinate(pos), rot);
                pos += dir;
            }
        }

        private void GenerateBorder()
        {
            for (var x = 0; x < _grid.Dim; ++x)
            {
                for (var y = 0; y < _grid.Dim; ++y)
                {
                    if (x == 0 || y == 0 || x == _grid.Dim - 1 || y == _grid.Dim - 1)
                        Instantiate(_tunnelFloor, TranslateCoordinate(new Vec2i(x, y)),
                            Quaternion.identity);
                }
            }
        }

        private void InstantiateWallsAndFloors()
        {
            var gridDim = _grid.Dim;
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
                    Instantiate(WhichFloorToInstantiate(cellVal), TranslateCoordinate(new Vec2i(x, y)), Quaternion.identity);
                }
            }

            GenerateBorder();
        }

        private static void AddElemIfAble(List<Vec2i> list, Vec2i elem)
        {
            if (list.Count == 0)
            {
                list.Add(elem);
                return;
            }
            foreach (var v in list)
            {
                if (Vec2i.Distance(v, elem) < 8)
                {
                    return;
                }
            }
            list.Add(elem);
        }

        private void InstantiateInterior()
        {
            foreach (var room in _rooms)
            {
                var w = room.Width / 2;
                var h = room.Height / 2;
                float area = w * h;
                var columnsNum = Convert.ToUInt32(_randomGenerator.Next(0, _columnsMaxNum / 4 + 1));
                var maxNumOfIter = 1000;
                var colPositions = new List<Vec2i>();
                for (var i = 0; i < maxNumOfIter && colPositions.Count < columnsNum; ++i)
                {
                    AddElemIfAble(colPositions,
                        new Vec2i(_randomGenerator.Next(2, w - 2), _randomGenerator.Next(2, h - 2)));
                }

                foreach (var colPos in colPositions)
                {
                    var roomLeftUp = room.Pos + new Vec2i(0, room.Height);
                    var roomRightDown = room.Pos + new Vec2i(room.Width, 0);
                    var roomRightUp = room.Pos + new Vec2i(room.Width, room.Height);
                    var pos = colPos + room.Pos;
                    Instantiate(_column0, GetVec3(pos), Quaternion.identity);
                    Instantiate(_column1, GetVec3(new Vec2i(pos.x, roomLeftUp.y - colPos.y - 2)), Quaternion.identity);
                    Instantiate(_column1, GetVec3(new Vec2i(roomRightDown.x - colPos.x - 2, pos.y)), Quaternion.identity);
                    Instantiate(_column0, GetVec3(roomRightUp - colPos - new Vec2i(2, 2)), Quaternion.identity);
                }
            }
        }
    }
}