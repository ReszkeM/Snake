using System;
using System.Collections.Generic;
using System.Linq;
using Snake.Models;

namespace Snake.Helpers
{
    public static class PointsGeneratorHelper
    {
        public static Point NewPoint(ICollection<Point> points)
        {
            Random random = new Random();
            int index = random.Next(points.Count);
            return points.ElementAt(index);
        }
    }
}
