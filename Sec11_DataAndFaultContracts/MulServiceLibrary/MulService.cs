using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MulServiceLibrary
{
    // [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class MulService : IMulService
    {
        public int MulInt(int a, int b)
        {
            return a * b;
        }

        public void Save(Student student)
        {
            Console.WriteLine(student);
        }

        public int DivInt(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (Exception ex)
            {
                // 출시 이후에는 전체 Exception을 보여주지 않는다.
                // 하지만 개별적인 예외는 FaultException을 발생시킴으로써 보여줄 수 있다.
                throw new FaultException("The second parameter cannot be zero");
            }
        }

        public int DivInt2(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (Exception ex)
            {
                var divFault = new DivFault();
                divFault.Message = "The second parameter cannot be zero";
                divFault.OperationMessage = ex.Message;

                throw new FaultException<DivFault>(divFault, "The second parameter cannot be zero");
            }
        }
    }
}
