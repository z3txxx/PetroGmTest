using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryShared
{
    public class Point : Shape
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override void Draw()
        {
            Console.WriteLine("point at ({0}, {1})", this.X, this.Y);
        }

        public override void Intersect(Shape other)
        {
            if (other is Circle )
                ShapeIntersection.PointWithCircle();
            else if (other is Line)
                ShapeIntersection.PointWithLine();
            else if (other is Rect)
                ShapeIntersection.PointWithRect();
            else if (other is Point)
                ShapeIntersection.PointWithPoint();
        }
    }
}
