using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics.Eventing.Reader;
using System.IO;

namespace CourseOnlineServiceLibrary
{
    public class CoursesOnline : ICoursesOnline
    {
        private readonly string _dbFile = Path.Combine(Environment.CurrentDirectory, "CoursesOnline.db");

        private Course course = null;
        private List<Course> courses = null;
        private List<CourseTaken> coursesTaken = null;

        public CoursesOnline()
        {
            //CreateTable();
        }


        public void CreateTable()
        {
            using (var connection = new SQLiteConnection($"Data Source={_dbFile}"))
            {

                try
                {
                    connection.Open();

                    var sql =
                        "create table if not exists course(course_id integer primary key , course_name text, course_price real)";
                    var command = new SQLiteCommand(sql, connection);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        public void InsertData(int courseId, string courseName, double coursePrice)
        {
            using (var connection = new SQLiteConnection($"Data Source={_dbFile}"))
            {

                try
                {
                    connection.Open();

                    var sql =
                        $"Insert into course values({courseId}, '{courseName}', {coursePrice}";
                    var command = new SQLiteCommand(sql, connection);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public List<Course> ListCourses()
        {
            //course = new List<Course>();

            //try
            //{
            //    using (var connection = new SQLiteConnection(_dbFile))
            //    {

            //    }
            //}
            return null;
        }

        public void EmptyCoursesTaken()
        {
            throw new System.NotImplementedException();
        }

        public void AddToCoursesTaken(CourseTaken courseTaken)
        {
            throw new System.NotImplementedException();
        }

        public List<CourseTaken> ListCoursesTaken()
        {
            throw new System.NotImplementedException();
        }
    }
}