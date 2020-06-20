using System.Runtime.Serialization;

namespace TestService
{
    [DataContract]
    public class Country
    {
        [DataMember]
        public string CountryId { get; set; }
        [DataMember]
        public string CountryName { get; set; }

        public Country(string countryId, string countryName)
        {
            CountryId = countryId;
            CountryName = countryName;
        }
    }
}