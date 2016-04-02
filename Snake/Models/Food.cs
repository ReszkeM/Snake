using Snake.Interfaces;

namespace Snake.Models
{
    public class Food : IEatable, IDrawable
    {
        public Point Point { get; set; }
        public int Weight { get; set; }
        public char Char { get; set; }

        public Food(Point point, int weight, char c)
        {
            Point = point;
            Weight = weight;
            Char = c;
        }

        public bool IsEaten(Point point)
        {
            return Point.X == point.X && Point.Y == point.Y;
        }

        public int GetWeight()
        {
            return Weight;
        }

        public void Draw()
        {
            Point.Show(Char);
        }

        public void Hide()
        {
            Point.Hide();
        }
    }
}
