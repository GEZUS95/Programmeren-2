using System;

namespace Opgave2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            int[,] matrix = new int[5, 10];
            VulMatrix(matrix);
            ToonMatrix(matrix);
            Console.Write("Geef een getal: ");
            int getal = int.Parse(Console.ReadLine());
            VerschuifMatrix(matrix, getal);
            ToonMatrix(matrix);
        }

        void VulMatrix(int[,] matrix)
        {
            Random rnd = new Random();
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[r, k] = rnd.Next(1, 100);
                }
            }
        }

        void ToonMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    Console.Write("{0, 3}", matrix[r, k]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        void VerschuifMatrix(int[,] matrix, int zoekgetal)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[r, k] == zoekgetal)
                    {
                        Console.WriteLine("verschuif rij {0} vanaf kolom {1}...", r + 1, k + 1);
                        VerschuifRij(matrix, r, k);
                        break;
                    }
                }
            }
        }

        void VerschuifRij(int[,] matrix, int rij, int kolom)
        {
            int[] tempRow = new int[matrix.GetLength(1)];
            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                tempRow[k] = matrix[rij, kolom];
                kolom = (kolom + 1) % matrix.GetLength(1);
            }

            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                matrix[rij, k] = tempRow[k];
            }
        }

    }
}
