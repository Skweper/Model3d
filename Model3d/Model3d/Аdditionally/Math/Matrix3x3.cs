namespace Additionally.Math
{
    public class Matrix3x3
    {
        public Matrix3x3()
        {
            if (m_Matrix == null)
            {
                m_Matrix = new double[9];
            }

            SetIdentity();
        }

        public Matrix3x3(double m0, double m1, double m2, 
                         double m3, double m4, double m5, 
                         double m6, double m7, double m8)
        {
            if (m_Matrix == null)
            {
                m_Matrix = new double[9];
            }

            m_Matrix[0] = m0; m_Matrix[1] = m1; m_Matrix[2] = m2;
            m_Matrix[3] = m3; m_Matrix[4] = m4; m_Matrix[5] = m5;
            m_Matrix[6] = m6; m_Matrix[7] = m7; m_Matrix[8] = m8;
        }

        public Matrix3x3(double[] array)
        {
            if (array != null)
            {
                if (array.Length == 9)
                {
                    m_Matrix = new double[9];

                    for (int i = 0; i < m_Matrix.Length; i++)
                    {
                        m_Matrix[i] = array[i];
                    }
                }
                else
                {
                    SetIdentity();
                }
            }
            else
            {
                SetIdentity();
            }
        }

        public static Matrix3x3 operator +(Matrix3x3 m1, Matrix3x3 m2)
        {
            Matrix3x3 result = new Matrix3x3();

            result[0] = m1[0] + m2[0]; 
            result[1] = m1[1] + m2[1];
            result[2] = m1[2] + m2[2];
            result[3] = m1[3] + m2[3];
            result[4] = m1[4] + m2[4]; 
            result[5] = m1[5] + m2[5];
            result[6] = m1[6] + m2[6];
            result[7] = m1[7] + m2[7]; 
            result[8] = m1[8] + m2[8];

            return result;
        }

        public static Matrix3x3 operator -(Matrix3x3 m1, Matrix3x3 m2)
        {
            Matrix3x3 result = new Matrix3x3();

            result[0] = m1[0] - m2[0];
            result[1] = m1[1] - m2[1];
            result[2] = m1[2] - m2[2];
            result[3] = m1[3] - m2[3];
            result[4] = m1[4] - m2[4];
            result[5] = m1[5] - m2[5];
            result[6] = m1[6] - m2[6];
            result[7] = m1[7] - m2[7];
            result[8] = m1[8] - m2[8];

            return result;
        }

        public static Vector2 operator *(Matrix3x3 m, Vector2 v)
        {
            Vector2 result = new Vector2();

            result.X = m[0] * v.X + m[1] * v.Y + m[2] * 1;
            result.Y = m[3] * v.X + m[4] * v.Y + m[5] * 1;

            return result;
        }

        public static Vector3 operator *(Matrix3x3 m, Vector3 v)
        {
            Vector3 result = new Vector3();

            result.X = m[0] * v.X + m[1] * v.Y + m[2] * 1;
            result.Y = m[3] * v.X + m[4] * v.Y + m[5] * 1;
            result.Z = 0;

            return result;
        }

        public static Matrix3x3 operator *(Matrix3x3 m1, Matrix3x3 m2)
        {
            Matrix3x3 result = new Matrix3x3();

            result[0] = m1[0] * m2[0] + m1[1] * m2[3] + m1[2] * m2[6];
            result[1] = m1[0] * m2[1] + m1[1] * m2[4] + m1[2] * m2[7];
            result[2] = m1[0] * m2[2] + m1[1] * m2[5] + m1[2] * m2[8];

            result[3] = m1[3] * m2[0] + m1[4] * m2[3] + m1[5] * m2[6];
            result[4] = m1[3] * m2[1] + m1[4] * m2[4] + m1[5] * m2[7];
            result[5] = m1[3] * m2[2] + m1[4] * m2[5] + m1[5] * m2[8];

            result[6] = m1[6] * m2[0] + m1[7] * m2[3] + m1[8] * m2[6];
            result[7] = m1[6] * m2[1] + m1[7] * m2[4] + m1[8] * m2[7];
            result[8] = m1[6] * m2[2] + m1[7] * m2[5] + m1[8] * m2[8];

            return result;
        }

        public static Matrix3x3 operator *(Matrix3x3 m, double d)
        {
            Matrix3x3 result = new Matrix3x3();

            result[0] = m[0] * d;
            result[1] = m[1] * d;
            result[2] = m[2] * d;
            result[3] = m[3] * d;
            result[4] = m[4] * d;
            result[5] = m[5] * d;
            result[6] = m[6] * d;
            result[7] = m[7] * d;
            result[8] = m[8] * d;

            return result;
        }

        public static Matrix3x3 operator /(Matrix3x3 m, double d)
        {
            Matrix3x3 result = new Matrix3x3();

            result[0] = m[0] / d;
            result[1] = m[1] / d;
            result[2] = m[2] / d;
            result[3] = m[3] / d;
            result[4] = m[4] / d;
            result[5] = m[5] / d;
            result[6] = m[6] / d;
            result[7] = m[7] / d;
            result[8] = m[8] / d;

            return result;
        }

        public double this[int i]
        {
            get
            {
                if (i >= 0 && i < 9)
                {
                    return m_Matrix[i];
                }
                else
                {
                    return double.NaN;
                }
            }
            set
            {
                if (i >= 0 && i < 9)
                {
                    m_Matrix[i] = value;
                }
            }
        }

        public double this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < 3 && j >= 0 && j < 3)
                {
                    return m_Matrix[i * 3 + j];
                }
                else
                {
                    return double.NaN;
                }
            }
            set
            {
                if (i > 0 && i < 3 && j > 0 && j < 3)
                {
                    m_Matrix[i * 3 + j] = value;
                }
            }
        }

        public void SetZeroMatrix()
        {
            for (int i = 0; i < m_Matrix.Length; i++)
            {
                m_Matrix[i] = 0;
            }
        }

        public void SetIdentity()
        {
            m_Matrix[0] = 1; m_Matrix[1] = 0; m_Matrix[2] = 0;
            m_Matrix[3] = 0; m_Matrix[4] = 1; m_Matrix[5] = 0;
            m_Matrix[6] = 0; m_Matrix[7] = 0; m_Matrix[8] = 1;
        }

        public void Scale(Vector2 v)
        {
            m_Matrix[0] = v.X;
            m_Matrix[4] = v.Y;
        }

        public void Translate(Vector2 v)
        {
            m_Matrix[2] = v.X;
            m_Matrix[5] = v.Y;
        }

        // Матрица поворотов находится в стадии редактирования :)
        //public void RotateX(double angle)
        //{
        //    m_Matrix[4] = System.Math.Cos(angle);
        //    m_Matrix[5] = -System.Math.Sin(angle);
        //    m_Matrix[7] = System.Math.Sin(angle);
        //    m_Matrix[8] = System.Math.Cos(angle);
        //}

        //public void RotateY(double angle)
        //{
        //    m_Matrix[0] = System.Math.Cos(angle);
        //    m_Matrix[2] = System.Math.Sin(angle);
        //    m_Matrix[6] = -System.Math.Sin(angle);
        //    m_Matrix[8] = System.Math.Cos(angle);
        //}

        //public void RotateZ(double angle)
        //{
        //    m_Matrix[0] = System.Math.Cos(angle);
        //    m_Matrix[1] = -System.Math.Sin(angle);
        //    m_Matrix[3] = System.Math.Sin(angle);
        //    m_Matrix[4] = System.Math.Cos(angle);
        //}

        private double[] m_Matrix;
    }
}
