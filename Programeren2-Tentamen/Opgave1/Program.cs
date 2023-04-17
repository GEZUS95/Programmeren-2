using System;

namespace Opgave1
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
            Console.Write("Enter ISBN number: ");
            string isbn = Console.ReadLine();
            ISBNValidation isValid = ValidateISBN(isbn);
            switch (isValid)
            {
                case ISBNValidation.InvalidISBN: Console.WriteLine("Invalid ISBN number!"); ;break;
                case ISBNValidation.ValidISBN13: Console.WriteLine("Valid ISBN-13 number"); ;break;
                default: break;
            }
        }

        ISBNValidation ValidateISBN(string isbn)
        {
            ISBNValidation valid = ISBNValidation.InvalidISBN;

            if (isbn.Length >= 13)
            {
                if (IsValidISBN13(isbn))
                {
                    valid = ISBNValidation.ValidISBN13;
                }
            }

            return valid;
        }

        bool IsValidISBN13(string isbn)
        {
            bool isValid = false;
            try
            {
                foreach (char c in isbn)
                {
                    if(c < '0' || c > '9')
                    {
                        throw new Exception("Invalid isbn character!");
                    }
                }

                isbn = isbn.Replace("-", "");
                if (isbn.Length == 13)
                {
                    int som, totaal = 0;
                    for (int i = 0; i < isbn.Length; i++)
                    {
                        int nummer = isbn[i] - '0';
                        if ((i % 2) == 1)
                        {
                            som = nummer * 3;
                        }
                        else
                        {
                            som = nummer;
                        }

                        totaal = totaal + som;
                    }
                    if ((totaal % 10) == 0) isValid = true;
                }
            }
            catch (Exception e) { Console.ForegroundColor = ConsoleColor.Red; Console.Write(e);}
            

            return isValid;
        }
    }
}
