using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3
{
    public class Vector
    {
        public double x;
        public double y;
        public double z;

        public Vector(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector (Vector vector)
        {
            this.x = vector.x;
            this.y = vector.y;
            this.z = vector.z;
        }

        public double length
        {
            get
            {
                return Math.Sqrt(x * x + y * y + z * z);
            }
        }

        public void Scale(double d)
        {
            double k = d / this.length;
            x = x * k;
            y = y * k;
            z = z * k;
        }
    }
}
