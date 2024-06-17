using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryShared
{
    public abstract class Shape
    {
        public abstract void Draw();
        public abstract void Intersect(Shape other);
    }
}
