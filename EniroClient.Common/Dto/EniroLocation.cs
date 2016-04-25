using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EniroClient.Common.Dto
{
    [DataContract]
    public class EniroLocation
    {
        [DataMember(Name = "coordinates")]
        public List<EniroCoordinates> Coordinates { get; set; }

        public EniroLocation()
        {
            Coordinates = new List<EniroCoordinates>();
        }
    }
}