using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MEPInWCFLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract=typeof(IMEPCallBack))]
    public interface IMEP
    {
        [OperationContract(IsOneWay = true)]
        void SendEmail(string toAddress);

        // TODO: Add your service operations here
    }

    public interface IMEPCallBack
    {
        [OperationContract(IsOneWay = true)]
        void SendEmailCallBack(string toAddress);
    }
}
