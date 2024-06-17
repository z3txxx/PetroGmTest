using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryShared
{
    internal enum LineAndCircleIntersectionNumber
    {
        NotIntersect,
        FirstPoint,
        SecondPoint,
        TwoPoints
    }
    internal static class ShapeIntersection
    {
        public static void PointWithPoint() => Console.WriteLine("The point cannot intersect the point");
        public static void PointWithCircle() => Console.WriteLine("The point cannot intersect the circle");
        public static void PointWithLine() => Console.WriteLine("The point cannot intersect the line");
        public static void PointWithRect() => Console.WriteLine("The point cannot intersect the rect");
        public static void LineWithCircle(Line line, Circle circle)
        {
            double resX1, resY1, resX2, resY2;
            LineAndCircleIntersectionNumber intersectionNum;
            intersectionNum = LineCircleIntersection(line, circle, out resX1, out resY1, out resX2, out resY2);
            if (intersectionNum == LineAndCircleIntersectionNumber.NotIntersect)
                Console.WriteLine("Line and circle do not have intersections");
            else if (intersectionNum == LineAndCircleIntersectionNumber.TwoPoints)
                Console.WriteLine("Line and circle have intersections at ({0}, {1}) and ({2}, {3})", resX1, resY1, resX2, resY2);
        }
        public static void LineWithLine(Line firstLine, Line secondLine)
        {
            double resX, resY;
            if (!TwoLinesIntersection(firstLine, secondLine, out resX, out resY))
               Console.WriteLine("Line and line do not have intersection");
            else
               Console.WriteLine("Line and line have intersection at ({0}, {1})", resX, resY);
        }
        public static void LineWithRect(Line line, Rect rect)
        {
            double resX, resY;
            List<double> points = new List<double>(4);
            Line leftRect = new Line(rect.LeftBottomX, rect.LeftBottomY, rect.LeftBottomX, rect.RightTopX);
            Line rightRect = new Line(rect.RightTopX, rect.LeftBottomY, rect.RightTopX, rect.RightTopY);
            Line bottomRect = new Line(rect.LeftBottomX, rect.LeftBottomY, rect.RightTopX, rect.LeftBottomY);
            Line topRect = new Line(rect.LeftBottomX, rect.RightTopY, rect.RightTopX, rect.RightTopY);
            
            if(TwoLinesIntersection(line, leftRect, out resX, out resY))
            {
                if (resX >= leftRect.FirstPointX && resX <= leftRect.LastPointX && resY >= leftRect.FirstPointY && resY <= leftRect.LastPointY)
                {
                    points.Add(resX);
                    points.Add(resY);
                }
            }
            if (TwoLinesIntersection(line, rightRect, out resX, out resY))
            {
                if (resX >= rightRect.FirstPointX && resX <= rightRect.LastPointX && resY >= rightRect.FirstPointY && resY <= rightRect.LastPointY)
                {
                    points.Add(resX);
                    points.Add(resY);
                }
            }
            if (TwoLinesIntersection(line, bottomRect, out resX, out resY))
            {
                if (resX >= bottomRect.FirstPointX && resX <= bottomRect.LastPointX && resY >= bottomRect.FirstPointY && resY <= bottomRect.LastPointY)
                {
                    points.Add(resX);
                    points.Add(resY);
                }
            }
            if (TwoLinesIntersection(line, topRect, out resX, out resY))
            {
                if (resX >= topRect.FirstPointX && resX <= topRect.LastPointX && resY >= topRect.FirstPointY && resY <= topRect.LastPointY)
                {
                    points.Add(resX);
                    points.Add(resY);
                }
            }
            if (points.Count == 0)
                Console.WriteLine("Line and rect do not have intersection");
            else if (points.Count == 2)
                Console.WriteLine("Line and rect have intersection at ({0}, {1})", points[0], points[1]);
            else if (points.Count == 4)
                Console.WriteLine("Line and rect have intersections at ({0}, {1}) and ({2}, {3})", points[0], points[1], points[2], points[3]);
        }
        public static void RectWithCircle(Rect rect, Circle circle)
        {
            double resX1, resY1, resX2, resY2;
            List<double> points = new List<double>(16);
            Line leftRect = new Line(rect.LeftBottomX, rect.LeftBottomY, rect.LeftBottomX, rect.RightTopX);
            Line rightRect = new Line(rect.RightTopX, rect.LeftBottomY, rect.RightTopX, rect.RightTopY);
            Line bottomRect = new Line(rect.LeftBottomX, rect.LeftBottomY, rect.RightTopX, rect.LeftBottomY);
            Line topRect = new Line(rect.LeftBottomX, rect.RightTopY, rect.RightTopX, rect.RightTopY);

            LineAndCircleIntersectionNumber intersectNum;

            intersectNum = LineCircleIntersection(leftRect, circle, out resX1, out resY1, out resX2, out resY2, true);
            if (intersectNum == LineAndCircleIntersectionNumber.TwoPoints)
                points.AddRange([resX1, resY1, resX2, resY2]);
            else if (intersectNum == LineAndCircleIntersectionNumber.FirstPoint)
                points.AddRange([resX1, resY1]);
            else if (intersectNum == LineAndCircleIntersectionNumber.SecondPoint)
                points.AddRange([resX2, resY2]);

            intersectNum = LineCircleIntersection(rightRect, circle, out resX1, out resY1, out resX2, out resY2, true);
            if (intersectNum == LineAndCircleIntersectionNumber.TwoPoints)
                points.AddRange([resX1, resY1, resX2, resY2]);
            else if (intersectNum == LineAndCircleIntersectionNumber.FirstPoint)
                points.AddRange([resX1, resY1]);
            else if (intersectNum == LineAndCircleIntersectionNumber.SecondPoint)
                points.AddRange([resX2, resY2]);

            intersectNum = LineCircleIntersection(bottomRect, circle, out resX1, out resY1, out resX2, out resY2, true);
            if (intersectNum == LineAndCircleIntersectionNumber.TwoPoints)
                points.AddRange([resX1, resY1, resX2, resY2]);
            else if (intersectNum == LineAndCircleIntersectionNumber.FirstPoint)
                points.AddRange([resX1, resY1]);
            else if (intersectNum == LineAndCircleIntersectionNumber.SecondPoint)
                points.AddRange([resX2, resY2]);

            intersectNum = LineCircleIntersection(topRect, circle, out resX1, out resY1, out resX2, out resY2, true);
            if (intersectNum == LineAndCircleIntersectionNumber.TwoPoints)
                points.AddRange([resX1, resY1, resX2, resY2]);
            else if (intersectNum == LineAndCircleIntersectionNumber.FirstPoint)
                points.AddRange([resX1, resY1]);
            else if (intersectNum == LineAndCircleIntersectionNumber.SecondPoint)
                points.AddRange([resX2, resY2]);

            if (points.Count == 0)
                Console.WriteLine("Rect and circle do not have intersection");
            else
            {
                Console.Write("Rect and circle have intersections at ");
                for (int i = 0; i < points.Count; i = i + 2)
                {
                    if (i == points.Count - 2)
                        Console.WriteLine("({0}, {1})", points[i], points[i + 1]);
                    else
                        Console.Write("({0}, {1}) and ", points[i], points[i + 1]);
                }
            }
        }
        public static void RectWithRect(Rect firstRect, Rect secondRect)
        {
            double resX, resY;
            List<double> points = new List<double>(4);
            Line leftRect1 = new Line(firstRect.LeftBottomX, firstRect.LeftBottomY, firstRect.LeftBottomX, firstRect.RightTopX);
            Line rightRect1 = new Line(firstRect.RightTopX, firstRect.LeftBottomY, firstRect.RightTopX, firstRect.RightTopY);
            Line bottomRect1 = new Line(firstRect.LeftBottomX, firstRect.LeftBottomY, firstRect.RightTopX, firstRect.LeftBottomY);
            Line topRect1 = new Line(firstRect.LeftBottomX, firstRect.RightTopY, firstRect.RightTopX, firstRect.RightTopY);


            Line leftRect2 = new Line(secondRect.LeftBottomX, secondRect.LeftBottomY, secondRect.LeftBottomX, secondRect.RightTopX);
            Line rightRect2 = new Line(secondRect.RightTopX, secondRect.LeftBottomY, secondRect.RightTopX, secondRect.RightTopY);
            Line bottomRect2 = new Line(secondRect.LeftBottomX, secondRect.LeftBottomY, secondRect.RightTopX, secondRect.LeftBottomY);
            Line topRect2 = new Line(secondRect.LeftBottomX, secondRect.RightTopY, secondRect.RightTopX, secondRect.RightTopY);
            #region Сравнение левого отрезка
            if (TwoLinesIntersection(leftRect1, leftRect2, out resX, out resY))
            {
                if (resX >= leftRect1.FirstPointX && resX <= leftRect1.LastPointX && resY >= leftRect1.FirstPointY && resY <= leftRect1.LastPointY
                    && resX >= leftRect2.FirstPointX && resX <= leftRect2.LastPointX && resY >= leftRect2.FirstPointY && resY <= leftRect2.LastPointY)
                    points.AddRange([resX, resY]);
            }
            if (TwoLinesIntersection(leftRect1, rightRect2, out resX, out resY))
            {
                if (resX >= leftRect1.FirstPointX && resX <= leftRect1.LastPointX && resY >= leftRect1.FirstPointY && resY <= leftRect1.LastPointY
                    && resX >= rightRect2.FirstPointX && resX <= rightRect2.LastPointX && resY >= rightRect2.FirstPointY && resY <= rightRect2.LastPointY)
                    points.AddRange([resX, resY]);
            }
            if (TwoLinesIntersection(leftRect1, bottomRect2, out resX, out resY))
            {
                if (resX >= leftRect1.FirstPointX && resX <= leftRect1.LastPointX && resY >= leftRect1.FirstPointY && resY <= leftRect1.LastPointY
                    && resX >= bottomRect2.FirstPointX && resX <= bottomRect2.LastPointX && resY >= bottomRect2.FirstPointY && resY <= bottomRect2.LastPointY)
                    points.AddRange([resX, resY]);
            }
            if (TwoLinesIntersection(leftRect1, topRect2, out resX, out resY))
            {
                if (resX >= leftRect1.FirstPointX && resX <= leftRect1.LastPointX && resY >= leftRect1.FirstPointY && resY <= leftRect1.LastPointY
                    && resX >= topRect2.FirstPointX && resX <= topRect2.LastPointX && resY >= topRect2.FirstPointY && resY <= topRect2.LastPointY)
                    points.AddRange([resX, resY]);
            }
            #endregion
            #region Сравнение правого отрезка
            if (TwoLinesIntersection(rightRect1, leftRect2, out resX, out resY))
            {
                if (resX >= rightRect1.FirstPointX && resX <= rightRect1.LastPointX && resY >= rightRect1.FirstPointY && resY <= rightRect1.LastPointY
                    && resX >= leftRect2.FirstPointX && resX <= leftRect2.LastPointX && resY >= leftRect2.FirstPointY && resY <= leftRect2.LastPointY)
                    points.AddRange([resX, resY]);
            }
            if (TwoLinesIntersection(rightRect1, rightRect2, out resX, out resY))
            {
                if (resX >= rightRect1.FirstPointX && resX <= rightRect1.LastPointX && resY >= rightRect1.FirstPointY && resY <= rightRect1.LastPointY
                    && resX >= rightRect2.FirstPointX && resX <= rightRect2.LastPointX && resY >= rightRect2.FirstPointY && resY <= rightRect2.LastPointY)
                    points.AddRange([resX, resY]);
            }
            if (TwoLinesIntersection(rightRect1, bottomRect2, out resX, out resY))
            {
                if (resX >= rightRect1.FirstPointX && resX <= rightRect1.LastPointX && resY >= rightRect1.FirstPointY && resY <= rightRect1.LastPointY
                    && resX >= bottomRect2.FirstPointX && resX <= bottomRect2.LastPointX && resY >= bottomRect2.FirstPointY && resY <= bottomRect2.LastPointY)
                    points.AddRange([resX, resY]);
            }
            if (TwoLinesIntersection(rightRect1, topRect2, out resX, out resY))
            {
                if (resX >= rightRect1.FirstPointX && resX <= rightRect1.LastPointX && resY >= rightRect1.FirstPointY && resY <= rightRect1.LastPointY
                    && resX >= topRect2.FirstPointX && resX <= topRect2.LastPointX && resY >= topRect2.FirstPointY && resY <= topRect2.LastPointY)
                    points.AddRange([resX, resY]);
            }
            #endregion
            #region Сравнение нижнего отрезка
            if (TwoLinesIntersection(bottomRect1, leftRect2, out resX, out resY))
            {
                if (resX >= bottomRect1.FirstPointX && resX <= bottomRect1.LastPointX && resY >= bottomRect1.FirstPointY && resY <= bottomRect1.LastPointY
                    && resX >= leftRect2.FirstPointX && resX <= leftRect2.LastPointX && resY >= leftRect2.FirstPointY && resY <= leftRect2.LastPointY)
                    points.AddRange([resX, resY]);
            }
            if (TwoLinesIntersection(bottomRect1, rightRect2, out resX, out resY))
            {
                if (resX >= bottomRect1.FirstPointX && resX <= bottomRect1.LastPointX && resY >= bottomRect1.FirstPointY && resY <= bottomRect1.LastPointY
                    && resX >= rightRect2.FirstPointX && resX <= rightRect2.LastPointX && resY >= rightRect2.FirstPointY && resY <= rightRect2.LastPointY)
                    points.AddRange([resX, resY]);
            }
            if (TwoLinesIntersection(bottomRect1, bottomRect2, out resX, out resY))
            {
                if (resX >= bottomRect1.FirstPointX && resX <= bottomRect1.LastPointX && resY >= bottomRect1.FirstPointY && resY <= bottomRect1.LastPointY
                    && resX >= bottomRect2.FirstPointX && resX <= bottomRect2.LastPointX && resY >= bottomRect2.FirstPointY && resY <= bottomRect2.LastPointY)
                    points.AddRange([resX, resY]);
            }
            if (TwoLinesIntersection(bottomRect1, topRect2, out resX, out resY))
            {
                if (resX >= bottomRect1.FirstPointX && resX <= bottomRect1.LastPointX && resY >= bottomRect1.FirstPointY && resY <= bottomRect1.LastPointY
                    && resX >= topRect2.FirstPointX && resX <= topRect2.LastPointX && resY >= topRect2.FirstPointY && resY <= topRect2.LastPointY)
                    points.AddRange([resX, resY]);
            }
            #endregion
            #region Сравнение верхнего отрезка
            if (TwoLinesIntersection(topRect1, leftRect2, out resX, out resY))
            {
                if (resX >= topRect1.FirstPointX && resX <= topRect1.LastPointX && resY >= topRect1.FirstPointY && resY <= topRect1.LastPointY
                    && resX >= leftRect2.FirstPointX && resX <= leftRect2.LastPointX && resY >= leftRect2.FirstPointY && resY <= leftRect2.LastPointY)
                    points.AddRange([resX, resY]);
            }
            if (TwoLinesIntersection(topRect1, rightRect2, out resX, out resY))
            {
                if (resX >= topRect1.FirstPointX && resX <= topRect1.LastPointX && resY >= topRect1.FirstPointY && resY <= topRect1.LastPointY
                    && resX >= rightRect2.FirstPointX && resX <= rightRect2.LastPointX && resY >= rightRect2.FirstPointY && resY <= rightRect2.LastPointY)
                    points.AddRange([resX, resY]);
            }
            if (TwoLinesIntersection(topRect1, bottomRect2, out resX, out resY))
            {
                if (resX >= topRect1.FirstPointX && resX <= topRect1.LastPointX && resY >= topRect1.FirstPointY && resY <= topRect1.LastPointY
                    && resX >= bottomRect2.FirstPointX && resX <= bottomRect2.LastPointX && resY >= bottomRect2.FirstPointY && resY <= bottomRect2.LastPointY)
                    points.AddRange([resX, resY]);
            }
            if (TwoLinesIntersection(topRect1, topRect2, out resX, out resY))
            {
                if (resX >= topRect1.FirstPointX && resX <= topRect1.LastPointX && resY >= topRect1.FirstPointY && resY <= topRect1.LastPointY
                    && resX >= topRect2.FirstPointX && resX <= topRect2.LastPointX && resY >= topRect2.FirstPointY && resY <= topRect2.LastPointY)
                    points.AddRange([resX, resY]);
            }
            #endregion
            Console.WriteLine(points.Count);
            if (points.Count == 0)
                Console.WriteLine("Rect and rect do not have intersection");
            else if (points.Count  > 0)
                Console.WriteLine("Rect and rect have intersections at ({0}, {1}) and ({2}, {3})", points[0], points[1], points[2], points[3]);
        }
        public static void CircleWithCircle(Circle firstCircle, Circle secondCircle)
        {
            double distance;
            distance = Math.Sqrt((firstCircle.CenterX - secondCircle.CenterX) * (firstCircle.CenterX - secondCircle.CenterX)
                                  + (firstCircle.CenterY - secondCircle.CenterY) * (firstCircle.CenterY - secondCircle.CenterY));
            if (distance >= firstCircle.Radius + secondCircle.Radius || distance < Math.Abs(firstCircle.Radius - secondCircle.Radius))
                Console.WriteLine("Circle and circle do not have intersection");
            else
            {
                double a = (firstCircle.Radius * firstCircle.Radius - secondCircle.Radius * secondCircle.Radius + distance * distance)
                            / (2 * distance);
                double pX = firstCircle.CenterX + (a * (secondCircle.CenterX - firstCircle.CenterX)) / distance;
                double pY = firstCircle.CenterY + (a * (secondCircle.CenterY - firstCircle.CenterY)) / distance;
                double h = Math.Sqrt(firstCircle.Radius * firstCircle.Radius - a * a);
                double resX1, resY1, resX2, resY2;
                resX1 = pX + (h * (secondCircle.CenterY - firstCircle.CenterY)) / distance;
                resY1 = pY - (h * (secondCircle.CenterX - firstCircle.CenterX)) / distance;
                resX2 = pX - (h * (secondCircle.CenterY - firstCircle.CenterY)) / distance;
                resY2 = pY + (h * (secondCircle.CenterX - firstCircle.CenterX)) / distance;
                Console.WriteLine("Circle and circle have intersections at ({0}, {1}) and ({2}, {3})", resX1, resY1, resX2, resY2);
            }

        }

        private static bool TwoLinesIntersection(Line firstLine, Line secondLine, out double resX, out double resY)
        {
            resX = 0;
            resY = 0;
            double A1 = firstLine.LastPointY - firstLine.FirstPointY;
            double B1 = firstLine.FirstPointX - firstLine.LastPointX;
            double C1 = A1 * firstLine.FirstPointX + B1 * firstLine.FirstPointY;

            double A2 = secondLine.LastPointY - secondLine.FirstPointY;
            double B2 = secondLine.FirstPointX - secondLine.LastPointX;
            double C2 = A2 * secondLine.FirstPointX + B2 * secondLine.FirstPointY;

            double delta = A1 * B2 - A2 * B1;

            if (delta == 0)
                return false;

            resX = (C1 * B2 - C2 * B1) / delta;
            resY = (A1 * C2 - A2 * C1) / delta;
            return true;
        }
        private static LineAndCircleIntersectionNumber LineCircleIntersection(Line line, Circle circle, out double resX1, out double resY1
                                                                                , out double resX2, out double resY2, bool isSegmentLine = false)
        {
            resX1 = 0;
            resY1 = 0;
            resX2 = 0;
            resY2 = 0;
            //Уравнение прямой и линии приведем к одному уравнению вида at^2+bt+c=0, где при 0<=t<=1, точка лежит на отрезке
            double a, b, c, D;
            double t1, t2;
            a = (line.LastPointX - line.FirstPointX) * (line.LastPointX - line.FirstPointX)
                + (line.LastPointY - line.FirstPointY) * (line.LastPointY - line.FirstPointY);
            b = 2 * ((line.FirstPointX - circle.CenterX) * (line.LastPointX - line.FirstPointX)
                     + (line.FirstPointY - circle.CenterY) * (line.LastPointY - line.FirstPointY));
            c = (line.FirstPointX - circle.CenterX) * (line.FirstPointX - circle.CenterX)
                + (line.FirstPointY - circle.CenterY) * (line.FirstPointY - circle.CenterY) - (circle.Radius * circle.Radius);
            D = b * b - 4 * a * c;
            if (D < 0)
            {
                return LineAndCircleIntersectionNumber.NotIntersect;
            }
            else if (D == 0)
            {
                return LineAndCircleIntersectionNumber.NotIntersect;
            }
            else if (D > 0)
            {
                t1 = (-b + Math.Sqrt(D)) / (2 * a);
                t2 = (-b - Math.Sqrt(D)) / (2 * a);
                resX1 = line.FirstPointX + t1 * (line.LastPointX - line.FirstPointX);
                resY1 = line.FirstPointY + t1 * (line.LastPointY - line.FirstPointY);
                resX2 = line.FirstPointX + t2 * (line.LastPointX - line.FirstPointX);
                resY2 = line.FirstPointY + t2 * (line.LastPointY - line.FirstPointY);
                if (isSegmentLine == true)
                {
                    if (t1 >= 0 && t1 <= 1 && t2 >= 0 && t2 <= 1)
                    {
                        return LineAndCircleIntersectionNumber.TwoPoints;
                    }
                    else if (t1 >= 0 && t1 <= 1)
                    {
                        return LineAndCircleIntersectionNumber.FirstPoint;
                    }
                    else if (t2 >= 0 && t2 <= 1)
                    {
                        return LineAndCircleIntersectionNumber.SecondPoint;
                    }
                    else
                    {
                        return LineAndCircleIntersectionNumber.NotIntersect;
                    }
                }
                else
                    return LineAndCircleIntersectionNumber.TwoPoints;
            }
            else
                return LineAndCircleIntersectionNumber.NotIntersect;
        }
    }
}
