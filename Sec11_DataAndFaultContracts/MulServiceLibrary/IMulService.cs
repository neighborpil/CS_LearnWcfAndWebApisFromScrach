using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MulServiceLibrary
{
    [ServiceContract]
    public interface IMulService
    {
        [OperationContract]
        int MulInt(int a, int b);

        [OperationContract]
        void Save(Student student);
    }
}
