using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CoursesServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
    public class Courses : ICourses
    {
        private List<Course> courses;

        public Courses()
        {
            courses = new List<Course>();
        }

        public void AddToCourses(Course course)
        {
            courses.Add(course);
        }

        public List<Course> ListCourses()
        {
            return courses;
        }
    }
}
