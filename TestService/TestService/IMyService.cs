using System.Collections.Generic;
using System.ServiceModel;

namespace TestService
{
    [ServiceContract]
    public interface IMyService // 서비스에는 [ServiceContract]를 붙여주고
    {
        [OperationContract]
        string GetData(); // 메서드에는 [OperationContract]를 붙여준다

        [OperationContract]
        string GetMessage(string name);

        [OperationContract]
        string GetResult(int sid, string sname, int m1, int m2, int m3); // 오버라이딩은 불가능하다. 

        [OperationContract]
        string GetStudentResult(Student student); // 클래스는 Serialize해주어야 한다.

        [OperationContract]
        int GetMax(int[] ar);

        [OperationContract]
        int[] GetSorted(int[] ar);


        [OperationContract]
        Student GetTopper(List<Student> students);

        [OperationContract]
        List<Country> GetAllCountries();
    }
}