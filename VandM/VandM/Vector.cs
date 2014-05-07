using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VandM
{
    class Vector
    {
        private double x;
        private double y;
        private double z;
        public Vector()
        {
            x=0;
            y=0;
            z=0;
        }
        public Vector(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public double GetX()
        {
            return x;
        }
        public double GetY()
        {
            return y;
        }
        public double GetZ()
        {
            return z;
        }
        public double[] GetVector()
        {
            double[] res={x,y,z};
            return res;
        }
        public double GetLength()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }
        public static double ScalarV(Vector a,Vector b,double c)
        {
            return a.GetLength() * b.GetLength() * Math.Cos(c);
        }
        public static Vector PlusV(Vector a, Vector b)
        {
            Vector c = new Vector();
            c.x = a.x + b.x;
            c.y = a.y + b.y;
            c.z = a.z + b.z;
            return c;
        }
        public static bool Equals(Vector a, Vector b)
        {
            if (a.x == b.x && a.y == b.y && a.z == b.z)
                return true;
            else return false;
        }
    }
}
