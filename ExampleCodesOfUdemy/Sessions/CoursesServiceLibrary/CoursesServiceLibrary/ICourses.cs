using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CoursesServiceLibrary
{
    [DataContract]
    public class Course
    {
        [DataMember]
        public int CourseId { get; set; }
        [DataMember]
        public string CourseName { get; set; }
    }

    [ServiceContract(SessionMode=SessionMode.Required)]
    public interface ICourses
    {
        [OperationContract(IsInitiating=true)]
        void AddToCourses(Course course);

        [OperationContract(IsTerminating=true)]
        List<Course> ListCourses();
    }


}
