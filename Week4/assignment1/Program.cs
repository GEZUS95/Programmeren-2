using System;
using System.IO;

namespace assignment1
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
            Person p = new Person();
            string name = ReadString("Enter your name: ");
            if (File.Exists(name+".txt")) // Terug kerende gebruiker
            {
                Console.WriteLine("Nice to see you again, {0}", name);
                Console.WriteLine("We have the following information about you:");
                p = ReadPerson(name + ".txt");
                DisplayPerson(p);
            }
            else // dus nieuwe gebruiker
            {
                Console.WriteLine("Welcome {0}", name);
                p = ReadPerson();
                WritePerson(p, name + ".txt");
            }

            Console.ReadKey();
        }

        string ReadString(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }
        int ReadInt(string question)
        {
            Console.Write(question);
            return int.Parse(Console.ReadLine());
        }

        Person ReadPerson()
        {
            Person p = new Person();

            p.name = ReadString("Enter your name: ");
            p.city = ReadString("Enter your city: ");
            p.age = ReadInt("Enter your age: ");

            return p;
        }

        void DisplayPerson(Person p)
        {
            Console.WriteLine("Name     : {0}", p.name);
            Console.WriteLine("City     : {0}", p.city);
            Console.WriteLine("Age      : {0}", p.age);
        }

        void WritePerson(Person p, string filename)
        {
            // open file
            StreamWriter writer = new StreamWriter(filename);

            // write lines
            writer.WriteLine(p.name);
            writer.WriteLine(p.city);
            writer.WriteLine(p.age);

            //close writer !!DO NOT FORGET!!
            writer.Close();

            Console.WriteLine("Your data is written to file.");
        }

        Person ReadPerson(string filename)
        {
            Person p = new Person();
            StreamReader reader = new StreamReader(filename);

            p.name = reader.ReadLine();
            p.city = reader.ReadLine();
            p.age = int.Parse(reader.ReadLine());

            reader.Close();

            return p;
        }
    }
}
