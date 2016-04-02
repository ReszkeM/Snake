using System.Collections.Generic;
using System.Linq;
using Snake.Collections;
using Snake.Enums;
using Snake.Interfaces;

namespace Snake.Models
{
    public class Snake : ISnake
    {
        public Deque<Point> Body { get; set; }
        public Point LastHiddenPoint { get; set; }
        public Direction Direction { get; set; }

        public Snake(int x, int y, int length = 4, Direction dir = Direction.Up)
        {
            Body = new Deque<Point>();
            Direction = dir;

            for (int i = 0; i < length; i++)
            {
                Body.AddToFront(new Point(x, y - i));
            }
        }

        public void Move()
        {
            LastHiddenPoint = Body.RemoveFromBack();
            LastHiddenPoint.Hide();

            Point point = Body.First();
            var p = new Point(point.X, point.Y);

            switch (Direction)
            {
                case Direction.Up:
                    p.Y--;
                    break;
                case Direction.Down:
                    p.Y++;
                    break;
                case Direction.Left:
                    p.X--;
                    break;
                case Direction.Right:
                    p.X++;
                    break;
            }

            p.Show();
            Body.AddToFront(p);
        }

        public Point GetHead()
        {
            return Body.First();
        }

        public ICollection<Point> GetBody()
        {
            return Body.ToList();
        }

        public ICollection<Point> GetBodyWithoutHead()
        {
            var newList = new List<Point>();

            for (var i = 1; i < Body.Count; i++)
            {
                newList.Add(Body[i]);
            }

            return newList;
        } 

        public void ChangeDirection(char c)
        {
            if (c == 'w' && Direction != Direction.Down && Direction != Direction.Up)
                Direction = Direction.Up;
            else if (c == 's' && Direction != Direction.Up && Direction != Direction.Down)
                Direction = Direction.Down;
            else if (c == 'a' && Direction != Direction.Right && Direction != Direction.Left)
                Direction = Direction.Left;
            else if (c == 'd' && Direction != Direction.Left && Direction != Direction.Right)
                Direction = Direction.Right;
        }

        public void Eat()
        {
            Body.AddToBack(LastHiddenPoint);
        }

        public void Draw()
        {
            foreach (var point in Body)
            {
                point.Show();
            }
        }
    }
}
