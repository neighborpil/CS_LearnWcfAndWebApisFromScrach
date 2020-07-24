using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseOnlineServiceLibrary;

namespace CoursesOnlineSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var online = new CoursesOnline();
            online.CreateTable();
        }

    }
}
