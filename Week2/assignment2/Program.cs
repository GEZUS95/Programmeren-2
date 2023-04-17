using System;

namespace assignment2
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
            InitMatrixRandom(matrix, 1, 100);
            DisplayMatrix(matrix);
            Console.WriteLine();
            Console.Write("Enter a number (to search for): ");
            int number = int.Parse(Console.ReadLine());
            Position first = SearchNumber(matrix, number);
            Position last = SearchNumberBackwards(matrix, number);
            Console.WriteLine("Number {0} is found (first) at position [{1},{2}]", number, first.row, first.colum);
            Console.WriteLine("Number {0} is found (last) at position [{1},{2}]", number, last.row, last.colum);
            Console.ReadKey();
        }

        void InitMatrixRandom(int[,] matrix, int min, int max)
        {
            Random rnd = new Random();
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[r, k] = rnd.Next(min, max);
                }
            }
        }

        void DisplayMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    Console.Write("{0,5}", matrix[r, k]);
                }
                Console.WriteLine();
            }
        }
        Position SearchNumber(int[,] matrix, int number)
        {
            Position pos = new Position();
            pos.row = pos.colum = -1;
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[r, k] == number)
                    {
                        pos.row = r;
                        pos.colum = k;
                        return pos;
                    }
                }
            }
            return pos;
        }

        Position SearchNumberBackwards(int[,] matrix, int number)
        {
            Position pos = new Position();
            pos.row = pos.colum = -1;
            for (int r = (matrix.GetLength(0) - 1); r >= 0; r--)
            {
                for (int k = (matrix.GetLength(1) - 1); k >= 0; k--)
                {
                    if (matrix[r, k] == number)
                    {
                        pos.row = r;
                        pos.colum = k;
                        return pos;
                    }
                }
            }
            return pos;
        }
    }
}
