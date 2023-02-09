using System;

namespace ConwayGameOfLife
{
    public class GameOfLife
    {
        private readonly int Height;
        private readonly int Width;
        private readonly int[,] matrix;

        public GameOfLife(int Height, int Width)
        {
            this.Height = Height;
            this.Width = Width;
            matrix= new int[Height, Width];
            GenerateMatrix();
        }

        private void GenerateMatrix()
        {
            Random rnd = new();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    matrix[i, j] = rnd.Next(0, 2);
                }
            }
        }

         public void DisplayMatrix()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                    if (j == Width - 1) Console.WriteLine("\r");
                }
            }
            Console.SetCursorPosition(0, Console.WindowTop);
        }

        public void CreateNewGeneration()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int liveNeighbors = CountLiveNeighbors(matrix, i, j, Height, Width);
                    if (matrix[i, j] == 1)
                    {
                        // A live cell with 2 or 3 live neighbors stays alive
                        if (liveNeighbors == 2 || liveNeighbors == 3)
                        {
                            matrix[i, j] = 1;
                        }
                        // A live cell with fewer than 2 or more than 3 live neighbors dies
                        else
                        {
                            matrix[i, j] = 0;
                        }
                    }
                    else
                    {
                        // A dead cell with exactly 3 live neighbors becomes alive
                        if (liveNeighbors == 3)
                        {
                            matrix[i, j] = 1;
                        }
                    }
                }
            }
        }

        static int CountLiveNeighbors(int[,] matrix, int i, int j, int height, int width)
        {
            int liveNeighbors = 0;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0) continue;

                    int row = i + x;
                    int col = j + y;
                    if (row >= 0 && row < height && col >= 0 && col < width)
                    {
                        if (matrix[row, col] == 1)
                        {
                            liveNeighbors++;
                        }
                    }
                }
            }
            return liveNeighbors;
        }
    }
}
