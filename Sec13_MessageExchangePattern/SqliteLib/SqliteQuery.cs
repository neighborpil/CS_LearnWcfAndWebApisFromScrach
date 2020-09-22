using System;
using System.Collections.Generic;
using InterfaceLib.Database;

namespace SqliteLib
{
    public class SqliteQuery : Query
    {
        public override string ToQuery
        {
            get
            {
                string result = string.Empty;

                if (!string.IsNullOrWhiteSpace(this.Value))
                {
                    this.Value = this.Value.Replace("{", string.Empty);
                    this.Value = this.Value.Replace("}", string.Empty);
                }

                switch (this.Type)
                {
                    case QueryType.Create:
                        result = $"CREATE TABLE IF NOT EXISTS {this.Table} ({this.Value})";
                        break;
                    case QueryType.Select:
                        result = $"SELECT {this.Value} FROM {this.Table}";
                        if (!string.IsNullOrWhiteSpace(this.Where))
                            result += $" WHERE {this.Where}";
                        if (!string.IsNullOrWhiteSpace(this.Order))
                            result += $" ORDER BY {this.Order}";
                        break;
                    case QueryType.Insert:
                        var pair = SplitNameValuePair(this.Value);

                        result = $"INSERT INTO {this.Table} ({pair.Item1}) VALUES ({pair.Item2})";
                        break;
                    case QueryType.Update:
                        result = $"UPDATE {this.Table} SET {this.Value} WHERE {this.Where}";
                        break;
                    case QueryType.Delete:
                        result = $"DELETE FROM {this.Table} WHERE {this.Value}";
                        break;
                }

                return result;
            }
        }


        /// <summary>
        /// 입력 항목을 이름/값으로 분리
        /// </summary>
        /// <param name="rawValue">원본</param>
        /// <returns>분리된 문자열</returns>
        private static Tuple<string, string> SplitNameValuePair(string rawValue)
        {
            var pairs = rawValue.Split(',');

            var names = new List<string>();
            var values = new List<string>();
            try
            {
                foreach (var pair in pairs)
                {
                    var split = pair.Split('=');
                    names.Add(split[0].Trim());
                    values.Add(split[1].Trim());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return Tuple.Create(string.Join(", ", names), string.Join(", ", values));
        }
    }
}