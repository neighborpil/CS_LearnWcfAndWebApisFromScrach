using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MulServiceLibrary2
{
    public class MulService : INewMulService
    {
        public int MulInt(int a, int b)
        {
            return a * b;
        }


        public double MulDouble(double a, double b)
        {
            return a * b;
        }
    }

    //public class MulService : IMulService
    //{
    //    public int Mul(int a, int b)
    //    {
    //        return a * b;
    //    }


    //    public double Mul(double a, double b)
    //    {
    //        return a * b;
    //    }
    //}
}
