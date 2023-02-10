
using System;
using System.Data;
using InterfaceLib.Database;
using SqliteLib;

namespace MessageExchangePatternInWcfLibrary
{
    public class CreateUserRegistrationDB
    {

        private readonly string _dbFile;

        public CreateUserRegistrationDB(string dbFile)
        {
            _dbFile = dbFile;
        }

        public void CreateDB()
        {
            var query = new SqliteQuery();
            query.Type = QueryType.Create;
            query.Table = "user_registration";
            query.Value =
                "user_id integer primary key autoincrement, user_email text, email_sent_flag text default 'y'";

            using (var database = new Sqlite(_dbFile))
            {
                database.SetData(query);
            }
        }
    }
}