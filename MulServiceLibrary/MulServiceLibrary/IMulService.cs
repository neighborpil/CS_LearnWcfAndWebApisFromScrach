using System.ServiceModel;

namespace MulServiceLibrary
{
    [ServiceContract]
    public interface IMulService
    {
        [OperationContract]
        int Mul(int a, int b);
    }
}