using System.Collections.Generic;
using Snake.Models;

namespace Snake.Interfaces
{
    public interface ISnake : IDrawable
    {
        void Move();
        void ChangeDirection(char c);
        void Eat();
        Point GetHead();
        ICollection<Point> GetBody();
        ICollection<Point> GetBodyWithoutHead();
    }
}
