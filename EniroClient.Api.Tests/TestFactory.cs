using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EniroClient.Api.Tests
{
    public class TestFactory
    {
        public static SerializableTestObject GetTestObject()
        {
            return new SerializableTestObject {Something = "something"};
        }
    }

    [DataContract]
    public class SerializableTestObject
    {
        [DataMember(Name = "something")]
        public string Something { get; set; }
    }
}
