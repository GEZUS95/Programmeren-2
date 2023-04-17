using System;
using System.Collections.Generic;
using System.IO;

namespace assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("invalid number of arguments!");
                Console.WriteLine("usage: assignment[3-4] <filename>");
                return;
            }
            string filename = args[0];
            Program myProgram = new Program();
            myProgram.Start(filename);
        }
        void Start(string filename)
        {
            List<string> words = ReadWords(filename, 5);
            string lingoWord = SelectWord(words);

            LingoGame lingoGame = new LingoGame();
            lingoGame.Init(lingoWord);
            if (PlayLingo(lingoGame))
            {
                Console.WriteLine("You have guessed the word!");
            }
            else { Console.WriteLine("Too bad, you did not guess the word ({0})", lingoGame.lingoWord); }
        }

        List<string> ReadWords(string filename, int lenght)
        {
            List<string> w = new List<string>();
            StreamReader reader = new StreamReader(filename);

            while (!reader.EndOfStream)
            {
                string word = reader.ReadLine();
                if (word.Length == lenght)
                {
                    w.Add(word);
                }
            }
            return w;
        }

        string SelectWord(List<string> words)
        {
            Random rnd = new Random();
            int n = rnd.Next(words.Count);

            return words[n];
        }

        bool PlayLingo(LingoGame lingoGame)
        {
            int pogingen = 0;
            int wordLenght = lingoGame.lingoWord.Length;

            while (pogingen < 5 && !lingoGame.WordGuessed())
            {
                Console.WriteLine("Enter a (5-letter) word, attempt {0}: ", pogingen);
                lingoGame.playerWord = ReadPlayerWord(wordLenght);
                LetterState[] letterResults = lingoGame.ProcessWord(lingoGame.playerWord);
                DisplayPlayerWord(lingoGame.playerWord, letterResults);

                pogingen++;
            }
            return lingoGame.WordGuessed();
        }

        string ReadPlayerWord(int length)
        {
            string word = "";
            do
            {
                word = Console.ReadLine();
                
            } while (word.Length != length);
            
            string test = word.ToUpper();
            return test;
        }

        void DisplayPlayerWord(string playerword, LetterState[] letterResults)
        {
            for (int i = 0; i < playerword.Length; i++)
            {
                if (letterResults[i] == LetterState.Correct)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }
                else if (letterResults[i] == LetterState.WrongPosition)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }

                Console.Write(playerword[i]);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}
