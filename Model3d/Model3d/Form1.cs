using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace Model3d
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Vector
        {
            private int x;
            private int y;
            private int z;
            public Vector(int X, int Y, int Z)
            {
                x = X;
                y = Y;
                z = Z;
            }
            public int X
            {
                get
                {
                    return x;
                }
            }
            public int Y
            {
                get
                {
                    return y;
                }
            }
            public int Z
            {
                get
                {
                    return z;
                }
            }
        }
    }
}
