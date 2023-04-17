using System;
using CandyCrusherLogic;

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
            int[,] playingField = new int[nrOfRows, nrOfColumns];
            InitCandies(playingField);
            DisplayCandies(playingField);
            Console.WriteLine();
            if (CandyCrusher.ScoreRowPresent(playingField) == true)
            {
                Console.WriteLine("row score");
            }
            else
            {
                Console.WriteLine("no row score");
            }
            if (CandyCrusher.ScoreColumnPresent(playingField) == true)
            {
                Console.WriteLine("column score");
            }
            else
            {
                Console.WriteLine("no column score");
            }
            Console.ReadKey();
        }

        void InitCandies(int[,] playingField)
        {
            Random rnd = new Random();
            for (int r = 0; r < playingField.GetLength(0); r++)
            {
                for (int k = 0; k < playingField.GetLength(1); k++)
                {
                    playingField[r, k] = (int)(RegularCandies)rnd.Next(0, 6);
                }
            }
        }
        void DisplayCandies(int[,] playingField)
        {
            for (int r = 0; r < playingField.GetLength(0); r++)
            {
                for (int k = 0; k < playingField.GetLength(1); k++)
                {
                    switch (playingField[r,k])
                    {
                        case 0: Console.ForegroundColor = ConsoleColor.Red; break;
                        case 1: Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                        case 2: Console.ForegroundColor = ConsoleColor.Yellow; break;
                        case 3: Console.ForegroundColor = ConsoleColor.Green; break;
                        case 4: Console.ForegroundColor = ConsoleColor.Blue; break;
                        case 5: Console.ForegroundColor = ConsoleColor.Magenta; break;
                        default:
                            break;
                    }
                    Console.Write("#");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        
    }
}
