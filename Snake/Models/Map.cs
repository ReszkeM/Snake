using System;
using System.Collections.Generic;
using System.Linq;
using Snake.Interfaces;

namespace Snake.Models
{
    public class Map : IMap
    {
        public ICollection<Point> Arena { get; set; } 
        public ICollection<Point> ArenaBorder { get; set; } 
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }

        public Map(int startX, int endX, int startY, int endY)
        {
            Arena = new List<Point>();
            ArenaBorder = new List<Point>();

            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;

            for (int y = startY; y <= endY; y++)
            {
                for (int x = startX; x <= endX; x++)
                {
                    if (y == startY || y == endY || x == startX || x == endX)
                        ArenaBorder.Add(new Point(x, y));
                    else 
                        Arena.Add(new Point(x, y));
                }
            }
        }

        public ICollection<Point> GetFreePoints(ISnake snake)
        {
            return Arena.Where(arenaPoint => snake.GetBody().All(snakePoint => !snakePoint.Equals(arenaPoint))).ToList();
        }

        public ICollection<Point> GetBorder()
        {
            return ArenaBorder;
        }

        public void Draw()
        {
            foreach (var point in ArenaBorder)
            {
                Console.SetCursorPosition(point.X, point.Y);

                if (point.Y == StartY)
                    Console.Write("-");
                else if (point.Y == EndY)
                    Console.Write("-");
                else if (point.X == StartX)
                    Console.Write("|");
                else if (point.X == EndX)
                    Console.Write("|");
            }
        } 
    }
}
