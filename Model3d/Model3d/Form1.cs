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
using Additionally;
using Additionally.Core;
using Additionally.Math;
using Additionally.Render;

namespace Model3d
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //ЧЕ ТУТ ДЕЛАТЬ????????????????????
        }
            

        private void Form1_Load(object sender, EventArgs e)
        {
            Initialize();            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Render(e.Graphics);   
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clear();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateScene();
        }

        public void Initialize()
        {
            m_log = new Log(@"d:\Log.txt");
            m_log.WriteLine("Start: " + DateTime.Now.ToShortDateString() + "(" + DateTime.Now.ToShortTimeString() + ")");
            m_log.WriteLine("");

            Matrix3x3 matrix = new Matrix3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);
            matrix = matrix * matrix;

            Matrix4x4 test_mul44 = new Matrix4x4();
            for (int i = 0; i < 16; i++)
            {
                test_mul44[i] = i;
            }

            test_mul44 = test_mul44 * test_mul44;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    m_log.Write(test_mul44[i, j] + " ");
                }

                m_log.WriteLine("");
            }

            Vector3 v1 = new Vector3(1, 2, 3);
            double x = v1.ToArray()[0];
            double y = v1.ToArray()[1];
            double z = v1.ToArray()[2];

            v1.Normalize();
            Vector3 cross = Vector3.CrossProduct(v1, v1);
            double dot = Vector3.DotProduct(v1, v1);

            Matrix4x4 matrix1 = new Matrix4x4();
            matrix1.Rotate(45, 0, 0);
            matrix1.SetIdentity();

            m_Render = new Render(this);

            timer.Enabled = true;
            timer.Interval = 60;
        }

        public void UpdateScene()
        {

            this.Invalidate();
        }

        public void Render(Graphics graphics)
        {
            m_Polygon1 = new Vector3[]{
                new Vector3(10, 200, 0), new Vector3(400, 200, 0),
                new Vector3(400, 400, 0), new Vector3(10, 400, 0)
            };

            m_Polygon2 = new Vector3[]{
                new Vector3(10, 200, 10), new Vector3(400, 200, 10),
                new Vector3(400, 400, 10), new Vector3(10, 400, 10)
            };

            m_Render.BeginScene(Color.SteelBlue, graphics);

            // Вывод текста шрифтом: Times New Roman 14pt
            m_Render.DrawText("Hello, World!", 10, 10, Color.White, 14);

            m_World = new Matrix4x4();
            m_World.SetIdentity();

            Matrix4x4 perspective = new Matrix4x4();
            perspective.SetPerspective(this.Width, this.Height, 90, 1, 1000);

            Matrix4x4 translate = new Matrix4x4();
            translate.Translate(new Vector3(0, 0, 5));

            m_Render.SetTransform(m_World);

            // Рисование полигона
            m_Render.DrawPolygon(m_Polygon2, Color.Red, 2);

            m_World.SetIdentity();
            translate.Translate(new Vector3(-300, -100, 5));
            m_World = m_World * perspective * translate;


            m_Render.SetTransform(m_World);
            m_Render.DrawPolygon(m_Polygon1, Color.Blue, 4);

            m_Render.EndScene();
        }

        public void Clear()
        {
            m_log.WriteLine("");
            m_log.WriteLine("End: " + DateTime.Now.ToShortDateString() + "(" + DateTime.Now.ToShortTimeString() + ")");
            m_log.WriteLine("");
        }

        private Vector3[] m_Polygon1;
        private Vector3[] m_Polygon2;
        private Matrix4x4 m_World;
        private Render m_Render;
        private Log m_log;

    }
}
