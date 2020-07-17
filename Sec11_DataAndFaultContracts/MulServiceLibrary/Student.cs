using System.Runtime.Serialization;

namespace MulServiceLibrary
{
    [DataContract]
    public class Student
    {
        // 기본 자료형의 경우 [DataMember]을 삭제하여도 정상적으로 직렬화가 일어난다
        [DataMember]
        public int StudentId { get; set; }

        [DataMember]
        public string StudentName { get; set; }

        public Student(int studentId, string studentName)
        {
            StudentId = studentId;
            StudentName = studentName;
        }

        public override string ToString()
        {
            return $"StudentId: {StudentId}, StudentName: {StudentName}";
        }
    }
}