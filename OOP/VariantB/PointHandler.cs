using System;

namespace VariantB
{
    public class PointHandler
    {
        int _numberOfPoints = 0;
        Point[] points;
        int NumberOfPoints
        {
            get
            {
                return _numberOfPoints;
            }
            set
            {
                while (true)
                {
                    if (value < 0)
                    {
                        Console.WriteLine("Wrong quantity of points. Try Again");
                    }
                    else
                    {
                        _numberOfPoints = value;
                        break;
                    }
                }

            }
        }
        public PointHandler(int numberOfPoints)
        {
            NumberOfPoints = numberOfPoints;
            points = new Point[numberOfPoints];
            SetValueForPoints();
        }
        private void SetValueForPoints()
        {
            double x, y;
            for (int i = 0; i < NumberOfPoints; i++)
            {

                Console.WriteLine($"Set x and y for point number {i}: ");
                string[] strings = (Console.ReadLine()).Split(' ');
                if (Double.TryParse(strings[0], out x) && Double.TryParse(strings[1], out y))
                {
                    points[i] = new Point(x, y);
                }
                else
                {
                    Console.WriteLine("Wrong numbers, try again");
                    i--;
                }
            }
        }
        public void DisplayPointsLyingOnTheLineWithThePoints((double x, double y) point1, (double x, double y) point2)
        {
            bool pointExists = false;
            Console.WriteLine($"On the line that starts at x:{point1.x} y:{point1.y} and ends at x:{point2.x} y:{point2.y} lies ");
            foreach (Point point in points)
            {
                if ((point.X - point1.x) * (point2.y - point1.y) == (point2.x - point1.x) * (point.Y - point1.y))
                {
                    if (Math.Min(point1.y, point2.y) <= point.Y && (Math.Max(point1.y, point2.y) >= point.Y) && Math.Min(point1.x, point2.x) <= point.X && Math.Max(point1.x, point2.x) >= point.X)
                    {
                        Console.Write($"{point.X} {point.Y} ");
                        pointExists = true;
                    }
                }
            }
            if (!pointExists)
            {
                Console.Write("0 points");
            }
        }
        public void DisplayPointsLyingOnTheLineWithThePoints(Point point1, Point point2)
        {
            bool pointExists = false;
            Console.WriteLine($"On the line that starts at x:{point1.X} y:{point1.Y} and ends at x:{point2.X} y:{point2.Y} lies ");
            foreach (Point point in points)
            {
                if ((point.X - point1.X) * (point2.Y - point1.Y) == (point2.X - point1.X) * (point.Y - point1.Y))
                {
                    if (Math.Min(point1.Y, point2.Y) <= point.Y && (Math.Max(point1.Y, point2.Y) >= point.Y) && Math.Min(point1.X, point2.X) <= point.X && Math.Max(point1.X, point2.X) >= point.X)
                    {
                        Console.Write($"{point.X} {point.Y} ");
                        pointExists = true;
                    }
                }
            }
            if (!pointExists)
            {
                Console.Write("0 points");
            }
        }
        private double FindLengthBetweenPoints(Point point2, Point point1)
        {
            return Math.Sqrt(Math.Pow((point2.X - point1.X), 2) + Math.Pow((point2.Y - point1.Y), 2));
        }
        public Point FindTheNearestPoint(Point point, Point[] points)
        {
            double currentDistance = 0, previousDistance = double.MaxValue;
            Point nearestPoint = new Point(0, 0);
            foreach (Point thePoint in points)
            {
                currentDistance = FindLengthBetweenPoints(thePoint, point);
                if (currentDistance < previousDistance)
                {
                    previousDistance = currentDistance;
                    nearestPoint = thePoint;
                }
            }
            return nearestPoint;
        }
        public Point FindTheNearestPoint(Point point)
        {
            double currentDistance = 0, previousDistance = double.MaxValue;
            Point nearestPoint = new Point(0, 0);
            foreach (Point thePoint in points)
            {
                currentDistance = FindLengthBetweenPoints(thePoint, point);
                if (currentDistance < previousDistance)
                {
                    previousDistance = currentDistance;
                    nearestPoint = thePoint;
                }
            }
            return nearestPoint;
        }
        public Point FindTheFurthestPoint(Point point, Point[] points)
        {
            double currentDistance = 0, previousDistance = double.MinValue;
            Point furthestPoint = new Point(0, 0);
            foreach (Point thePoint in points)
            {
                currentDistance = FindLengthBetweenPoints(thePoint,point);
                if (currentDistance > previousDistance)
                {
                    previousDistance = currentDistance;
                    furthestPoint = thePoint;
                }
            }
            return furthestPoint;
        }
        public Point FindTheFurthestPoint(Point point)
        {
            double currentDistance = 0, previousDistance = double.MinValue;
            Point furthestPoint = new Point(0, 0);
            foreach (Point thePoint in points)
            {
                currentDistance = FindLengthBetweenPoints(thePoint, point);
                if (currentDistance > previousDistance)
                {
                    previousDistance = currentDistance;
                    furthestPoint = thePoint;
                }
            }
            return furthestPoint;
        }


    }
}
