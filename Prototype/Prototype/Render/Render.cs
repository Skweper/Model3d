using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Prototype.Math;

namespace Prototype.Render
{
    public class Render
    {
        public enum RenderType
        {
            RT_TRIANGLE = 0,
            RT_QUAD     = 1
        }
  
        public Render(Control context)
        {
            m_Context = context;
            Matrix3D = new Matrix4x4();
            
            m_DoubleBuffer = new BufferedGraphicsContext(); 
        }

        public void SetTransform(Matrix4x4 matrix)
        {
            Matrix3D = matrix;
        }

        public void BeginScene(Color clearColor, Graphics graphics)
        {
            m_BufferGraphics = m_DoubleBuffer.Allocate(graphics, new Rectangle(0, 0, m_Context.Width, m_Context.Height));
            m_BufferGraphics.Graphics.Clear(clearColor);
        }

        public void EndScene()
        {
            m_BufferGraphics.Render();
        }

        public void DrawText(string text, Vector2 v, Color color, double size)
        {
            m_BufferGraphics.Graphics.DrawString(text, new Font("Times New Roman", (float)size), new SolidBrush(color), (float)v.X, (float)v.Y);
        }

        public void DrawText(string text, double x, double y, Color color, double size)
        {
            m_BufferGraphics.Graphics.DrawString(text, new Font("Times New Roman", (float)size), new SolidBrush(color), (float)x, (float)y);
        }

        public void DrawPolygon(Vector3[] v, Color color, RenderType rtype)
        {
            PointF[] points = new PointF[v.Length];

            for (int i = 0; i < points.Length; i++)
            {
                v[i] = Matrix3D * v[i];
                points[i] = new PointF(((float)v[i].X / (float)v[i].Z) + (m_Context.Width / 2), ((float)v[i].Y / (float)v[i].Z) + (m_Context.Height / 2));
            }

            if (rtype == RenderType.RT_TRIANGLE)
            {
                List<PointF> tri = new List<PointF>();

                for (int i = 0; i < points.Length; i++)
                {
                    tri.Add(points[i]);

                    if (tri.Count == 3)
                    {
                        m_BufferGraphics.Graphics.DrawPolygon(new Pen(color, 1), tri.ToArray());
                        tri.Clear();
                    }
                }
            }
            else
            {
                List<PointF> quad = new List<PointF>();

                for (int i = 0; i < points.Length; i++)
                {
                    quad.Add(points[i]);

                    if (quad.Count == 4)
                    {
                        m_BufferGraphics.Graphics.DrawPolygon(new Pen(color, 1), quad.ToArray());
                        quad.Clear();
                    }
                }
            }
        }

        public Matrix4x4 Matrix3D { get; set; }

        private BufferedGraphics m_BufferGraphics;
        private BufferedGraphicsContext m_DoubleBuffer;
        private Control m_Context;
    }
}
