using System;

namespace opgave1
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
            Console.Write("Geef een zin: ");
            string zin = Console.ReadLine();
            string nieuweZin = HusselZinWoorden(zin);
            Console.WriteLine(nieuweZin);
            Console.ReadKey();
        }

        string HusselZinWoorden(string zin)
        {
            string husselzin = "";
            string[] woorden = zin.Split(' ');
            foreach(string woord in woorden)
            {
                husselzin += HusselWoord(woord) + " ";
            }
            return husselzin;
        }

        string HusselWoord(string woord)
        {
            if(woord.Length <= 3)
            {
                return woord;
            }

            string nieuwWoord = woord[0].ToString();
            string restWoord = woord.Substring(1, (woord.Length - 2));
            Random rnd = new Random();
            while (restWoord.Length > 0)
            {
                int randomIndex = rnd.Next(restWoord.Length);
                nieuwWoord += restWoord[randomIndex];
                restWoord = restWoord.Remove(randomIndex, 1);
            }
            nieuwWoord += woord[woord.Length - 1];
            return nieuwWoord;
        }
    }
}
