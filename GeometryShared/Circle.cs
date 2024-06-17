using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryShared
{
    public class Circle : Shape
    {
        public double CenterX { get; set; }
        public double CenterY { get; set; }

        public double Radius { get; set; }

        public Circle(double x, double y, double r)
        {
            CenterX = x;
            CenterY = y;    
            Radius = r;
        }

        public override void Draw()
        {
            Console.WriteLine("Circle at ({0}, {1}), radius = {2}", this.CenterX, this.CenterY, this.Radius);
        }

        public override void Intersect(Shape other)
        {
            if (other is Circle c)
                ShapeIntersection.CircleWithCircle(this, c);
            else if (other is Line l)
                ShapeIntersection.LineWithCircle(l, this);
            else if (other is Rect r)
                ShapeIntersection.RectWithCircle(r, this);
            else if (other is Point)
                ShapeIntersection.PointWithCircle();
        }
    }
}
