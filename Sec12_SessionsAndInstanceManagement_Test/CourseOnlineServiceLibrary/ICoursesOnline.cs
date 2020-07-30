using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace CourseOnlineServiceLibrary
{
    [DataContract]
    public class Course
    {
        [DataMember]
        public int CourseId { get; set; }

        [DataMember]
        public string CourseName { get; set; }

        [DataMember]
        public double CoursePrice { get; set; }


        public Course(int courseId, string courseName, double coursePrice)
        {
            CourseId = courseId;
            CourseName = courseName;
            CoursePrice = coursePrice;
        }
    }

    [DataContract]
    public class CourseTaken
    {
        [DataMember]
        public int CourseId { get; set; }

        [DataMember]
        public string CourseName { get; set; }

        [DataMember]
        public double CoursePrice { get; set; }
    }

    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ICoursesOnline
    {
        [OperationContract]
        List<Course> ListCourses();

        [OperationContract(IsInitiating = true)]
        void EmptyCoursesTaken();

        [OperationContract]
        void AddToCoursesTaken(CourseTaken courseTaken);

        [OperationContract(IsTerminating = true)]
        List<CourseTaken> ListCoursesTaken();
    }
}