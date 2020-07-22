using System.Collections.Generic;
using System.ServiceModel;

namespace CourseServiceLibrary
{
    /*
    // client로부터 call이 올 때마다 WCF 인스턴스를 만들기 때문에 이전 콜에서 만들어진 데이터 사용이 불가능하다.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    
    // client로부터 call이 오면 각 클라이언트에 대한 WCF 인스턴스를 만들기 때문에 이전 콜에서 만들어진 데이터 사용이 가능하다.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]

    // 오직 하나의 WCF 인스턴스를 만들기 때문에 어떠한 클라이언트에서 콜이 오더라도 데이터가 저장되며 사용이 가능하다. 글로벌 오브젝트로 보면 된다
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]

    */

    // client로부터 call이 오면 각 클라이언트에 대한 WCF 인스턴스를 만들기 때문에 이전 콜에서 만들어진 데이터 사용이 가능하다.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
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