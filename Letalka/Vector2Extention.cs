using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace Letalka
{
    public static class Vector2Extension
    {

        public static Vector2 Rotate(this Vector2 v, float angle)
        {
            float sin = (float)Math.Sin(angle);
            float cos = (float)Math.Cos(angle);

            float tx = v.X;
            float ty = v.Y;
            v.X = (cos * tx) - (sin * ty);
            v.Y = (sin * tx) + (cos * ty);
            return v;
        }
    }
}