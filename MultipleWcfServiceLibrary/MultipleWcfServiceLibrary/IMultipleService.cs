using System.ServiceModel;

namespace MultipleWcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMultipleService" in both code and config file together.
    [ServiceContract]
    public interface IMultipleService
    {
        [OperationContract]
        int Multiple(int a, int b);

    }
}
