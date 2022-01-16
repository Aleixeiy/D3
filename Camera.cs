using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3
{
    public class Camera
    {
        public Map map;
        public Point3D pos;
        public Vector vector;

        public int PhotoWidth = 1536;
        public int PhotoHeight = 800;
        public int distToPhoto = 250;

        public Camera(Map map, Point3D pos, Vector vector)
        {
            this.map = map;
            this.pos = pos;
            this.vector = vector;
        }

        public void DrawPhoto(Graphics graphics)
        {
            long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            List<Triangle> triangeles = new List<Triangle>();
            foreach (Item item in map.items)
                foreach (Triangle triangle in item.triangles)
                    triangeles.Add(triangle);
            foreach (Triangle triangle in triangeles)
                DrawTriangle(graphics, triangle);
            long finish = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long time = finish - start;
            int y = 0;
        }

        public void Forward(int delta)
        {
            Vector dVector = new Vector(this.vector);
            dVector.Scale(delta);
            pos.x += (int)dVector.x;
            pos.y += (int)dVector.y;
            pos.z += (int)dVector.z;
        }

        public void Back(int delta)
        {
            Forward(-delta);
        }

        public void RotateRight(double angle)
        {
            RotateLeft(-angle);
        }

        public void RotateLeft(double angle)
        {
            vector.x = vector.x * Math.Cos(angle) - vector.y * Math.Sin(angle);
            vector.y = vector.x * Math.Sin(angle) + vector.y * Math.Cos(angle);
        }

        private void DrawTriangle(Graphics graphics, Triangle triangle)
        {
            
            Point? point1 = GetPoint(triangle.point1);
            Point? point2 = GetPoint(triangle.point2);
            Point? point3 = GetPoint(triangle.point3);
            
            if ((point1 != null) && (point2 != null) && (point3 != null))
            {
                Point[] points = { (Point)point1, (Point)point2, (Point)point3 };
                graphics.FillPolygon(new SolidBrush(triangle.color), points);
            }
        }

        private Point? GetPoint(Point3D point)
        {
            double m = vector.x * (point.x - pos.x) + vector.y * (point.y - pos.y) + vector.x * vector.y * (point.z - pos.z);
            double n = vector.y * (point.x - pos.x) - vector.x * (point.y - pos.y) + vector.y * vector.z * (point.z - pos.z);
            double k = vector.z * (point.x - pos.x) - (vector.x * vector.x + vector.y * vector.y) * (point.z - pos.z);
            if (m <= 0) return null;
            Point result = new Point();
            result.X = (int)(n * distToPhoto / m) + PhotoWidth / 2;
            result.Y = (int)(k * distToPhoto / m) + PhotoHeight / 2;
            return result;
        }
    }
}
