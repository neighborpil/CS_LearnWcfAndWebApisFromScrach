using SqliteController;

namespace MessageExchangePatternInWcfClient
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
            var helper = new SqliteHelper(_dbFile);

            var query =
                "create table if not exists user_registration(user_id integer primary key autoincrement, user_email text, email_sent_flag text default 'y')";
            helper.ExecuteNonQuery(query);

        }
    }
}