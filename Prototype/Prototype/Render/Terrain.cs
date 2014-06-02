using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype.Math;
using Prototype.Render;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Prototype.Render
{
   public class Terrain
    {
       public int Height(int X, int Y)
       {

           int x = X % MAP_SIZE;
           int y = Y % MAP_SIZE;

           if (HeightMap.Length == 0) return 0;

           return HeightMap[x + (y * MAP_SIZE)];
       }

       public void LoadRawFile(string strName)
       {
           HeightMap = new byte[MAP_SIZE * MAP_SIZE];
          
           BinaryReader reader = new BinaryReader(File.Open(strName, FileMode.Open));
           HeightMap = reader.ReadBytes(MAP_SIZE * MAP_SIZE);
           reader.Close();

           Polygons = new List<Vector3>();

           int X = 0, Y = 0;
           int x, y, z;

           for (X = 0; X < MAP_SIZE; X += STEP_SIZE)
           {
               for (Y = 0; Y < MAP_SIZE; Y += STEP_SIZE)
               {
                   x = X;
                   y = Height(X, Y);
                   z = Y;
                   // glVertex3i(x, y, z);    // Посылаем эту вершину для рендера в OpenGL
                   //x = 0 + (800 - 0) * ((x + 1) / 2);
                   //z = 600 - (600) * ((z + 1) / 2);
                   Polygons.Add(new Vector3(x, y, z));

                   x = X;
                   y = Height(X, Y + STEP_SIZE);
                   z = Y + STEP_SIZE;
                   // glVertex3i(x, y, z);    // Посылаем для отрисовки
                   //x = 0 + (800 - 0) * ((x + 1) / 2);
                   //z = 600 - (600) * ((z + 1) / 2);
                   Polygons.Add(new Vector3(x, y, z));

                   x = X + STEP_SIZE;
                   y = Height(X + STEP_SIZE, Y + STEP_SIZE);
                   z = Y + STEP_SIZE;
                   // glVertex3i(x, y, z);    // Рисуем
                   //x = 0 + (800 - 0) * ((x + 1) / 2);
                   //z = 600 - (600) * ((z + 1) / 2);
                   Polygons.Add(new Vector3(x, y, z));

                   x = X + STEP_SIZE;
                   y = Height(X + STEP_SIZE, Y);
                   z = Y;
                   // glVertex3i(x, y, z);   
                   //x = 0 + (800 - 0) * ((x + 1) / 2);
                   //z = 600 - (600) * ((z + 1) / 2);
                   Polygons.Add(new Vector3(x, y, z));
               }
           }
       }

       public void Render(Render render)
       {
           render.DrawPolygon(Polygons.ToArray(), Color.White, Prototype.Render.Render.RenderType.RT_QUAD);
       }
  
       public byte[] HeightMap { get; set; }
       public List<Vector3> Polygons { get; set; }

       public static int MAP_SIZE = 128;
       public static int STEP_SIZE = 1;
       public static float HEIGHT_RATIO = 1.5f;
    }
}
