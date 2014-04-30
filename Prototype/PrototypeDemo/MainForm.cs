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

            // Тот самый зеленый квадратик
            m_Polygon = new Vector2[]{
                new Vector2(10, 200), new Vector2(400, 200),
                new Vector2(400, 400), new Vector2(10, 400)
            };

            // Настройки таймера
            timer.Enabled = true;
            timer.Interval = 60;
        }

        public void UpdateScene()
        {
            // Расчет значений для анимации
            if (m_PositionX >= 380) m_PositionX = 0;

            m_PositionX += 10;

            // Обновление формы, делает ее не действительной
            this.Invalidate();
        }

        public void Render(Graphics graphics)
        {
            ///////////////////////////////////////////////////////////////////////
            // //////////////  ТЕСТ ДВУХМЕРНОЙ ГРАФИКИ И ПРЕОБРАЗОВАНИЙ ///////////
            ///////////////////////////////////////////////////////////////////////

            m_Render.BeginScene(Color.SteelBlue, graphics);
            
            // Вывод текста шрифтом: Times New Roman 14pt
            m_Render.DrawText("Hello, World!", 10, 10, Color.White, 14);

            m_World = new Matrix3x3();
            m_World.SetIdentity();

            // New_Position = Matrix_World * Old_Position
            Matrix3x3 matrixScale = new Matrix3x3();
            matrixScale.SetIdentity();

            // Масштабирование красной линии
            m_World.Scale(new Vector2(10, 10));

            // Перемещение красной линии
            m_World.Translate(new Vector2(m_PositionX, 0));

            // m_World = m_World * matrixScale;
            m_Render.SetTransform(m_World);

            // Draw Line with scale size, for test only :)
            // Modify m_Render::DrawLine()
            m_Render.DrawLine(new Vector2(10, 10), new Vector2(10, 200), Color.Red, 10);

            // Сброс мировой матрицы
            m_World.SetIdentity();

            m_Render.SetTransform(m_World);
            m_Render.DrawFillPolygon(m_Polygon, Color.Green);

            // Конец сцены, выводим все из буфера графики на форму
            m_Render.EndScene();
        }

        public void Clear()
        {
            m_log.WriteLine("");
            m_log.WriteLine("End: " + DateTime.Now.ToShortDateString() + "(" + DateTime.Now.ToShortTimeString() + ")");
            m_log.WriteLine("");
        }

        private Vector2[] m_Polygon;
        private Matrix3x3 m_World;
        private double m_PositionX = 0;
        private Render m_Render;
        private Log m_log;
    }
}
