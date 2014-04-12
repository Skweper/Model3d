using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Math
{
    public class Vector2
    {
        public Vector2()
        {
            X = 0;
            Y = 0;
        }

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            Vector2 result = new Vector2();

            result.X = v1.X + v2.X;
            result.Y = v1.Y + v2.Y;

            return result;
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            Vector2 result = new Vector2();

            result.X = v1.X - v2.X;
            result.Y = v1.Y - v2.Y;

            return result;
        }

        public static Vector2 operator -(Vector2 v)
        {
            Vector2 result = new Vector2();

            result.X = -v.X;
            result.Y = -v.Y;

            return result;
        }

        public static Vector2 operator ++(Vector2 v)
        {
            Vector2 result = new Vector2();

            result.X = v.X + 1;
            result.Y = v.Y + 1;

            return result;
        }

        public static Vector2 operator --(Vector2 v)
        {
            Vector2 result = new Vector2();

            result.X = v.X - 1;
            result.Y = v.Y - 1;

            return result;
        }

        public static Vector2 operator *(Vector2 v, double d)
        {
            Vector2 result = new Vector2();

            result.X = v.X * d;
            result.Y = v.Y * d;

            return result;
        }

        public static Vector2 operator /(Vector2 v, double d)
        {
            Vector2 result = new Vector2();

            result.X = v.X / d;
            result.Y = v.Y / d;

            return result;
        }

        public static bool operator <(Vector2 v1, Vector2 v2)
        {
            if (v1.Length() < v2.Length()) return true;

            return false;
        }

        public static bool operator >(Vector2 v1, Vector2 v2)
        {
            if (v1.Length() > v2.Length()) return true;

            return false;
        }

        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            if (v1.X == v2.X && v1.Y == v2.Y) return true;

            return false;
        }

        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            if (v1.X != v2.X && v1.Y != v2.Y) return true;

            return false;
        }

        public double[] ToArray()
        {
            double[] result = { X, Y };

            return result;
        }

        public double Length()
        {
            return System.Math.Sqrt(X * X + Y * Y);
        }

        public void Normalize()
        {
            double inv_length = 1 / this.Length();

            this.X *= inv_length;
            this.Y *= inv_length;
        }

        public static double DotProduct(Vector2 v1, Vector2 v2)
        {
            return (v1.X * v2.X + v1.Y * v2.Y);
        }

        public double X { get; set; }
        public double Y { get; set; }
    }
}
