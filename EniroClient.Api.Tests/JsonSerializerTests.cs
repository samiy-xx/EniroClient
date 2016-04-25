using NUnit.Framework;

namespace EniroClient.Api.Tests
{
    [TestFixture]
    public class JsonSerializerTests
    {
        [Test]
        public void SerializerSerializes()
        {
            var o = TestFactory.GetTestObject();
            var r = JsonSerializer.Serialize(o);
            Assert.IsNotNullOrEmpty(r);
            Assert.IsInstanceOf<string>(r);
            Assert.IsTrue(r.Contains("something"));
        }

        [Test]
        public void SerializerDeserializes()
        {
            const string s = "{\"something\":\"something\"}";
            var o = JsonSerializer.Deserialize<SerializableTestObject>(s);
            Assert.IsNotNull(o);
            Assert.IsInstanceOf<SerializableTestObject>(o);
            Assert.AreEqual("something", o.Something);
        }
    }
}
