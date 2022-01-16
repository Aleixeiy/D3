using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3
{
    public class Map
    {
        public List<Item> items = new List<Item>();

        public Map()
        {

        }

        public Map(string fileName)
        {
            string text = File.ReadAllText(fileName);
            var words = text.Split(' ', '\r', '\n');
            Item mainItem = new Item();

            int i = 0;
            while (i < words.Length)
            {
                Point3D p1 = new Point3D(int.Parse(words[i]), int.Parse(words[i + 1]), int.Parse(words[i + 2]));
                Point3D p2 = new Point3D(int.Parse(words[i + 3]), int.Parse(words[i + 4]), int.Parse(words[i + 5]));
                Point3D p3 = new Point3D(int.Parse(words[i + 6]), int.Parse(words[i + 7]), int.Parse(words[i + 8]));
                Color color = Color.FromArgb(int.Parse(words[i + 9]));
                mainItem.AddTriangle(new Triangle(p1, p2, p3, color));
                i += 10;
                while ((i < words.Length) && ((words[i].Length == 0) || (words[i][0]) < '0' || (words[i][0] > '9')))
                    i++;
            }
            this.AddItem(mainItem);
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }
    }
}
