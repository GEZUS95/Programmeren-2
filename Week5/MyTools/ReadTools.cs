using System;

namespace MyTools
{
    public class ReadTools
    {
        public static int ReadInt(string question)
        {
            Console.Write(question);
            return int.Parse(Console.ReadLine());
        }

        public static int ReadInt(string question, int min, int max)
        {
            Console.Write(question);
            int answer = int.Parse(Console.ReadLine());
            while ((answer < min) || (answer > max))
            {
                Console.Write(question);
                answer = int.Parse(Console.ReadLine());
            }
            return answer;
        }
        public static string ReadString(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }
    }

}
