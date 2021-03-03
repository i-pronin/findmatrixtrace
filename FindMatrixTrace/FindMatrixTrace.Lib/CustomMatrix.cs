using System;
using System.Collections.Generic;
using System.Linq;
namespace FindMatrixTrace.Lib
{
    public class CustomMatrix
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int[,] Matrix { get; private set;}
        public int Trace { get; private set;}


        public CustomMatrix(int height, int width)
        {
            Height = height;
            Width = width;
            Matrix = new int[Height, Width];
            Trace = 0;
            PopulateMatrix();
        }

        public int GetTraceSum()
        {
            if (Trace == 0)
            {
                for (var i = 0; i < Height && i < Width; i++)
                {
                    Trace += Matrix[i, i];
                }
            }
            return Trace;
        }

        private void PopulateMatrix()
        {
            var random = new Random();
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    Matrix[i, j] = random.Next(0, 101);
                }
            }
        }

        public void DisplayMatrix()
        {
            Console.WriteLine();
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    if (i == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.Write($"{Matrix[i, j],-3} ");
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }

    }
}
