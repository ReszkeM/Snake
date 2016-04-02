using System.Collections.Generic;
using System.Linq;
using Snake.Interfaces;
using Snake.Models;

namespace Snake.Helpers
{
    public static class CollisionHelper
    {
        public static bool CheckCollision(ISnake snake, ICollection<Point> pointsToCheck)
        {
            return pointsToCheck.Any(p => snake.GetHead().Equals(p));
        }
        public static bool CheckCollision(ISnake snake, Food food)
        {
            return food != null && food.IsEaten(snake.GetHead());
        }
    }
}
