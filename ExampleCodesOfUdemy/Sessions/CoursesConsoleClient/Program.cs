using CoursesConsoleClient.CoursesServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CoursesClient CC = new CoursesClient("NetTcpBinding_ICourses");
            CC.AddToCourses(new Course() { CourseId = int.Parse(Console.ReadLine()), CourseName = Console.ReadLine() });
            GetCourses(CC);

            CC = new CoursesClient("NetTcpBinding_ICourses");
            CC.AddToCourses(new Course() { CourseId = int.Parse(Console.ReadLine()), CourseName = Console.ReadLine() });
            GetCourses(CC);
            
            Console.ReadLine();

        }

        private static void GetCourses(CoursesClient CC)
        {
            Console.WriteLine();
            foreach (var item in CC.ListCourses())
            {
                Console.WriteLine("CourseId:{0} CourseName:{1}", item.CourseId, item.CourseName);
            }
        }
    }
}
