using System;
using System.Collections.Generic;
using System.IO;

namespace Opgave3
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
            List<Stelling> stellingen = LeesStellingen("stellingen.txt");
            if (stellingen == 0)
            {
                Console.WriteLine("Geen stellingen gelezen...");
                return;
            }
            List<Partij> partijen = LeesPartijen("partijen.txt");
            if (partijen == 0)
            {
                Console.WriteLine("Geen partijen gelezen...");
                return;
            }

            string gebruiker = DoorloopStellingen(stellingen);
            VergelijkPartijen(gebruiker, partijen);
        }

        List<Stelling> LeesStellingen(string bestand)
        {
            List<Stelling> stellingen = new List<Stelling>();

            if (File.Exists(bestand))
            {
                StreamReader reader = new StreamReader(bestand);
                while (!reader.EndOfStream)
                {
                    Stelling stelling = new Stelling();
                    stelling.Titel = reader.ReadLine();
                    stelling.tekst = reader.ReadLine();
                    stellingen.Add(stelling);
                }
                reader.Close();
            }
            return stellingen;
        }

        List<Partij> LeesPartijen(string bestand)
        {
            List<Partij> partijen = new List<Partij>();
            
            if (File.Exists(bestand))
            {
                StreamReader reader = new StreamReader(bestand);
                while (!reader.EndOfStream)
                {
                    Partij partij = new Partij();
                    partij.naam = reader.ReadLine();
                    partij.antwoorden = reader.ReadLine();
                    partijen.Add(partij);
                }
                reader.Close();
            }
            return partijen;

        }

        string DoorloopStellingen(List<Stelling> stellingen)
        {
            string antwoorden = "";
            int count = 1;
            foreach (Stelling stelling in stellingen)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0}. {1}", count, stelling.Titel);
                Console.ResetColor();
                Console.WriteLine(stelling.tekst);
                Console.WriteLine();

                Console.Write("Geef uw menig (1=eens / 2=oneens / 3=geen): ");

                Console.WriteLine();
                count++;
            }
            return antwoorden;
        }

        double BepaalMatchPercentage(string gebruiker, Partij partij)
        {
            int count = 0;
            for (int i = 0; i < gebruiker.Length; i++)
            {
                if(gebruiker[i] == partij.antwoorden[i])
                {
                    count++;
                }
            }

            return (count / partij.antwoorden.Length * 100);
        }

        void VergelijkPartijen(string gebruiker, List<Partij> partijen)
        {
            foreach (Partij partij in partijen)
            {
                double percentage = BepaalMatchPercentage(gebruiker, partij);
                Console.WriteLine("{0,-3} : {1.0} %", partij.naam, percentage);
            }
        }

    }
}
