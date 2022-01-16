using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3
{
    public class Item
    {
        public List<Triangle> triangles = new List<Triangle>();

        public Item(List<Triangle> triangles)
        {
            this.triangles = triangles;
        }

        public Item()
        {

        }

        public void AddTriangle(Triangle triangle)
        {
            triangles.Add(triangle);
        }
    }
}
