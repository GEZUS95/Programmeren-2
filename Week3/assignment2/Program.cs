using System;
using System.Collections.Generic;

namespace assignment2
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
            List<string> words = ListOfWords();
            HangmanGame hangman = new HangmanGame();
            hangman.Init(SelectWord(words));
            bool won = PlayHangman(hangman);
            Console.WriteLine(hangman.guessedWord);
            if (won)
            {
                Console.WriteLine("You guessed the word");
            }
            else
            {
                Console.WriteLine("Too bad, you did not guess the word ({0})", hangman.secretWord);
            }
            Console.ReadKey();
        }

        List<string> ListOfWords()
        {
            List<string> words = new List<string>();
            words.Add("airplane");
            words.Add("kitchen");
            words.Add("building");
            words.Add("incredible");
            words.Add("funny");
            words.Add("trainstation");
            words.Add("neighbour");
            words.Add("different");
            words.Add("department");
            words.Add("planet");
            words.Add("presentation");
            words.Add("embarrassment");
            words.Add("integration");
            words.Add("scenario");
            words.Add("discount");
            words.Add("management");
            words.Add("understanding");
            words.Add("registration");
            words.Add("security");
            words.Add("language");

            return words;
        }

        string SelectWord(List<string> words)
        {
            Random rnd = new Random();
            int r = rnd.Next(words.Count);

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
                return true;
            }
            
            return false;
        }

        void DisplayWord(string word)
        {
            foreach (char c in word)
            {
                Console.Write(" {0} ", c);
            }
            Console.WriteLine("\n\n");
        }

        void DisplayLetters(List<char> letters)
        {
            Console.Write("Entered letters: ");
            foreach (char c in letters)
            {
                Console.Write("{0} ",c);
            }
            Console.WriteLine("\n");
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
            return letter;
        }
    }
}
