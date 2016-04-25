using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EniroClient.Common.Dto
{
    [DataContract]
    public class EniroAdvert
    {
        [DataMember(Name = "eniroId", IsRequired = false)]
        public int EniroId { get; set; }
        
        [DataMember(Name = "companyInfo")]
        public EniroCompanyInfo CompanyInfo { get; set; }

        [DataMember(Name = "address")]
        public EniroAddress Address { get; set; }

        [DataMember(Name = "location")]
        public EniroLocation Location { get; set; }

        [DataMember(Name = "phoneNumbers")]
        public List<EniroPhoneNumber> PhoneNumbers { get; set; }

        [DataMember(Name = "homepage")]
        public string Homepage { get; set; }

        [DataMember(Name = "facebook")]
        public string Facebook { get; set; }

        [DataMember(Name = "companyReview")]
        public string CompanyReview { get; set; }

        [DataMember(Name = "infoPageLink")]
        public string InfoPageLink { get; set; }

        public EniroAdvert()
        {
            PhoneNumbers = new List<EniroPhoneNumber>();
        }
    }
}