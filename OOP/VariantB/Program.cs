using System;

namespace VariantB
{
    class Program
    {
        static void Main(string[] args)
        {
            var pointHendler = new VariantB.PointHandler(4);
            var point = pointHendler.FindTheNearestPoint(new Point((0, 0)), new VariantB.Point[] { new VariantB.Point(2, 4), new VariantB.Point(1, 1), });
            Console.WriteLine($"{point.X} + {point.Y}");
            point = pointHendler.FindTheFurthestPoint(new Point((0, 0)));
            Console.WriteLine($"{point.X} + {point.Y}");
            pointHendler.DisplayPointsLyingOnTheLineWithThePoints(point, new Point(1, 2));
        }
    }
}
 