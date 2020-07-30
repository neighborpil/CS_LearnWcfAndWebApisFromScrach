using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace SqliteController
{
    public class SqliteHelper
    {
        private readonly string _dbFile;


        public SqliteHelper(string fileName)
        {
            _dbFile = Path.Combine(Environment.CurrentDirectory, fileName);
        }

        /// <summary>
        /// 조회
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable ExecuteReader(string query)
        {
            DataTable returned = null;
            using (var connection = new SQLiteConnection($"Data Source={_dbFile}"))
            {
                using (var command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        var dataReader = command.ExecuteReader();
                        returned = dataReader.GetSchemaTable();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                
            }
            return returned;
        }

        /// <summary>
        /// 삽입 또는 업데이트
        /// </summary>
        /// <param name="query"></param>
        /// <param name="lastInsertedId"></param>
        /// <returns></returns>
        public long ExecuteNonQuery(string query)
        {
            long inserted = 0;
            using (var connection = new SQLiteConnection($"Data Source={_dbFile}"))
            {
                using (var command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        inserted = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return inserted;
        }
    }
}