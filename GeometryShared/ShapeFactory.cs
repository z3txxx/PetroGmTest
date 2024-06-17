using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryShared
{
    public class ShapeFactory
    {
        public static Shape createShape(string input)
        {
            string[] data = input.Split(' ');
            Shape shape = null;
            if (data[0] == "point")
            {
                double x, y;
                x = double.Parse(data[1]);
                y = double.Parse(data[2]);
                shape = new Point(x, y);
            }
            else if (data[0] == "line")
            {
                double x1, y1, x2, y2;
                x1 = double.Parse(data[1]);
                y1 = double.Parse(data[2]);
                x2 = double.Parse(data[3]);
                y2 = double.Parse(data[4]);
                shape = new Line(x1, y1, x2, y2);
            }
            else if (data[0] == "rect")
            {
                double x1, y1, x2, y2;
                x1 = double.Parse(data[1]);
                y1 = double.Parse(data[2]);
                x2 = double.Parse(data[3]);
                y2 = double.Parse(data[4]);
                shape = new Rect(x1, y1, x2, y2);
            }
            else if (data[0] == "circle")
            {
                double x, y, r;
                x = double.Parse(data[1]);
                y = double.Parse(data[2]);
                r = double.Parse(data[3]);
                shape = new Circle(x, y, r);
            }
            return shape;
        }

    }
}
