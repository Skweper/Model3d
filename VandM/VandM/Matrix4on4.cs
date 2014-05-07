using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VandM
{
    class Matrix4on4
    {
        private double[] matrix;
        public Matrix4on4()
        {
            matrix = new double[16];
        }
        public Matrix4on4(double m0,double m1,double m2,double m3,double m4,double m5,double m6,double m7,double m8,double m9,double m10,double m11,double m12,double m13,double m14,double m15)
        {
            matrix = new double[16];
            matrix[0] = m0;
            matrix[1] = m1;
            matrix[2] = m2;
            matrix[3] = m3;
            matrix[4] = m4;
            matrix[5] = m5;
            matrix[6] = m6;
            matrix[7] = m7;
            matrix[8] = m8;
            matrix[9] = m9;
            matrix[10] = m10;
            matrix[11] = m11;
            matrix[12] = m12;
            matrix[13] = m13;
            matrix[14] = m14;
            matrix[15] = m15;
        }
        public double[] GetMatrix()
        {
            return matrix;
        }
        public static Matrix4on4 UmnM(Matrix4on4 M1, Matrix4on4 M2)
        {
            Matrix4on4 res = new Matrix4on4();

            res.matrix[0] = M1.matrix[0] * M2.matrix[0] + M1.matrix[1] * M2.matrix[4] + M1.matrix[2] * M2.matrix[8] + M1.matrix[3] * M2.matrix[12];
            res.matrix[1] = M1.matrix[0] * M2.matrix[1] + M1.matrix[1] * M2.matrix[5] + M1.matrix[2] * M2.matrix[9] + M1.matrix[3] * M2.matrix[13];
            res.matrix[2] = M1.matrix[0] * M2.matrix[2] + M1.matrix[1] * M2.matrix[6] + M1.matrix[2] * M2.matrix[10] + M1.matrix[3] * M2.matrix[14];
            res.matrix[3] = M1.matrix[0] * M2.matrix[3] + M1.matrix[1] * M2.matrix[7] + M1.matrix[2] * M2.matrix[11] + M1.matrix[3] * M2.matrix[15];

            res.matrix[4] = M1.matrix[4] * M2.matrix[0] + M1.matrix[5] * M2.matrix[4] + M1.matrix[6] * M2.matrix[8] + M1.matrix[7] * M2.matrix[12];
            res.matrix[5] = M1.matrix[4] * M2.matrix[1] + M1.matrix[5] * M2.matrix[5] + M1.matrix[6] * M2.matrix[9] + M1.matrix[7] * M2.matrix[13];
            res.matrix[6] = M1.matrix[4] * M2.matrix[2] + M1.matrix[5] * M2.matrix[6] + M1.matrix[6] * M2.matrix[10] + M1.matrix[7] * M2.matrix[14];
            res.matrix[7] = M1.matrix[4] * M2.matrix[3] + M1.matrix[5] * M2.matrix[7] + M1.matrix[6] * M2.matrix[11] + M1.matrix[7] * M2.matrix[15];

            res.matrix[8] = M1.matrix[8] * M2.matrix[0] + M1.matrix[9] * M2.matrix[4] + M1.matrix[10] * M2.matrix[8] + M1.matrix[11] * M2.matrix[12];
            res.matrix[9] = M1.matrix[8] * M2.matrix[1] + M1.matrix[9] * M2.matrix[5] + M1.matrix[10] * M2.matrix[9] + M1.matrix[11] * M2.matrix[13];
            res.matrix[10] = M1.matrix[8] * M2.matrix[2] + M1.matrix[9] * M2.matrix[6] + M1.matrix[10] * M2.matrix[10] + M1.matrix[11] * M2.matrix[14];
            res.matrix[11] = M1.matrix[8] * M2.matrix[3] + M1.matrix[9] * M2.matrix[7] + M1.matrix[10] * M2.matrix[11] + M1.matrix[11] * M2.matrix[15];

            res.matrix[12] = M1.matrix[12] * M2.matrix[0] + M1.matrix[13] * M2.matrix[4] + M1.matrix[14] * M2.matrix[8] + M1.matrix[15] * M2.matrix[12];
            res.matrix[13] = M1.matrix[12] * M2.matrix[1] + M1.matrix[13] * M2.matrix[5] + M1.matrix[14] * M2.matrix[9] + M1.matrix[15] * M2.matrix[13];
            res.matrix[14] = M1.matrix[12] * M2.matrix[2] + M1.matrix[13] * M2.matrix[6] + M1.matrix[14] * M2.matrix[10] + M1.matrix[15] * M2.matrix[14];
            res.matrix[15] = M1.matrix[12] * M2.matrix[3] + M1.matrix[13] * M2.matrix[7] + M1.matrix[14] * M2.matrix[11] + M1.matrix[15] * M2.matrix[15];

            return res;
        }
        public static Matrix4on4 PlusM(Matrix4on4 M1, Matrix4on4 M2)
        {
            Matrix4on4 res = new Matrix4on4();
            res.matrix[0] = M1.matrix[0] + M2.matrix[0];
            res.matrix[1] = M1.matrix[1] + M2.matrix[1];
            res.matrix[2] = M1.matrix[2] + M2.matrix[2];
            res.matrix[3] = M1.matrix[3] + M2.matrix[3];
            res.matrix[4] = M1.matrix[4] + M2.matrix[4];
            res.matrix[5] = M1.matrix[5] + M2.matrix[5];
            res.matrix[6] = M1.matrix[6] + M2.matrix[6];
            res.matrix[7] = M1.matrix[7] + M2.matrix[7];
            res.matrix[8] = M1.matrix[8] + M2.matrix[8];
            res.matrix[9] = M1.matrix[9] + M2.matrix[9];
            res.matrix[10] = M1.matrix[10] + M2.matrix[10];
            res.matrix[11] = M1.matrix[11] + M2.matrix[11];
            res.matrix[12] = M1.matrix[12] + M2.matrix[12];
            res.matrix[13] = M1.matrix[13] + M2.matrix[13];
            res.matrix[14] = M1.matrix[14] + M2.matrix[14];
            res.matrix[15] = M1.matrix[15] + M2.matrix[15];
            return res;
        }
        public static bool Equals(Matrix4on4 M1, Matrix4on4 M2)
        {
            for (int i = 0; i < M1.matrix.Length; i++)
            {
                if (M1.matrix[0] != M2.matrix[0])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
