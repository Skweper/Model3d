namespace Prototype.Math
{
    public class Vector3
    {
        public Vector3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            Vector3 result = new Vector3();

            result.X = v1.X + v2.X;
            result.Y = v1.Y + v2.Y;
            result.Z = v1.Z + v2.Z;

            return result;
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            Vector3 result = new Vector3();

            result.X = v1.X - v2.X;
            result.Y = v1.Y - v2.Y;
            result.Z = v1.Z - v2.Z;

            return result;
        }

        public static Vector3 operator -(Vector3 v)
        {
            Vector3 result = new Vector3();

            result.X = -v.X;
            result.Y = -v.Y;
            result.Z = -v.Z;

            return result;
        }

        public static Vector3 operator ++(Vector3 v)
        {
            Vector3 result = new Vector3();

            result.X = v.X + 1;
            result.Y = v.Y + 1;
            result.Z = v.Z + 1;

            return result;
        }

        public static Vector3 operator --(Vector3 v)
        {
            Vector3 result = new Vector3();

            result.X = v.X - 1;
            result.Y = v.Y - 1;
            result.Z = v.Z - 1;

            return result;
        }

        public static Vector3 operator *(Vector3 v, double d)
        {
            Vector3 result = new Vector3();

            result.X = v.X * d;
            result.Y = v.Y * d;
            result.Z = v.Z * d;

            return result;
        }

        public static Vector3 operator /(Vector3 v, double d)
        {
            Vector3 result = new Vector3();

            result.X = v.X / d;
            result.Y = v.Y / d;
            result.Z = v.Z / d;

            return result;
        }

        public static bool operator <(Vector3 v1, Vector3 v2)
        {
            if (v1.Length() < v2.Length()) return true;

            return false;
        }

        public static bool operator >(Vector3 v1, Vector3 v2)
        {
            if (v1.Length() > v2.Length()) return true;

            return false;
        }

        public static bool operator ==(Vector3 v1, Vector3 v2)
        {
            if (v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z) return true;

            return false;
        }

        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            if (v1.X != v2.X && v1.Y != v2.Y && v1.Z != v2.Z) return true;

            return false;
        }

        public double[] ToArray()
        {
            double[] result = { X, Y, Z };

            return result;
        }

        public double Length()
        {
            return System.Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public void Normalize()
        {
            double inv_length = 1 / this.Length();

            this.X *= inv_length;
            this.Y *= inv_length;
            this.Z *= inv_length;
        }

        public static double DotProduct(Vector3 v1, Vector3 v2)
        {
            return (v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z);
        }

        public static Vector3 CrossProduct(Vector3 v1, Vector3 v2)
        {
            Vector3 result = new Vector3();

            result.X = v1.Y * v2.Z - v1.Z * v2.Y;
            result.Y = v1.Z * v2.X - v1.X * v2.Z;
            result.Z = v1.X * v2.Y - v1.Y * v2.X;

            return result;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
