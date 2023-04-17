using System;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("invalid number of arguments!");
                Console.WriteLine("usage: assignment[1-3] <nrOfRows> <nrOfColumns>");
                return;
            }
            int nrOfRows = int.Parse(args[0]);
            int nrOfColumns = int.Parse(args[1]);
            Program myProgram = new Program();
            myProgram.Start(nrOfRows, nrOfColumns);
        }

        void Start(int nrOfRows, int nrOfColumns)
        {
            int[,] matrix = new int[nrOfRows, nrOfColumns];
            InitMatrix2D(matrix);
            //InitMatrixLinear(matrix);
            //DisplayMatrix(matrix);
            DisplayMatrixWithCross(matrix);
            Console.ReadKey();
        }

        void InitMatrix2D(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    int getal = (r * matrix.GetLength(1)) + k + 1;
                    matrix[r, k] = getal;
                }
            }
        }

        void InitMatrixLinear(int[,] matrix)
        {
            for (int getal = 1; getal < matrix.Length; getal++)
            {
                int row = (getal - 1) / getal;
                int col = (getal - 1) % getal;
                matrix[row, col] = getal;
            }
        }

        void DisplayMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    Console.Write("{0,3}", matrix[r, k]);
                }
                Console.WriteLine();
            }
        }

        void DisplayMatrixWithCross(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (r == k)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if ((r + k) == (matrix.GetLength(1) - 1))
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write("{0,3}", matrix[r, k]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}

