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

// Подключаем библиотеку Prototype
using Prototype.Core;
using Prototype.Math;
using Prototype.Render;

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////// ПРОГРАММА В СТАДИИ РАЗРАБОТКИ, АВТОР НЕ ВЕДАЕТ ЧТО ТВОРИТ :) ////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            // РИСУЮ НА ФОРМЕ ТАК-КАК ОНА ИМЕЕТ ДВОЙНУЮ БУФЕРИЗАЦИЮ
            // Зато не мерцает при анимации
            Render(e.Graphics);
        }  

        private void timer_Tick(object sender, EventArgs e)
        {
            // Обновление формы
            UpdateScene();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            m_Terrain = new Terrain();
            m_Terrain.LoadRawFile("Terrain.raw");
            
            m_log = new Log(@"C:\Log.txt");
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
            matrix1.Rotate(45, 0 , 0);
            matrix1.SetIdentity();

            m_Render = new Render(this);

            // Настройки таймера
            timer.Enabled = true;
            timer.Interval = 60;
        }

        public void UpdateScene()
        {

            // Обновление формы, делает ее не действительной
            this.Invalidate();
        }

        public void Render(Graphics graphics)
        {
            ///////////////////////////////////////////////////////////////////////
            // //////////////  ТЕСТ ДВУХМЕРНОЙ ГРАФИКИ И ПРЕОБРАЗОВАНИЙ ///////////
            ///////////////////////////////////////////////////////////////////////

            
            m_Polygon1 = new Vector3[]{
                new Vector3(10, 200, 5), new Vector3(400, 200, 5),
                new Vector3(400, 400, 5), new Vector3(10, 400, 5),
                new Vector3(10, 200, 10), new Vector3(400, 200, 10),
                new Vector3(400, 400, 10), new Vector3(10, 400, 10),
                new Vector3(10, 200, 50), new Vector3(400, 200, 50),
                new Vector3(400, 400, 50), new Vector3(10, 400, 50),
                new Vector3(10, 200, 100), new Vector3(400, 200, 100),
                new Vector3(400, 400, 100), new Vector3(10, 400, 100)
            };

            m_Render.BeginScene(Color.SteelBlue, graphics);
            
            // Вывод текста шрифтом: Times New Roman 14pt
            m_Render.DrawText("Hello, World!", 10, 10, Color.White, 14);

            m_World = new Matrix4x4();
            m_World.SetIdentity();

            Matrix4x4 perspective = new Matrix4x4();
            perspective.SetPerspective(this.Width, this.Height, 45, 1, 10000);

            Matrix4x4 translate = new Matrix4x4();
            translate.Translate(new Vector3(1, 1, 1));

            m_World.SetIdentity();
            m_World = m_World * perspective * translate;

            m_Render.SetTransform(m_World);
            //m_Render.DrawPolygon(m_Polygon1, Color.Red, Prototype.Render.Render.RenderType.RT_QUAD);
            m_Terrain.Render(m_Render);

            // Конец сцены, выводим все из буфера графики на форму
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
        private Terrain m_Terrain;
        private Render m_Render;
        private Log m_log;
    }
}
