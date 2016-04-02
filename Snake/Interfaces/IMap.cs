using System.Collections.Generic;
using Snake.Models;

namespace Snake.Interfaces
{
    public interface IMap : IDrawable
    {
        ICollection<Point> GetFreePoints(ISnake snake);
        ICollection<Point> GetBorder();
    }
}
