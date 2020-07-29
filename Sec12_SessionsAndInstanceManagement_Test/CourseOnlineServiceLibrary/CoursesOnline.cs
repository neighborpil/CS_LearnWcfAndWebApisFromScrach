using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.ServiceModel;

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
        }


        public List<Course> ListCourses()
        {
            courses = new List<Course>();

            using (var connection = new SQLiteConnection(_dbFile))
            {

                try
                {
                    connection.Open();

                    string sql = string.Empty;
                    sql = $"select * from course";
                    var command = new SQLiteCommand(sql, connection);
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var courseId = Convert.ToInt32(dataReader["course_id"]);
                        var courseName = dataReader["course_name"].ToString();
                        var coursePrice = Convert.ToDouble(dataReader["course_price"]);
                        var course = new Course(courseId, courseName, coursePrice);
                        courses.Add(course);
                    }

                    return courses;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return null;
        }

        public void EmptyCoursesTaken()
        {
            try
            {
                coursesTaken = new List<CourseTaken>();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public void AddToCoursesTaken(CourseTaken courseTaken)
        {
            try
            {
                coursesTaken.Add(courseTaken);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public List<CourseTaken> ListCoursesTaken()
        {
            try
            {
                return coursesTaken;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}