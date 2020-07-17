using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulServiceLibrary
{
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
    }
}
