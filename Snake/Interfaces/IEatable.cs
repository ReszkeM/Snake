using Snake.Models;

namespace Snake.Interfaces
{
    public interface IEatable
    {
        bool IsEaten(Point point);
    }
}
