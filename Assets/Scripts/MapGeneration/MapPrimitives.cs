using UnityEngine;
using static MapGeneration.Geometry;

namespace MapGeneration
{
    namespace MapPrimitives
    {
        public enum CellType
        {
            None,
            Room,
            Tunnel
        }

        public class Grid
        {
            public CellType[,] Data;
            public int Dim;

            public Grid(int n)
            {
                Dim = n;
                Data = new CellType[Dim, Dim];
            }
            
            public Grid(Grid grid)
            {
                Dim = grid.Dim;
                Data = new CellType[Dim, Dim];
                for (var x = 0; x < Dim; ++x)
                {
                    for (var y = 0; y < Dim; ++y)
                    {
                        Data[x, y] = grid.Data[x, y];
                    }
                }
            }

            public CellType At(int x, int y)
            {
                var len = Data.GetLength(0);
                if (x < 0 || x >= len || y < 0 || y >= len)
                {
                    return CellType.None;
                }

                return Data[x, y];
            }
        }
    }
}