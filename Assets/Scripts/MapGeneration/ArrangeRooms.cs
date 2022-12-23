using System;
using System.Collections.Generic;
using System.Linq;
using MapGeneration.MapPrimitives;
using UnityEngine;
using Grid = MapGeneration.MapPrimitives.Grid;
using Random = System.Random;
using Vec2i = UnityEngine.Vector2Int;

namespace MapGeneration
{
    public static class RoomsArranger
    {
        private static bool DoesNewRoomOverlap(IEnumerable<Geometry.Rect> rooms, Geometry.Rect newRoom)
        {
            return rooms.Any(room => Geometry.DoRectsOverlap(room, newRoom));
        }
        
        private static void FillGrid(Grid grid, Geometry.Rect newRoom)
        {
            for (var x = newRoom.Pos.x; x < newRoom.Pos.x + newRoom.Width; ++x)
            {
                for (var y = newRoom.Pos.y; y < newRoom.Pos.y + newRoom.Height; ++y)
                {
                    grid.Data[x, y] = CellType.Room;
                }
            }
        }
        
        public static (Grid, List<Geometry.Rect>) ArrangeRooms(float mapDensityScale, uint numOfRooms, uint roomMinDim, uint roomMaxDim, int seed)
        {
            var rooms = new List<Geometry.Rect>();
            var random = new Random(seed);
            var widths = new uint[numOfRooms];
            var heights = new uint[numOfRooms];
            for (var i = 0; i < numOfRooms; ++i)
            {
                widths[i] = Convert.ToUInt32(random.Next((int)roomMinDim, (int)roomMaxDim));
                heights[i] = Convert.ToUInt32(random.Next((int)roomMinDim, (int)roomMaxDim));
            }

            float totalArea = 0;
            for (var i = 0; i < numOfRooms; ++i)
            {
                totalArea += widths[i] * heights[i];
            }

            var mapArea = totalArea / mapDensityScale;
            var gridDim = (int)(Math.Round(Math.Sqrt(mapArea), MidpointRounding.AwayFromZero) + 0.1);
            var grid = new Grid(gridDim);

            for (var i = 0; i < numOfRooms; ++i)
            {
                var iterationsNum = -1;
                var newRoom = new Geometry.Rect(-1, -1, (int)widths[i], (int)heights[i]);
                var newRoomOverlaps = true;
                while (newRoomOverlaps)
                {
                    if (iterationsNum == 100000) throw new Exception("nah");
                    ++iterationsNum;
                    newRoom.Pos.x = random.Next(0, (int)(grid.Dim - widths[i]));
                    newRoom.Pos.y = random.Next(0, (int)(grid.Dim - heights[i]));
                    if (!DoesNewRoomOverlap(rooms, newRoom))
                    {
                        newRoomOverlaps = false;
                    }
                }
                
                rooms.Add(newRoom);
                FillGrid(grid, newRoom);
            }

            return (grid, rooms);
        }
    }
}