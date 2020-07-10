using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulServiceLibrary2
{
    public class MulService : IMulService
    {
        public int Mul(int a, int b)
        {
            return a * b;
        }

        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
