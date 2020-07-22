using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MulServiceLibrary
{
    [DataContract]
    public class DivFault
    {
        /// <summary>
        /// EndUser에게 보여줄 메시지
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// 로깅을 하기위한 메시지
        /// </summary>
        [DataMember]
        public string OperationMessage { get; set; }
    }

    [ServiceContract]
    public interface IMulService
    {
        [OperationContract]
        int MulInt(int a, int b);

        [OperationContract]
        void Save(Student student);

        [OperationContract]
        int DivInt(int a, int b);

        [OperationContract]
        [FaultContract(typeof(DivFault))]
        int DivInt2(int a, int b);
    }
}
