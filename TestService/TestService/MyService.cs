using System;
using System.Collections.Generic;
using System.Linq;

namespace TestService
{
    public class MyService : IMyService
    {
        public string GetData()
        {
            return "www.google.com";
        }

        public string GetMessage(string name)
        {

            return $"Hello Mr./Ms {name}";
        }

        public string GetResult(int sid, string sname, int m1, int m2, int m3)
        {
            double average = (m1 + m2 + m3) / 3.0;
            if (average < 35)
            {
                return "Fail";
            }
            else
            {
                return "Pass";
            }
        }

        public string GetStudentResult(Student student)
        {
            double average = (student.Num1 + student.Num2 + student.Num3) / 3.0;
            if (average < 35)
            {
                return "Fail";
            }
            else
            {
                return "Pass";
            }
        }

        public int GetMax(int[] ar)
        {
            return ar.Max();
        }

        public int[] GetSorted(int[] ar)
        {
            Array.Sort(ar);
            return ar;
        }

        public Student GetTopper(List<Student> students)
        {
            return students.Aggregate(students.First(), (current, next) => next.Num1 > current.Num1 ? next : current);
        }

        public List<Country> GetAllCountries()
        {
            
            // db땡겨오는거 가능하다
            return null;
        }
    }
}