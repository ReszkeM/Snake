using System;
using Snake.Models;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(new Models.Snake(25, 15), new Map(10, 40, 5, 20), 0.3);
            game.Start();
            game.PrintMessage();

            Console.ReadKey();
        }
    }
}