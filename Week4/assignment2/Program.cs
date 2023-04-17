using System;
using System.Collections.Generic;
using System.IO;

namespace assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("invalid number of arguments!");
                Console.WriteLine("usage: assignment[2-3] <filename>");
                return;
            }
            string filename = args[0];
            Program myProgram = new Program();
            myProgram.Start(filename);
        }

        void Start(string filename)
        {
            List<string> words = ListOfWords(filename);
            HangmanGame hangman = new HangmanGame();
            hangman.Init(SelectWord(words));
            bool won = PlayHangman(hangman);
            if (won)
            {
                Console.WriteLine("You guessed the word");
            }
            else
            {
                DisplayWord(hangman.guessedWord);
                Console.WriteLine("Too bad, you did not guess the word ({0})", hangman.secretWord);
            }
            Console.ReadKey();
        }

        List<string> ListOfWords(string filename)
        {
            List<string> words = new List<string>();

            StreamReader reader = new StreamReader(filename);

            while (!reader.EndOfStream)
            {
                words.Add(reader.ReadLine());
            }

            reader.Close();

            return words;
        }

        string SelectWord(List<string> words)
        {
            Random rnd = new Random();
            int r = rnd.Next(words.Count);
            while (r <= 3)
            {
                r = rnd.Next(words.Count);
            }
            return words[r];
        }

        bool PlayHangman(HangmanGame hangman)
        {
            int attemptsLeft = 8;
            List<char> enteredLetters = new List<char>();
            while (!hangman.IsGuessed() && (attemptsLeft != 0))
            {
                DisplayWord(hangman.guessedWord);
                char l = ReadLetter(enteredLetters);
                if (!enteredLetters.Contains(l))
                {
                    enteredLetters.Add(l);
                    if (hangman.ContainsLetter(l))
                    {
                        hangman.ProcessLetter(l);
                    }
                    else { attemptsLeft--; }
                }
                else { attemptsLeft--; }
                DisplayLetters(enteredLetters);
                Console.WriteLine("Attempts left: {0}", attemptsLeft);
                Console.WriteLine();
            }
            if (hangman.IsGuessed())
            {
                DisplayWord(hangman.guessedWord);
                return true;
            }
            
            Console.WriteLine();

            return false;
        }

        void DisplayWord(string word)
        {
            foreach (char c in word)
            {
                Console.Write("{0} ", c);
            }
            Console.WriteLine();
        }

        void DisplayLetters(List<char> letters)
        {
            Console.Write("Entered letters: ");
            foreach (char c in letters)
            {
                Console.Write("{0} ",c);
            }
            Console.WriteLine();
        }

        char ReadLetter(List<char> blacklistLetters)
        {
            Console.Write("Enter a letter: ");
            char letter = char.Parse(Console.ReadLine());
            while (blacklistLetters.Contains(letter))
            {
                Console.Write("Enter a letter: ");
                letter = char.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            Console.WriteLine();
            return letter;
        }
    }
}
