using System;
using System.Collections.Generic;
using System.IO;

namespace assignment3
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
            Dictionary<string, string> Dictionary = ReadWords(filename);
            TranslateWords(Dictionary);
            Console.ReadKey();
        }

        Dictionary<string, string> ReadWords(string filename)
        {
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();

            StreamReader reader = new StreamReader(filename);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] items = line.Split(';');
                string dutchWord = items[0];
                string englishWord = items[1];
                Dictionary.Add(dutchWord, englishWord);
            }

            reader.Close();

            return Dictionary;
        }

        void TranslateWords(Dictionary<string, string> words)
        {
            Console.Write("Enter a word: ");
            string invoer = Console.ReadLine();

            while (invoer != "stop")
            {
                if (invoer == "listall")
                {
                    ListAllWords(words);
                }
                else if (!words.ContainsKey(invoer))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("word '{0}' not found", invoer);
                    Console.ResetColor();
                }
                else if (words.ContainsKey(invoer))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    words.TryGetValue(invoer, out string val);
                    Console.WriteLine("{0} => {1}", invoer , val);
                    Console.ResetColor();
                }
                
                Console.Write("Enter a word: ");
                invoer = Console.ReadLine();
            }
        }

        void ListAllWords(Dictionary<string, string> words)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (KeyValuePair<string, string> word in words)
            {
                Console.WriteLine("{0} => {1}", word.Key, word.Value);
            }
            Console.ResetColor();
        }
    }
}
