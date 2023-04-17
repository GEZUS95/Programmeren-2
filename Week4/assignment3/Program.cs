using System;
using System.IO;
using System.Linq;

namespace assignment3
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
            Console.Write("Enter a word (to search): ");
            string word = Console.ReadLine();
            int count = SearchWordInFile(filename, word);
            Console.WriteLine("Number of lines containing the word: {0}", count);
        }

        bool WordInLine(string line, string word)
        {
            return (line.IndexOf(word, StringComparison.CurrentCultureIgnoreCase) >= 0);
        }

        int SearchWordInFile(string filename, string word)
        {
            StreamReader reader = new StreamReader(filename);
            int count = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (WordInLine(line, word))
                {
                    //Console.WriteLine(line);
                    DisplayWordInLine(line, word);
                    Console.WriteLine(); count++;

                }
            }
            return count;
        }

        void DisplayWordInLine(string line, string word)
        {
            int start = line.IndexOf(word, StringComparison.OrdinalIgnoreCase);
            int end = start + word.Length - 1;

            for (int i = 0; i < line.Length; i++)
            {
                if (i == start)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("[");
                }

                Console.Write(line[i]);

                if (i == end)
                {
                    Console.Write("]");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();

        }
    }
}
