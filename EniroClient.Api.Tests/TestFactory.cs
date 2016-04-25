using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using EniroClient.Common.Dto;

namespace EniroClient.Api.Tests
{
    public class TestFactory
    {
        public static SerializableTestObject GetTestObject()
        {
            return new SerializableTestObject {Something = "something"};
        }

        public static HttpResponseMessage GenOkResponseMessage()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(CreateEniroResponse()))
            };
        }

        public static HttpResponseMessage GenNotFoundResponseMessage()
        {
            return new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("content")
            };
        }

        public static EniroResult CreateEniroResponse()
        {
            return new EniroResult
            {
                ItemsPerPage = 1,
                Query = "",
                StartIndex = 0,
                Title = "title",
                TotalCount = 1,
                Adverts = new List<EniroAdvert>
                {
                    new EniroAdvert
                    {
                        Facebook = "",
                        CompanyReview = "",
                        EniroId = 1,
                        Homepage = "",
                        InfoPageLink = "",
                        Address = new EniroAddress
                        {
                            CoName = "Test As",
                            PostArea = "TestTown",
                            PostBox = "PO 123",
                            PostCode = "0666",
                            StreetName = "Test Street"
                        },
                        CompanyInfo = new EniroCompanyInfo
                        {
                            CompanyName = "Test As",
                            CompanyText = "",
                            OrgNumber = 1
                        },
                        Location = new EniroLocation
                        {
                            Coordinates = new List<EniroCoordinates>
                            {
                                new EniroCoordinates
                                {
                                    Latitude = 1,
                                    Longitude = 1,
                                    Use = "test"
                                }
                            }
                        },
                        PhoneNumbers = new List<EniroPhoneNumber>
                        {
                            new EniroPhoneNumber
                            {
                                Label = "test",
                                PhoneNumber = "12345678",
                                Type = "test"
                            }
                        }
                    }
                }
            };
        }
    }

    [DataContract]
    public class SerializableTestObject
    {
        [DataMember(Name = "something")]
        public string Something { get; set; }
    }
}
