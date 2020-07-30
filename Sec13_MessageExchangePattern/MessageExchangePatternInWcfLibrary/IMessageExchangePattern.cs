using System.ServiceModel;

namespace MessageExchangePatternInWcfLibrary
{
    [ServiceContract]
    public interface IMessageExchangePattern
    {
        [OperationContract]
        void SendEmail(string toAddress);
    }
}