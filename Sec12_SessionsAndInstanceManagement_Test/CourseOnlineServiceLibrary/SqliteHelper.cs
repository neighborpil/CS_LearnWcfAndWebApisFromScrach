using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace CourseOnlineServiceLibrary
{
    public class SqliteHelper
    {
        private readonly string _dbFile = Path.Combine(Environment.CurrentDirectory, "CoursesOnline.db");


        public SqliteHelper()
        {
        }

        public void CreateTable()
        {
            bool isCreated = false;

            using (var connection = new SQLiteConnection($"Data Source={_dbFile}"))
            {
                try
                {
                    connection.Open();
                    //var sql = "drop table course";
                    var sql =
                        "create table course(course_id integer primary key autoincrement, course_name text, course_price real)";
                    var command = new SQLiteCommand(sql, connection);
                    command.ExecuteNonQuery();

                    isCreated = true;

                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            if (isCreated)
            {
                InsertData("C#.Net", 1000.0);
                InsertData("Asp.Net", 2000.0);
                InsertData("Ado.Net", 3000.0);
                InsertData("SqlServer", 4000.0);
                InsertData("MVC", 5000.0);
                InsertData("EF", 6000.0);
                InsertData("WCF", 7000.0);
            }
        }


        public void InsertData(string courseName, double coursePrice)
        {
            using (var connection = new SQLiteConnection($"Data Source={_dbFile}"))
            {

                try
                {
                    connection.Open();

                    var sql =
                        $"insert into course (course_name, course_price) values('{courseName}', {coursePrice})";
                    var command = new SQLiteCommand(sql, connection);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public List<Course> SelectData(int id = 0)
        {
            List<Course> courses = new List<Course>();
            using (var connection = new SQLiteConnection($"Data Source={_dbFile}"))
            {

                try
                {
                    connection.Open();

                    string sql = string.Empty;
                    if (id == 0)
                    {
                        sql = "select * from course";
                    }
                    else
                    {
                        sql =
                            $"select * from course where course_id = {id}";
                    }
                    var command = new SQLiteCommand(sql, connection);
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var courseId = Convert.ToInt32(dataReader["course_id"]);
                        var courseName = dataReader["course_name"].ToString();
                        var coursePrice = Convert.ToDouble(dataReader["course_price"]);
                        var course = new Course(courseId, courseName, coursePrice);
                        courses.Add(course);
                        Console.WriteLine($"CourseId: {dataReader["course_id"]}, CourseName: {dataReader["course_name"]}, CoursePrice: {dataReader["course_price"]}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return courses;
        }
    }
}