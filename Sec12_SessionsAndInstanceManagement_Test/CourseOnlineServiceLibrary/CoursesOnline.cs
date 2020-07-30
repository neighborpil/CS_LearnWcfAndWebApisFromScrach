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

        private readonly SqliteHelper _sqliteHelper;

        public CoursesOnline()
        {
            _sqliteHelper = new SqliteHelper();

        }


        public List<Course> ListCourses()
        {
            return _sqliteHelper.SelectData();
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