using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryShared;

namespace MyApp
{
    internal class ShapesFromInput
    {
        public string PathToInput { get; set; }
        public ShapesFromInput(string path)
        {
            PathToInput = path;
        }

        public void Run()
        {
            List<Shape> shapes = new List<Shape>();
            try
            {
                string[] lines = File.ReadAllLines(PathToInput);
                foreach (string line in lines)
                {
                    Shape shape;
                    shape = ShapeFactory.createShape(line);
                    shapes.Add(shape);
                    shape.Draw();
                }
                if (shapes.Count > 1)
                {
                    for (int i = 0; i < shapes.Count - 1; i++)
                    {
                        shapes[i].Intersect(shapes[i + 1]);
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
