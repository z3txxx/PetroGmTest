using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryShared
{
    public class Line : Shape
    {
        public double FirstPointX { get; set; }
        public double FirstPointY { get; set;}
        public double LastPointX { get; set;}
        public double LastPointY { get; set;}

        public Line(double x1, double y1, double x2, double y2)
        {
            FirstPointX = x1;   
            FirstPointY = y1;
            LastPointX = x2;
            LastPointY = y2;
        }

        public override void Draw()
        {
            Console.WriteLine("Line at ({0}, {1}), ({2}, {3})", this.FirstPointX, this.FirstPointY, this.LastPointX, this.LastPointY);
        }

        public override void Intersect(Shape other)
        {
            if (other is Circle c)
                ShapeIntersection.LineWithCircle(this, c);
            else if (other is Line l)
                ShapeIntersection.LineWithLine(this, l);
            else if (other is Rect r)
                ShapeIntersection.LineWithRect(this, r);
            else if (other is Point)
                ShapeIntersection.PointWithLine();
        }
    }
}
