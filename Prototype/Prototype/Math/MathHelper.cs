namespace Prototype.Math
{
    public class MathHelper
    {
        public static double ToRadian(double x) 
        {
            return ((x) * System.Math.PI / 180.0f);
        }

        public static double ToDegree(double x) 
        {
            return ((x) * 180.0f / System.Math.PI);
        }
    }
}
