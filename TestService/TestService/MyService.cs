using MySql.Data.MySqlClient;
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
            string ip = "127.0.0.1";
            string port = "3306";
            string uid = "root";
            string password = "bkt8a9c0ak";
            string database = "wcf_test";
            string strConn = $"Server={ip};Port={port};Database={database};Uid={uid};Pwd={password};";
               
            MySqlConnection conn = new MySqlConnection(strConn);
            conn.Open();

            string quary = "select * from contries";
            MySqlCommand command = new MySqlCommand(quary, conn);
            MySqlDataReader reader = command.ExecuteReader();


            var contires = new List<Country>();
            while (reader.Read())
            {
                contires.Add(new Country(reader["id"].ToString(), reader["name"].ToString()));
            }
            conn.Close(); // 사용이 끝나면 닫아주자.
            return contires;
        }
    }
}