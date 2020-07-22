using System.Collections.Generic;

namespace CourseServiceLibrary
{
    public class Courses : ICourses
    {
        private List<Course> _courses;

        public Courses()
        {
            _courses = new List<Course>();
        }

        public void AddToCourse(Course course)
        {
            _courses.Add(course);
        }

        public List<Course> ListCourse()
        {
            return _courses;
        }
    }
}