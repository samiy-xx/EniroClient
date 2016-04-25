using System.Runtime.Serialization;

namespace EniroClient.Common.Dto
{
    [DataContract]
    public class EniroCompanyInfo
    {
        [DataMember(Name = "companyName")]
        public string CompanyName { get; set; }

        [DataMember(Name = "orgNumber", IsRequired = false, EmitDefaultValue = false)]
        public long? OrgNumber { get; set; }

        [DataMember(Name = "companyText")]
        public string CompanyText { get; set; }
    }
}