using System;
using System.Collections.Generic;

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
            List<Course> gradeList = ReadGradeList();
            //Course course = new Course();
            //course = ReadCourse("Enter a course.");
            //ReadGradeList(NrOfCourses, gradeList);
            //DisplayCourse(course);
            DisplayGradeList(gradeList);
            Console.ReadKey();
        }

        PracticalGrade ReadPracticalGrade(string question)
        {
            foreach (PracticalGrade item in Enum.GetValues(typeof(PracticalGrade)))
            {
                Console.Write("{0}. {1}  ", (int)item, item);
            }
            Console.WriteLine();
            Console.Write(question);
            PracticalGrade grade = (PracticalGrade)int.Parse(Console.ReadLine());

            return grade;
        }

        void DisplayPracticalGrade(PracticalGrade practical)
        {
            Console.WriteLine("{0}", practical);
        }

        Course ReadCourse(string question)
        {
            Course C = new Course();
            Console.Write(question);
            Console.ForegroundColor = ConsoleColor.Green;
            C.Name = Console.ReadLine();
            Console.ResetColor();
            Console.Write("Grade for {0}: ", C.Name);
            Console.ForegroundColor = ConsoleColor.Green;
            C.Grade = int.Parse(Console.ReadLine());
            Console.ResetColor();
            C.Practical = ReadPracticalGrade($"Practical grade for {C.Name}: ");
            return C;
        }

        void DisplayCourse(Course course)
        {
            Console.Write("{0,-15}: {1,-5} {2}  ", course.Name, course.Grade, course.Practical);
        }

        List<Course> ReadGradeList()
        {
            List<Course> gradeList = new List<Course>();

            for (int i = 0; i < 3; i++)
            {
                gradeList.Add(ReadCourse("Enter a course.\nName of the course: "));
                Console.WriteLine();
            }

            return gradeList;
        }

        void DisplayGradeList(List<Course> gradeList)
        {
            int NoR = 0; // Number of Retakes
            bool cum = true;
            
            foreach (Course course in gradeList)
            {
                DisplayCourse(course);
                Console.WriteLine();
                if (!course.Passed()) { NoR++; }
                if (!course.CumLaude()) { cum = false; }
            }

            if (NoR > 0)
            {
                Console.WriteLine("Too bad, you did not graduate, you got {0} retakes.", NoR);
            }
            else
            {
                if (cum) { Console.WriteLine("Congratulations, you graduated Cum Laude!"); }
                else { Console.WriteLine("Congratulations, you graduated!"); }
            }
        }
    }
}
