using System;

namespace assignment2
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
            Person[] array = new Person[3];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = ReadPerson();
                Console.WriteLine();
            }
            for (int i = 0; i < array.Length; i++)
            {
                PrintPerson(array[i]);
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        Person ReadPerson()
        {
            Person p2;
            p2.FirstName = ReadString("Enter first name: ");
            p2.LastName = ReadString("Enter last name: ");
            p2.Gender = ReadGender("Enter gender (m/f): ");
            p2.Age = ReadInt("Enter age: ");
            p2.City = ReadString("Enter city: ");

            return p2;
        }

        int ReadInt(string question)
        {
            Console.Write(question);
            return int.Parse(Console.ReadLine());
        }
        string ReadString(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }

        void PrintPerson(Person p)
        {
            Console.Write("{0} {1}",p.FirstName, p.LastName);
            PrintGender(p.Gender);
            Console.WriteLine("{0} years old, {1}", p.Age, p.City);
        }

        GenderType ReadGender(string question)
        {
            Console.Write(question);
            string gender = Console.ReadLine();
            if (gender == "f")
            {
                return GenderType.Female;
            }
            else
            {
                return GenderType.Male;
            }
        }

        void PrintGender(GenderType gender)
        {
            switch (gender)
            {
                case GenderType.Male:
                    Console.Write(" (m)\n");
                    break;
                case GenderType.Female:
                    Console.Write(" (f)\n");
                    break;
                default:
                    break;
            }
        }
    }
}
