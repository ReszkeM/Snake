using System;

namespace Snake.Models
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Show(char c = 'x')
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(c);
        }

        public void Hide()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }

        public bool Equals(Point point)
        {
            return X == point.X && Y == point.Y;
        }
    }
}
