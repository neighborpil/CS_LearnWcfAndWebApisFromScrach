using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseConsoleClient.ServiceReference1;

namespace CourseConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var coursesClient = new CoursesClient("BasicHttpBinding_ICourses");
            coursesClient.AddToCourse(new Course{CourseId = 1, CourseName = "Asp.Net"});
            coursesClient.AddToCourse(new Course{CourseId = 2, CourseName = "Ado.Net"});
            coursesClient.AddToCourse(new Course{CourseId = 2, CourseName = "C#.Net" });

            GetCourses(coursesClient);

            Console.ReadKey();
        }

        private static void GetCourses(CoursesClient coursesClient)
        {
            Console.WriteLine();

            foreach (var course in coursesClient.ListCourse())
            {
                Console.WriteLine($"CourseId: {course.CourseId}, CourseName: {course.CourseName}");
            }

        }
    }
}
