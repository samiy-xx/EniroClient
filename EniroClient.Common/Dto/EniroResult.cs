using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EniroClient.Common.Dto
{
    [DataContract]
    public class EniroResult
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "query")]
        public string Query { get; set; }

        [DataMember(Name = "totalHits")]
        public int TotalHits { get; set; }

        [DataMember(Name = "totalCount")]
        public int TotalCount { get; set; }

        [DataMember(Name = "startIndex")]
        public int StartIndex { get; set; }

        [DataMember(Name = "itemsPerPage")]
        public int ItemsPerPage { get; set; }

        [DataMember(Name = "adverts")]
        public List<EniroAdvert> Adverts { get; set; }

        public EniroResult()
        {
            Adverts = new List<EniroAdvert>();
        }
    }
}
