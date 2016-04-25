using System.Runtime.Serialization;

namespace EniroClient.Common.Dto
{
    [DataContract]
    public class EniroPhoneNumber
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }

        [DataMember(Name = "label")]
        public string Label { get; set; }
    }
}