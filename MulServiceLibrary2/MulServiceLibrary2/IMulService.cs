using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MulServiceLibrary2
{
    [ServiceContract(Name="MultiplicationService")]
    public interface IMulService
    {
        // Name을 쓰는 이유는 오버로딩에서 유용하기 때문
        [OperationContract(Name="Multiply")]
        int Mul(int a, int b);
    }
}
