using System;

namespace VariantB
{
    public struct Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Point((double x, double y) coordinates)
        {
            X = coordinates.x;
            Y = coordinates.y;
        }
       
    }
    
}
