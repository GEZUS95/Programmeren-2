using System;

namespace assignment1
{
    class Program
    {
        static void Main()
        {
            Program myProgram = new Program();
            myProgram.Start();
        }
        void Start()
        {
            PrintMonths();
            Month input = ReadMonth("Enter a month number: ");
            Console.WriteLine("{0} => {1}", (int)input , input);
            Console.ReadKey();
        }

        void PrintMonth(Month month)
        {
            Console.Write(month + "\n");
        }

        void PrintMonths()
        {
            foreach (Month m in Enum.GetValues(typeof(Month)))
            {
                Console.WriteLine("{0,5}. {1}", (int)m, m);
            }
        }

        Month ReadMonth(string question)
        {
            Console.Write(question);
            int invoer = int.Parse(Console.ReadLine());

            while (!Enum.IsDefined(typeof(Month), (Month)invoer))
            {
                Console.WriteLine("{0} is not a valid value.", invoer);
                Console.Write(question);
                invoer = int.Parse(Console.ReadLine());
            }
            Month read = (Month)invoer;
            return read;
        }
    }
}
