using System.Dynamic;

namespace InterfaceLib.Database
{
    public enum QueryType
    {
        Create,
        Insert,
        Select,
        Update,
        Delete
    }

    public class Query
    {
        public QueryType Type { get; set; }
        public string Table { get; set; }
        public string Value { get; set; }
        public string[] Values
        {
            set => Value = string.Join(",", value);
        }
        public string Where { get; set; }
        public string Order { get; set; }

        // public int Limit { get; set; }

        public virtual string ToQuery { get; }
    }
}