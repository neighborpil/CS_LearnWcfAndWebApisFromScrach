using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using InterfaceLib.Database;

namespace SqliteLib
{
    public class Sqlite : IDatabase
    {
        private readonly string _dbFile;

        private SQLiteConnection _connection;

        private SQLiteTransaction _transaction;

        public Sqlite(string fileName)
        {
            _dbFile = Path.Combine(Environment.CurrentDirectory, fileName);
            _connection = new SQLiteConnection($"Data Source={_dbFile}");
        }

        /// <summary>
        /// 조회
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable GetData(Query query)
        {
            DataTable result = null;
            using (var adapter = new SQLiteDataAdapter(query.ToQuery, _connection))
            {
                try
                {
                    _connection.Open();

                    var dataSet = new DataSet();
                    adapter.Fill(dataSet, "result");
                    _connection.Close();

                    result = dataSet.Tables["result"];

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }

        public long SetData(Query query, bool needLastInsertedId = false)
        {
            long inserted = 0;
            using (var command = new SQLiteCommand(query.ToQuery, _connection))
            {
                try
                {
                    _connection.Open();

                    if (needLastInsertedId)
                    {
                        inserted = (long)command.ExecuteScalar();
                    }
                    else
                    {
                        inserted = command.ExecuteNonQuery();
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return inserted;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _connection.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
    }
}