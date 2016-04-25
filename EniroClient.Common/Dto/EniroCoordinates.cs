using System.Runtime.Serialization;

namespace EniroClient.Common.Dto
{
    [DataContract]
    public class EniroCoordinates
    {
        [DataMember(Name = "use")]
        public string Use { get; set; }

        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }

        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }
    }
}