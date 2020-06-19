using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TestService
{
    // 클래스를 파라미터로 넘기려면 Serialize 해야한다.
    [DataContract]
    public class Student // 클래스명에는 [DataContract]를 붙이고
    {
        [DataMember]
        public int Id { get; set; } // 각각의 변수 명에는 [DataMember]를 붙인다.
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Num1 { get; set; }
        [DataMember]
        public int Num2 { get; set; }
        [DataMember]
        public int Num3 { get; set; }

        //[CollectionDataContract]
        //public List<string> Messages { get; set; } = new List<string>();
    }
}