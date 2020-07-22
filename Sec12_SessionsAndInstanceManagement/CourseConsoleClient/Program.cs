using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CourseConsoleClient.ServiceReference1;

namespace CourseConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //var coursesClient = new CoursesClient("BasicHttpBinding_ICourses"); // Not support session
            var coursesClient = new CoursesClient("NetTcpBinding_ICourses"); //support session

            //coursesClient.AddToCourse(new Course{CourseId = 1, CourseName = "Asp.Net"});
            //coursesClient.AddToCourse(new Course{CourseId = 2, CourseName = "Ado.Net"});
            //coursesClient.AddToCourse(new Course{CourseId = 2, CourseName = "C#.Net" });
            //GetCourses(coursesClient);



            //Enumerable.Range(0, 3).ToList().ForEach(i =>
            //{
            //    Console.WriteLine($"Enter Record {i + 1}");
            //    coursesClient.AddToCourse(new Course(){CourseId = int.Parse(Console.ReadLine()), CourseName = Console.ReadLine()});
            //});
            //GetCourses(coursesClient);



            //coursesClient.AddToCourse(new Course { CourseId = 1, CourseName = "Asp.Net" });
            //coursesClient.AddToCourse(new Course { CourseId = 2, CourseName = "Ado.Net" });
            //coursesClient.AddToCourse(new Course { CourseId = 2, CourseName = "C#.Net" });

            //Thread.Sleep(5000);

            //GetCourses(coursesClient);



            coursesClient.AddToCourse(new Course { CourseId = 1, CourseName = "Asp.Net" });
            GetCourses(coursesClient);

            // 세션이 끝나면 객체를 새로 만들어줘야 한다.
            coursesClient = new CoursesClient("NetTcpBinding_ICourses"); //support session
            coursesClient.AddToCourse(new Course { CourseId = 1, CourseName = "Asp.Net" });
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
