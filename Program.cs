using System;

namespace ConwayGameOfLife
{
    static class Program
    {
        private const uint NumOfGenerations = 80;
        private const int Height = 15;
        private const int Width = 30;

        private static void Main()
        {
            int generations = 0;
            GameOfLife game = new(Height, Width);

            while (generations++ < NumOfGenerations)
            {
                game.DisplayMatrix();
                game.CreateNewGeneration();

                // Speed up or slow down the game
                System.Threading.Thread.Sleep(50);
            }
        }
    }
}