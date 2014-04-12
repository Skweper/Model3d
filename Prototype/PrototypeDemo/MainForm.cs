using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Prototype.Core;
using Prototype.Math;
using Prototype.Render;

namespace PrototypeDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clear();
        }

        private void ViewPanel_Paint(object sender, PaintEventArgs e)
        {
            Render((Control)sender, e.Graphics);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Update();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            Log log = new Log(@"C:\Log.txt");
            // log.Write("Some text")

            Matrix3x3 matrix = new Matrix3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);
            matrix = matrix * matrix;

            Vector3 v1 = new Vector3(1, 2, 3);
            double x = v1.ToArray()[0];
            double y = v1.ToArray()[1];
            double z = v1.ToArray()[2];

            v1.Normalize();
            Vector3 cross = Vector3.CrossProduct(v1, v1);
            double dot = Vector3.DotProduct(v1, v1);

            Matrix4x4 matrix1 = new Matrix4x4();
            matrix1.Rotate(45, 0 , 0);
            matrix1.SetIdentity();

            m_Polygon = new Vector2[]{
                new Vector2(10, 200), new Vector2(400, 200),
                new Vector2(400, 400), new Vector2(10, 400)
            };

            timer.Enabled = true;
            timer.Interval = 60;
        }

        public void Update()
        {
            if (m_PositionX > 300) m_PositionX = 10;

            m_PositionX += 10;

            ViewPanel.Invalidate();
        }

        public void Render(Control context, Graphics graphics)
        {
            m_World = new Matrix3x3();
            m_World.SetIdentity();

            m_World.Translate(new Vector2(m_PositionX, 0));

            Render render = new Render(context, graphics);

            render.BeginScene(Color.SteelBlue);
            render.SetTransform(m_World);

            render.DrawLine(new Vector2(10, 10), new Vector2(200, 200), Color.Red, 10);

            m_World.SetIdentity();
            render.SetTransform(m_World);
            render.DrawFillPolygon(m_Polygon, Color.Green);

            render.EndScene();
        }

        public void Clear()
        {

        }

        private Vector2[] m_Polygon;
        private Matrix3x3 m_World;
        private double m_PositionX = 10;  
    }
}
