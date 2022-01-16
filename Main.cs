using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace D3
{
    public partial class Main : Form
    {
        Random r = new Random();
        public Camera camera;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            camera.DrawPhoto(e.Graphics);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            Map map = new Map("map.txt");
            Point3D pos = new Point3D(0, 0, 150);
            Vector vector = new Vector(1, 0, 0);
            camera = new Camera(map, pos, vector);
        }

        private Triangle GetRandomTriangle(int a, int b)
        {
            int x1 = r.Next(-a, a);
            int y1 = r.Next(-a, a);
            int z1 = r.Next(-a, a);
            int x2 = x1 + r.Next(-b, b);
            int y2 = y1 + r.Next(-b, b);
            int z2 = z1 + r.Next(-b, b);
            int x3 = x1 + r.Next(-b, b);
            int y3 = y1 + r.Next(-b, b);
            int z3 = z1 + r.Next(-b, b);
            Color color = Color.FromArgb(r.Next(2100000000));
            Point3D p1 = new Point3D(x1, y1, z1);
            Point3D p2 = new Point3D(x2, y2, z2);
            Point3D p3 = new Point3D(x3, y3, z3);
            Triangle t = new Triangle(p1, p2, p3 ,color);
            return t;
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                camera.Forward(10);
            }
            if (e.KeyCode == Keys.S)
            {
                camera.Back(10);
            }
            if (e.KeyCode == Keys.Right)
            {
                camera.RotateRight(0.1);
            }
            if (e.KeyCode == Keys.Left)
            {
                camera.RotateLeft(0.1);
            }
            Invalidate();
        }
    }
}
