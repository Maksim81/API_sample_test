using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Diagnostics;
using System.Net;
using System.IO;
using System;


namespace CatenaDB
{
    public class CreateSignature
    {        
        [SetUp]

        [Test, Description ("Create signature")]

        public async System.Threading.Tasks.Task CreateSimpleSignature(HttpClient client)
        {

                //var client = new HttpClient();
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("Name", "Grace Hopper"));
                postData.Add(new KeyValuePair<string, string>("request", "{\"dataHash\": {\"algorithm\": \"SHA-256\",\"value\": \"GHgonhozPdhQkdMPABufb57U1CjVfgSb0OvU28ib0hA=\"  },  \"level\": 0,  \"metadata\": { }        }"));

                var formContent = new FormUrlEncodedContent(postData);
                string requestContent = await formContent.ReadAsStringAsync();
                var response = await client.PostAsync("https://tryout-catena-db.guardtime.net/api/v1/signatures", formContent);
                var content = await response.Content.ReadAsStringAsync();
                Assert.That(response.IsSuccessStatusCode);
                Debug.WriteLine(message: "Request:" + requestContent);
                Debug.WriteLine(message: "Response:" + content.ToString());

        }
        [Test, Description("Creating the new asynsronous signature")]
        public async System.Threading.Tasks.Task CreateAsynchronousSignature()
        {

            var client = new HttpClient();
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("Name", "Grace Hopper"));
            postData.Add(new KeyValuePair<string, string>("request", "{\"dataHash\": {\"algorithm\": \"SHA-256\",\"value\": \"GHgonhozPdhQkdMPABufb57U1CjVfgSb0OvU28ib0hA=\"  },  \"level\": 0,  \"metadata\": { }        }"));

            var formContent = new FormUrlEncodedContent(postData);
            string requestContent = await formContent.ReadAsStringAsync();
            var response = await client.PostAsync("https://tryout-catena-db.guardtime.net/api/v1/signatures", formContent);
            var content = await response.Content.ReadAsStringAsync();
            Assert.That(response.IsSuccessStatusCode);
            Debug.WriteLine(message: "Request:" + requestContent);
            Debug.WriteLine(message: "Response:" + content.ToString());

        }


    }
    public class ReadSignature
    {
        [SetUp]
        public void SetupTest()
        {

        }
        [Test, Description("Create signature")]

        public void GetExistingSignatureDetails()
        {
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            string html = string.Empty;
            string url = "https://tryout-catena-db.guardtime.net/api/v1/signatures?ids=e3f33734-09e5-4d32-b48c-658f2ade6336";

            Stream data = client.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();
            Debug.WriteLine(message: "Response:" + s.ToString());
        }

        public void GetNotExistingSignatureDetails()
        {
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            string html = string.Empty;
            string url = "https://tryout-catena-db.guardtime.net/api/v1/signatures?ids=e3f33734-09e5-4d32-b48c-658f2ade6336";

            Stream data = client.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();
            Debug.WriteLine(message: "Response:" + s.ToString());
            Assert.That(s.ToString().Length>0);
        }

        [TearDown]
        public void TearDown()
        {

        }

        
        }

    public class ExtendSignature
    {
        [SetUp]
        public void SetupTest()
        {

        }
        [Test, Description("TC-003 Assigning unique ID to generated signature ")]

        public async System.Threading.Tasks.Task ExistingSignaturPersistence()
        {
            var client = new HttpClient();
            var putData = new List<KeyValuePair<string, string>>();
            client.BaseAddress = new Uri("https://tryout-catena-db.guardtime.net/api/v1/signatures");
            var formContent = new FormUrlEncodedContent(putData);
            string requestContent = await formContent.ReadAsStringAsync();
            var response = client.PutAsync("api/person", formContent).Result;
            Assert.That(response.IsSuccessStatusCode);
        }
        [Test, Description("TC-004 Assigning unique ID to generated signature (V2)")]
        public async System.Threading.Tasks.Task ExistingSignaturPersistenceV2()
        {
            var client = new HttpClient();
            var putData = new List<KeyValuePair<string, string>>();
            client.BaseAddress = new Uri("https://tryout-catena-db.guardtime.net/api/v2/signatures");
            var formContent = new FormUrlEncodedContent(putData);
            string requestContent = await formContent.ReadAsStringAsync();
            var response = client.PutAsync("api/person", formContent).Result;
            Assert.That(response.IsSuccessStatusCode);
        }

        [TearDown]
        public void TearDown()
        {

        }

    }
    }
