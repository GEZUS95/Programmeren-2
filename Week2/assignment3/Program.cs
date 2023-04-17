using System;

namespace assignment3
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
            RegularCandies[,] playingField = new RegularCandies[nrOfRows, nrOfColumns];
            InitCandies(playingField);
            DisplayCandies(playingField);
            Console.WriteLine();
            if (ScoreRowPresent(playingField) == true)
            {
                Console.WriteLine("row score");
            }
            else
            {
                Console.WriteLine("no row score");
            }
            if (ScoreColumnPresent(playingField) == true)
            {
                Console.WriteLine("column score");
            }
            else
            {
                Console.WriteLine("no column score");
            }
            Console.ReadKey();
        }

        void InitCandies(RegularCandies[,] playingField)
        {
            Random rnd = new Random();
            for (int r = 0; r < playingField.GetLength(0); r++)
            {
                for (int k = 0; k < playingField.GetLength(1); k++)
                {
                    RegularCandies candy = (RegularCandies)rnd.Next(0, 6);
                    playingField[r, k] = candy;
                }
            }
        }
        void DisplayCandies(RegularCandies[,] playingField)
        {
            for (int r = 0; r < playingField.GetLength(0); r++)
            {
                for (int k = 0; k < playingField.GetLength(1); k++)
                {
                    if (playingField[r, k] == RegularCandies.JellyBean)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (playingField[r, k] == RegularCandies.Lozenge)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (playingField[r, k] == RegularCandies.LemonDrop)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (playingField[r, k] == RegularCandies.Gum_Square)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (playingField[r, k] == RegularCandies.LollipopHead)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (playingField[r, k] == RegularCandies.Jujube_Cluster)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    Console.Write("#");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        bool ScoreRowPresent(RegularCandies[,] playingField)
        {
            bool scoreRAanwezig = false;
            for (int r = 0; r < playingField.GetLength(0); r++)
            {
                int count = 0;
                RegularCandies candy = 0;
                for (int k = 0; k < playingField.GetLength(1); k++)
                {
                    if (playingField[r, k] == candy)
                    {
                        count++;
                        if (count >= 3)
                        {
                            scoreRAanwezig = true;
                            break;
                        }
                    }
                    else
                    {
                        candy = playingField[r, k];
                        count = 1;
                    }
                }
            }
            return scoreRAanwezig;
        }

        bool ScoreColumnPresent(RegularCandies[,] playingField)
        {
            for (int k = 0; k < playingField.GetLength(1); k++)
            {
                int count = 0;
                RegularCandies candy = RegularCandies.JellyBean;
                for (int r = 0; r < playingField.GetLength(0); r++)
                {
                    if (playingField[r, k] == candy)
                    {
                        count++;
                        if (count >= 3)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        candy = playingField[r, k];
                        count = 1;
                    }
                }
            }
            return false;
        }
    }
}
