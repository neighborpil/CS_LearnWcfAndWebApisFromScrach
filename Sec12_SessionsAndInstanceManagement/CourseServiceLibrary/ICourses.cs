using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace CourseServiceLibrary
{
    [DataContract]
    public class Course
    {
        [DataMember]
        public int CourseId { get; set; }

        [DataMember]
        public string CourseName { get; set; }
    }

    [ServiceContract]
    public interface ICourses
    {
        [OperationContract]
        void AddToCourse(Course course);

        [OperationContract]
        List<Course> ListCourse();
    }
}