using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading.Tasks;
using Prototype.Math;

namespace Prototype.Render
{
    public class Render
    {
        public Render(Control context, Graphics g)
        {
            m_Graphics = g;
            m_Context = context;

            Matrix2D = new Matrix3x3();
            Matrix3D = new Matrix4x4();
        }

        public void SetTransform(Matrix3x3 matrix)
        {
            Matrix2D = matrix;
        }

        public void SetTransform(Matrix4x4 matrix)
        {
            Matrix3D = matrix;
        }

        public void BeginScene(Color clearColor)
        {
            m_Context.BackColor = clearColor;
        }

        public void EndScene()
        {
            // Освобождение занятых ресурсов
        }

        public void DrawPolygon(Vector2[] v, Color color, float width = 1)
        {
            PointF[] points = new PointF[v.Length];

            for(int i = 0; i < points.Length; i++) 
            {
                v[i] = Matrix2D * v[i];
                points[i] = new PointF((float)v[i].X, (float)v[i].Y);
            }

            m_Graphics.DrawPolygon(new Pen(color, width), points);
        }

        public void DrawFillPolygon(Vector2[] v, Color color)
        {
            PointF[] points = new PointF[v.Length];

            for (int i = 0; i < points.Length; i++)
            {
                v[i] = Matrix2D * v[i];
                points[i] = new PointF((float)v[i].X, (float)v[i].Y);
            }
            
            m_Graphics.FillPolygon(new SolidBrush(color), points);
        }

        public void DrawLine(Vector2 v1, Vector2 v2, Color color, float width = 1)
        {
            v1 = Matrix2D * v1;
            v2 = Matrix2D * v2;

            m_Graphics.DrawLine(new Pen(color, width), (float)v1.X, (float)v1.Y, (float)v2.X, (float)v2.Y);
        }

        public void DrawLines(Vector2[] v, Color color, float width = 1)
        {
            PointF[] points = new PointF[v.Length];

            for (int i = 0; i < points.Length; i++)
            {
                v[i] = Matrix2D * v[i];
                points[i] = new PointF((float)v[i].X, (float)v[i].Y);
            }

            m_Graphics.DrawLines(new Pen(color, width), points);
        }

        public Matrix3x3 Matrix2D { get; set; }
        public Matrix4x4 Matrix3D { get; set; }

        private Graphics m_Graphics;
        private Control m_Context;
    }
}
