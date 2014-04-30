using System.Drawing;
using System.Windows.Forms;
using Prototype.Math;

namespace Prototype.Render
{
    public class Render
    {
        public Render(Control context)
        {
            m_Context = context;

            Matrix2D = new Matrix3x3();
            Matrix3D = new Matrix4x4();

            m_DoubleBuffer = new BufferedGraphicsContext(); 
        }

        public void SetTransform(Matrix3x3 matrix)
        {
            Matrix2D = matrix;
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

        public void DrawPolygon(Vector2[] v, Color color, float width = 1)
        {
            PointF[] points = new PointF[v.Length];

            for(int i = 0; i < points.Length; i++) 
            {
                v[i] = Matrix2D * v[i];
                points[i] = new PointF((float)v[i].X, (float)v[i].Y);
            }

            m_BufferGraphics.Graphics.DrawPolygon(new Pen(color, width), points);
        }

        public void DrawFillPolygon(Vector2[] v, Color color)
        {
            PointF[] points = new PointF[v.Length];

            for (int i = 0; i < points.Length; i++)
            {
                v[i] = Matrix2D * v[i];
                points[i] = new PointF((float)v[i].X, (float)v[i].Y);
            }
            
            m_BufferGraphics.Graphics.FillPolygon(new SolidBrush(color), points);
        }

        public void DrawLine(Vector2 v1, Vector2 v2, Color color, float width = 1)
        {
            v1 = Matrix2D * v1;
            v2 = Matrix2D * v2;

            // m_BufferGraphics.Graphics.DrawLine(new Pen(color, width), (float)v1.X, (float)v1.Y, (float)v2.X, (float)v2.Y);

            // Draw Line with scale size, for test only :)
            m_BufferGraphics.Graphics.DrawLine(new Pen(color, width * (float)Matrix2D[0]), (float)v1.X, (float)v1.Y, (float)v2.X, (float)v2.Y);
        }

        public void DrawLine(double x1, double x2, double y1, double y2, Color color, float width = 1)
        {
            Vector2 v1 = new Vector2(x1, x2);
            Vector2 v2 = new Vector2(y1, y2);

            v1 = Matrix2D * v1;
            v2 = Matrix2D * v2;

            // m_BufferGraphics.Graphics.DrawLine(new Pen(color, width), (float)v1.X, (float)v1.Y, (float)v2.X, (float)v2.Y);

            // Draw Line with scale size, for test only :)
            m_BufferGraphics.Graphics.DrawLine(new Pen(color, width * (float)Matrix2D[0]), (float)v1.X, (float)v1.Y, (float)v2.X, (float)v2.Y);
        }

        public void DrawLines(Vector2[] v, Color color, float width = 1)
        {
            PointF[] points = new PointF[v.Length];

            for (int i = 0; i < points.Length; i++)
            {
                v[i] = Matrix2D * v[i];
                points[i] = new PointF((float)v[i].X, (float)v[i].Y);
            }

            m_BufferGraphics.Graphics.DrawLines(new Pen(color, width), points);
        }

        public Matrix3x3 Matrix2D { get; set; }
        public Matrix4x4 Matrix3D { get; set; }

        private BufferedGraphics m_BufferGraphics;
        private BufferedGraphicsContext m_DoubleBuffer;
        private Control m_Context;
    }
}
