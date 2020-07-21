using System.Runtime.Serialization;

namespace MulServiceLibrary
{
    [DataContract]
    public class Student
    {
        // 만약 특정 변수만 Service에서 표시하고 싶다면 [DataContract]와 [DataMember]를 특정 항목에만 표시하면 된다.
        //[DataMember(Name = "Sid")]
        [DataMember]
        public int StudentId { get; set; }

        // IsRequired가 붙으면 클라이언트에서 데이터를 넘기든지 안 넘기든지 필요함(Contract를 갱신하지 않으면 예외발생)
        [DataMember(IsRequired = true)]
        public string StudentName { get; set; }

        public string StudentContent { get; set; }

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