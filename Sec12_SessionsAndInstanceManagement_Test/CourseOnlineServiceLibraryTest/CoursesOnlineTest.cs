using CourseOnlineServiceLibrary;
using NUnit.Framework;

namespace CourseOnlineServiceLibraryTest
{
    [TestFixture]
    public class CoursesOnlineTest
    {
        [Test]
        public void CreateTable_JustRun_CreateSqlite3DbFile()
        {
            var coursesOnline = new CoursesOnline();
            coursesOnline.CreateTable();
        }
    }
}