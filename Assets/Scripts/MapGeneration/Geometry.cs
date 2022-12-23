using System;
using System.Collections.Generic;
using UnityEngine;
using Vec2i = UnityEngine.Vector2Int;

namespace MapGeneration
{
    public static class Geometry
    {
        public class Rect
        {
            public Vec2i Pos;
            public int Width;
            public int Height;

            public Rect(int x, int y, int width, int height)
            {
                Pos = new Vec2i(x, y);
                Width = width;
                Height = height;
            }
        }
        
        private static bool ValueInRange(int value, int min, int max)
        { return (value >= min) && (value <= max); }

        public static bool DoRectsOverlap(Rect r1, Rect r2)
        {
            // a.minX <= b.maxX &&
            //     a.maxX >= b.minX &&
            //     a.minY <= b.maxY &&
            //     a.maxY >= b.minY &&

            // return r1.Pos.x <= r2.Pos.x + r2.Width && r1.Pos.x + r1.Width >= r2.Pos.x &&
            //        r1.Pos.y <= r2.Pos.y + r2.Height && r1.Pos.y + r1.Height >= r2.Pos.y;
                
                
            var xOverlap = ValueInRange(r1.Pos.x, r2.Pos.x, r2.Pos.x + r2.Width) ||
                           ValueInRange(r2.Pos.x, r1.Pos.x, r1.Pos.x + r1.Width);
            
            var yOverlap = ValueInRange(r1.Pos.y, r2.Pos.y, r2.Pos.y + r2.Height) ||
                           ValueInRange(r2.Pos.y, r1.Pos.y, r1.Pos.y + r1.Height);
            
            return xOverlap && yOverlap;
        }
    }
}