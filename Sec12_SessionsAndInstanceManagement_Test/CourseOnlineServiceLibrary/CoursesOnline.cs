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
        //private readonly string _dbFile = Path.Combine(Environment.CurrentDirectory, "CoursesOnline.sqlite");

        private Course course = null;
        private List<Course> courses = null;
        private List<CourseTaken> coursesTaken = null;

        public CoursesOnline()
        {
            //CreateTable();
        }


        public void CreateTable()
        {
            using (var connection = new SQLiteConnection($"Data Source={$"D:\test.sqlite"}"))
            {

                try
                {
                    connection.Open();

                    var sql =
                        "create table course(course_id int primary key auto_increment, course_name varchar(50), course_price double)";
                    var command = new SQLiteCommand(sql, connection);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        //public void CreateTable()
        //{
        //    var dbFile = new FileInfo(_dbFile);
        //    if (!dbFile.Exists)
        //    {
        //        try
        //        {
        //            using (var connection = new SQLiteConnection(_dbFile))
        //            {
        //                string query =
        //                    "create table course(course_id int primary key auto_increment, course_name varchar(50), course_price double)";

        //                var result = connection.CreateTable<Course>();
        //                if(result == CreateTableResult.Created)
        //                {

        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //}


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