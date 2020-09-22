using NUnit.Framework;

namespace SqliteControllerTest
{
    [TestFixture]
    public class SqliteHelperTest
    {
        //[Test]
        //public void ExecuteReader_RunSelectQuery_ReturnDataTable()
        //{


        //    var helper = new SqliteHelper();
        //    helper.ExecuteReader()
        //}

        [Test]
        public void Test()
        {
            string names = string.Empty;
            var result = string.Join(", ", names);

            Assert.That(result, Is.EqualTo(string.Empty));
        }
    }
}