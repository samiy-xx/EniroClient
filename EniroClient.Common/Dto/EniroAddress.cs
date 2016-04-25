using System.Runtime.Serialization;

namespace EniroClient.Common.Dto
{
    [DataContract]
    public class EniroAddress
    {
        [DataMember(Name = "coName")]
        public string CoName { get; set; }

        [DataMember(Name = "streetName")]
        public string StreetName { get; set; }

        [DataMember(Name = "postCode")]
        public string PostCode { get; set; }

        [DataMember(Name = "postArea")]
        public string PostArea { get; set; }

        [DataMember(Name = "postBox")]
        public string PostBox { get; set; }
    }
}