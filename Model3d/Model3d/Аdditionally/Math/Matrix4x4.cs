namespace Additionally.Math
{
    public class Matrix4x4
    {
        public Matrix4x4()
        {
            if (m_Matrix == null)
            {
                m_Matrix = new double[16];
            }

            SetIdentity();
        }

        public Matrix4x4(double m0, double m1, double m2, double m3,
                         double m4, double m5, double m6, double m7,
                         double m8, double m9, double m10, double m11,
                         double m12, double m13, double m14, double m15)
        {
            if (m_Matrix == null)
            {
                m_Matrix = new double[16];
            }

            m_Matrix[0] = m0; m_Matrix[1] = m1; m_Matrix[2] = m2; m_Matrix[3] = m3;
            m_Matrix[4] = m4; m_Matrix[5] = m5; m_Matrix[6] = m6; m_Matrix[7] = m7;
            m_Matrix[8] = m8; m_Matrix[9] = m9; m_Matrix[10] = m10; m_Matrix[11] = m11;
            m_Matrix[12] = m12; m_Matrix[13] = m13; m_Matrix[14] = m14; m_Matrix[15] = m15;
        }

        public Matrix4x4(double[] array)
        {
            if (array != null)
            {
                if (array.Length == 16)
                {
                    m_Matrix = new double[16];

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

        public static Matrix4x4 operator +(Matrix4x4 m1, Matrix4x4 m2)
        {
            Matrix4x4 result = new Matrix4x4();

            result[0] = m1[0] + m2[0];
            result[1] = m1[1] + m2[1];
            result[2] = m1[2] + m2[2];
            result[3] = m1[3] + m2[3];
            result[4] = m1[4] + m2[4];
            result[5] = m1[5] + m2[5];
            result[6] = m1[6] + m2[6];
            result[7] = m1[7] + m2[7];
            result[8] = m1[8] + m2[8];
            result[9] = m1[9] + m2[9];
            result[10] = m1[10] + m2[10];
            result[11] = m1[11] + m2[11];
            result[12] = m1[12] + m2[12];
            result[13] = m1[13] + m2[13];
            result[14] = m1[14] + m2[14];
            result[15] = m1[15] + m2[15];

            return result;
        }

        public static Matrix4x4 operator -(Matrix4x4 m1, Matrix4x4 m2)
        {
            Matrix4x4 result = new Matrix4x4();

            result[0] = m1[0] - m2[0];
            result[1] = m1[1] - m2[1];
            result[2] = m1[2] - m2[2];
            result[3] = m1[3] - m2[3];
            result[4] = m1[4] - m2[4];
            result[5] = m1[5] - m2[5];
            result[6] = m1[6] - m2[6];
            result[7] = m1[7] - m2[7];
            result[8] = m1[8] - m2[8];
            result[9] = m1[9] - m2[9];
            result[10] = m1[10] - m2[10];
            result[11] = m1[11] - m2[11];
            result[12] = m1[12] - m2[12];
            result[13] = m1[13] - m2[13];
            result[14] = m1[14] - m2[14];
            result[15] = m1[15] - m2[15];

            return result;
        }

        public static Matrix4x4 operator *(Matrix4x4 m, double d)
        {
            Matrix4x4 result = new Matrix4x4();

            result[0] = m[0] * d;
            result[1] = m[1] * d;
            result[2] = m[2] * d;
            result[3] = m[3] * d;
            result[4] = m[4] * d;
            result[5] = m[5] * d;
            result[6] = m[6] * d;
            result[7] = m[7] * d;
            result[8] = m[8] * d;
            result[9] = m[9] * d;
            result[10] = m[10] * d;
            result[11] = m[11] * d;
            result[12] = m[12] * d;
            result[13] = m[13] * d;
            result[14] = m[14] * d;
            result[15] = m[15] * d;

            return result;
        }

        public static Matrix4x4 operator /(Matrix4x4 m, double d)
        {
            Matrix4x4 result = new Matrix4x4();

            result[0] = m[0] / d;
            result[1] = m[1] / d;
            result[2] = m[2] / d;
            result[3] = m[3] / d;
            result[4] = m[4] / d;
            result[5] = m[5] / d;
            result[6] = m[6] / d;
            result[7] = m[7] / d;
            result[8] = m[8] / d;
            result[9] = m[9] / d;
            result[10] = m[10] / d;
            result[11] = m[11] / d;
            result[12] = m[12] / d;
            result[13] = m[13] / d;
            result[14] = m[14] / d;
            result[15] = m[15] / d;

            return result;
        }

        public static Vector3 operator *(Matrix4x4 m, Vector3 v)
        {
            Vector3 result = new Vector3();

            result.X = m[0] * v.X + m[1] * v.Y + m[2] * v.Z + m[3] * 1;
            result.Y = m[4] * v.X + m[5] * v.Y + m[6] * v.Z + m[7] * 1;
            result.Z = m[8] * v.X + m[9] * v.Y + m[10] * v.Z + m[11] * 1;

            return result;
        }

        public static Matrix4x4 operator *(Matrix4x4 m1, Matrix4x4 m2)
        {
            Matrix4x4 result = new Matrix4x4();

            result[0] = m1[0] * m2[0] + m1[1] * m2[4] + m1[2] * m2[8] + m1[3] * m2[12];
            result[1] = m1[0] * m2[1] + m1[1] * m2[5] + m1[2] * m2[9] + m1[3] * m2[13];
            result[2] = m1[0] * m2[2] + m1[1] * m2[6] + m1[2] * m2[10] + m1[3] * m2[14];
            result[3] = m1[0] * m2[3] + m1[1] * m2[7] + m1[2] * m2[11] + m1[3] * m2[15];

            result[4] = m1[4] * m2[0] + m1[5] * m2[4] + m1[6] * m2[8] + m1[7] * m2[12];
            result[5] = m1[4] * m2[1] + m1[5] * m2[5] + m1[6] * m2[9] + m1[7] * m2[13];
            result[6] = m1[4] * m2[2] + m1[5] * m2[6] + m1[6] * m2[10] + m1[7] * m2[14];
            result[7] = m1[4] * m2[3] + m1[5] * m2[7] + m1[6] * m2[11] + m1[7] * m2[15];

            result[8] = m1[8] * m2[0] + m1[9] * m2[4] + m1[10] * m2[8] + m1[11] * m2[12];
            result[9] = m1[8] * m2[1] + m1[9] * m2[5] + m1[10] * m2[9] + m1[11] * m2[13];
            result[10] = m1[8] * m2[2] + m1[9] * m2[6] + m1[10] * m2[10] + m1[11] * m2[14];
            result[11] = m1[8] * m2[3] + m1[9] * m2[7] + m1[10] * m2[11] + m1[11] * m2[15];

            result[12] = m1[12] * m2[0] + m1[13] * m2[4] + m1[14] * m2[8] + m1[15] * m2[12];
            result[13] = m1[12] * m2[1] + m1[13] * m2[5] + m1[14] * m2[9] + m1[15] * m2[13];
            result[14] = m1[12] * m2[2] + m1[13] * m2[6] + m1[14] * m2[10] + m1[15] * m2[14];
            result[15] = m1[12] * m2[3] + m1[13] * m2[7] + m1[14] * m2[11] + m1[15] * m2[15];

            return result;
        }

        public double this[int i]
        {
            get
            {
                if (i >= 0 && i < 16) return m_Matrix[i];
                else return double.NaN;
            }
            set
            {
                if (i >= 0 && i < 16) m_Matrix[i] = value;
            }
        }

        public double this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < 4 && j >= 0 && j < 4)
                {
                    return m_Matrix[i * 4 + j];
                }
                else
                {
                    return double.NaN;
                }
            }
            set
            {
                if (i > 0 && i < 4 && j > 0 && j < 4)
                {
                    m_Matrix[i * 4 + j] = value;
                }
            }
        }

        public void SetZeroMatrix()
        {
            for (int i = 0; i < m_Matrix.Length; i++)
                m_Matrix[i] = 0;
        }

        public void SetIdentity()
        {
            m_Matrix[0] = 1; m_Matrix[1] = 0; m_Matrix[2] = 0; m_Matrix[3] = 0;
            m_Matrix[4] = 0; m_Matrix[5] = 1; m_Matrix[6] = 0; m_Matrix[7] = 0;
            m_Matrix[8] = 0; m_Matrix[9] = 0; m_Matrix[10] = 1; m_Matrix[11] = 0;
            m_Matrix[12] = 0; m_Matrix[13] = 0; m_Matrix[14] = 0; m_Matrix[15] = 1;
        }

        public void SetPerspective(int width, int height, double fov, double znear, double zfar)
        {
            double ar = (double)width / (double)height;
            double zNear = znear;
            double zFar = zfar;
            double zRange = zNear - zFar;
            double tanHalfFOV = System.Math.Tan(MathHelper.ToRadian(fov / 2.0));

            this[0, 0] = 1.0f / (tanHalfFOV * ar);
            this[0, 1] = 0.0f;
            this[0, 2] = 0.0f;
            this[0, 3] = 0.0f;

            this[1, 0] = 0.0f;
            this[1, 1] = 1.0f / tanHalfFOV;
            this[1, 2] = 0.0f;
            this[1, 3] = 0.0f;

            this[2, 0] = 0.0f;
            this[2, 1] = 0.0f;
            this[2, 2] = (-zNear - zFar) / zRange;
            this[2, 3] = 2.0f * zFar * zNear / zRange;

            this[3, 0] = 0.0f;
            this[3, 1] = 0.0f;
            this[3, 2] = 1.0f;
            this[3, 3] = 0.0f;
        }

        public void SetCamera(Vector3 position, Vector3 target, Vector3 up)
        {
            Matrix4x4 view = new Matrix4x4();

            Vector3 zaxis = target - position;
            zaxis.Normalize();

            Vector3 xaxis = Vector3.CrossProduct(up, zaxis);
            xaxis.Normalize();

            Vector3 yaxis = Vector3.CrossProduct(zaxis, xaxis);

            Vector3 pos = new Vector3()
            {
                X = -Vector3.DotProduct(xaxis, position),
                Y = -Vector3.DotProduct(yaxis, position),
                Z = -Vector3.DotProduct(zaxis, position),
            };

            view[0, 0] = xaxis.X;   view[0, 1] = xaxis.Y;   view[0, 2] = xaxis.Z;   view[0, 3] = 0.0;
            view[1, 0] = yaxis.X;   view[1, 1] = yaxis.Y;   view[1, 2] = yaxis.Z;   view[1, 3] = 0.0;
            view[2, 0] = zaxis.X;   view[2, 1] = zaxis.Y;   view[2, 2] = zaxis.Z;   view[2, 3] = 0.0;
            view[3, 0] = pos.X;     view[3, 1] = pos.Y;     view[3, 2] = pos.Z;     view[3, 3] = 1.0;

            m_Matrix = view.ToArray();
        }


        public void Scale(Vector3 v)
        {
            m_Matrix[0] = v.X;
            m_Matrix[5] = v.Y;
            m_Matrix[10] = v.Z;
        }

        public void Translate(Vector3 v)
        {
            m_Matrix[3] = v.X;
            m_Matrix[7] = v.Y;
            m_Matrix[11] = v.Z;
        }

        public void Rotate(double angleX, double angleY, double angleZ)
        {
            Matrix4x4 rx = new Matrix4x4();
            Matrix4x4 ry = new Matrix4x4();
            Matrix4x4 rz = new Matrix4x4();

            double x = MathHelper.ToRadian(angleX);
            double y = MathHelper.ToRadian(angleY);
            double z = MathHelper.ToRadian(angleZ);

            rx[0, 0] = 1.0f; rx[0, 1] = 0.0f; rx[0, 2] = 0.0f; rx[0, 3] = 0.0f;
            rx[1, 0] = 0.0f; rx[1, 1] = System.Math.Cos(x); rx[1, 2] = -System.Math.Sin(x); rx[1, 3] = 0.0f;
            rx[2, 0] = 0.0f; rx[2, 1] = System.Math.Sin(x); rx[2, 2] = System.Math.Cos(x); rx[2, 3] = 0.0f;
            rx[3, 0] = 0.0f; rx[3, 1] = 0.0f; rx[3, 2] = 0.0f; rx[3, 3] = 1.0f;

            ry[0, 0] = System.Math.Cos(y); ry[0, 1] = 0.0f; ry[0, 2] = -System.Math.Sin(y); ry[0, 3] = 0.0f;
            ry[1, 0] = 0.0f; ry[1, 1] = 1.0f; ry[1, 2] = 0.0f; ry[1, 3] = 0.0f;
            ry[2, 0] = System.Math.Sin(y); ry[2, 1] = 0.0f; ry[2, 2] = System.Math.Cos(y); ry[2, 3] = 0.0f;
            ry[3, 0] = 0.0f; ry[3, 1] = 0.0f; ry[3, 2] = 0.0f; ry[3, 3] = 1.0f;

            rz[0, 0] = System.Math.Cos(z); rz[0, 1] = -System.Math.Sin(z); rz[0, 2] = 0.0f; rz[0, 3] = 0.0f;
            rz[1, 0] = System.Math.Sin(z); rz[1, 1] = System.Math.Cos(z); rz[1, 2] = 0.0f; rz[1, 3] = 0.0f;
            rz[2, 0] = 0.0f; rz[2, 1] = 0.0f; rz[2, 2] = 1.0f; rz[2, 3] = 0.0f;
            rz[3, 0] = 0.0f; rz[3, 1] = 0.0f; rz[3, 2] = 0.0f; rz[3, 3] = 1.0f;

            m_Matrix = (rz * ry * rx).ToArray();
        }

        public double[] ToArray()
        {
            return m_Matrix;
        }

        private double[] m_Matrix;
    }
}
