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
            const int RIJEN = 5;
            const int KOLOMEN = 5;

            int[,] bingoKaart = new int[RIJEN, KOLOMEN];
            VulBingoKaart(bingoKaart);
            ToonBingoKaart(bingoKaart);
        }

        void VulBingoKolom(int[,] bingoKaart, int kolom, int minGetal, int maxGetal)
        {
            Random rnd = new Random();
            for (int r = 0; r < bingoKaart.GetLength(0); r++)
            {
                int randomGetal = rnd.Next(minGetal, maxGetal);
                if (bingoKaart[(r % 2), kolom] == randomGetal) { randomGetal = rnd.Next(minGetal, maxGetal); }
                bingoKaart[r, kolom] = randomGetal;
            }
        }

        void VulBingoKaart(int[,] bingoKaart)
        {
            for (int k = 0; k < bingoKaart.GetLength(1); k++)
            {
                int min = 0; 
                int max = 0;
                switch (k)
                {
                    case 0: min = 1; max = 16;break;
                    case 1: min = 16; max = 31;break;
                    case 2: min = 31; max = 46;break;
                    case 3: min = 46; max = 61;break;
                    case 4: min = 61; max = 76;break;
                    default:break;
                }

                VulBingoKolom(bingoKaart, k, min, max);
                bingoKaart[2, 2] = 0;
            }
        }

        void ToonBingoKaart(int[,] bingoKaart)
        {
            for (int r = 0; r < bingoKaart.GetLength(0); r++)
            {
                for (int k = 0; k < bingoKaart.GetLength(1); k++)
                {
                    if (bingoKaart[r, k] <= 0)
                    {
                        Console.Write(" --");
                    }
                    else
                    {
                        Console.Write("{0, 3}", bingoKaart[r, k]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
