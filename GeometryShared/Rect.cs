using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryShared
{
    public class Rect : Shape
    {
        public double LeftBottomX { get; set; }
        public double LeftBottomY { get; set;}
        public double RightTopX { get; set;}
        public double RightTopY { get; set;}

        public Rect(double x1, double y1, double x2, double y2)
        {
            LeftBottomX = x1;
            LeftBottomY = y1;
            RightTopX = x2;
            RightTopY = y2;
        }

        public override void Draw()
        {
            Console.WriteLine("rect at ({0}, {1}), ({2}, {3})", this.LeftBottomX, this.LeftBottomY, this.RightTopX, this.RightTopY);
        }

        public override void Intersect(Shape other)
        {
            if (other is Circle c)
                ShapeIntersection.RectWithCircle(this, c);
            else if (other is Rect r)
                ShapeIntersection.RectWithRect(this, r);
            else if (other is Line l)
                ShapeIntersection.LineWithRect(l, this);
            else if (other is Point)
                ShapeIntersection.PointWithRect();
        }
    }
}
