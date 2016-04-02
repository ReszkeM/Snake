using System;
using System.Threading;
using Snake.Helpers;
using Snake.Interfaces;

namespace Snake.Models
{
    public class Game : IPlayable
    {
        public ISnake Snake { get; set; }
        public IMap Map { get; set; }
        public Food Food { get; set; }
        public Food SuperFood { get; set; }
        public double SpeedInSeconds { get; set; }
        public int Points { get; set; }
        public int FoodCounter { get; set; }
        public int SuperFoodCounter { get; set; }

        public Game(ISnake snake, IMap map, double speedInSeconds)
        {
            Snake = snake;
            Map = map;
            SpeedInSeconds = speedInSeconds;
        }

        public void Start()
        {
            Init();

            while (CheckCollisions())
            {
                DetectDirectionChange();
                Move();
                FoodGenerator();
                PrintPoints();
                ExecuteDeley();
            }
        }

        public void PrintMessage()
        {
            Console.SetCursorPosition(15, 10);
            Console.Write(String.Format("Koniec gry, punkty: {0}", Points));
        }

        private bool CheckCollisions()
        {
            if (CollisionHelper.CheckCollision(Snake, Map.GetBorder()))
                return false;
            if (CollisionHelper.CheckCollision(Snake, Snake.GetBodyWithoutHead()))
                return false;
            if (CollisionHelper.CheckCollision(Snake, Food))
            {
                Snake.Eat();
                Points += Food.Weight;
                Food = null;
            }
            else if (CollisionHelper.CheckCollision(Snake, SuperFood))
            {
                Snake.Eat();
                Points += SuperFood.Weight;
                SuperFood = null;
            }
            return true;
        }

        private void Init()
        {
            Points = 0;
            FoodCounter = 0;
            SuperFoodCounter = 0;
            DrawElements();
        }

        private void DrawElements()
        {
            Map.Draw();
            Snake.Draw();
        }

        private void Move()
        {
            Snake.Move();
        }

        private void FoodGenerator()
        {
            if (Food != null && FoodCounter == 20)
            {
                Food.Hide();
                Food = null;
            }
            else if (Food == null)
            {
                Food = new Food(PointsGeneratorHelper.NewPoint(Map.GetFreePoints(Snake)), 1, 'x');
                Food.Draw();
                FoodCounter = 0;
            }

            if (SuperFood != null && SuperFoodCounter == 15)
            {
                SuperFood.Hide();
                SuperFood = null;
            }
            else if (SuperFoodCounter == 50)
            {
                SuperFood = new Food(PointsGeneratorHelper.NewPoint(Map.GetFreePoints(Snake)), 5, '$');
                SuperFood.Draw();
                SuperFoodCounter = 0;
            }

            FoodCounter++;
            SuperFoodCounter++;
        }

        private void PrintPoints()
        {
            Console.SetCursorPosition(2, 2);
            Console.Write(String.Format("Punkty: {0}", Points));
        }

        private void DetectDirectionChange()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                Snake.ChangeDirection(key.KeyChar);
            }
        }

        private void ExecuteDeley()
        {
            Thread.Sleep((int)(SpeedInSeconds * 1000));
        }
    }
}
