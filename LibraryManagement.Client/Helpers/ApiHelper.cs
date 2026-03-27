using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace LibraryManagement.Client.Helpers
{
    public static class ApiHelper
    {
        public static string BaseUrl = "http://localhost:59137/LibraryService.svc";

        public static T Get<T>(string endpoint)
        {
            var request = (HttpWebRequest)WebRequest.Create(BaseUrl + endpoint);
            request.Method = "GET";
            request.ContentType = "application/json";

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        public static T Post<T>(string endpoint, object data)
        {
            var request = (HttpWebRequest)WebRequest.Create(BaseUrl + endpoint);
            request.Method = "POST";
            request.ContentType = "application/json";

            string json = JsonConvert.SerializeObject(data);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            using (var stream = request.GetRequestStream())
            {
                stream.Write(byteArray, 0, byteArray.Length);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        public static T Put<T>(string endpoint, object data)
        {
            var request = (HttpWebRequest)WebRequest.Create(BaseUrl + endpoint);
            request.Method = "PUT";
            request.ContentType = "application/json";

            string json = JsonConvert.SerializeObject(data);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            using (var stream = request.GetRequestStream())
            {
                stream.Write(byteArray, 0, byteArray.Length);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        public static T Delete<T>(string endpoint)
        {
            var request = (HttpWebRequest)WebRequest.Create(BaseUrl + endpoint);
            request.Method = "DELETE";
            request.ContentType = "application/json";

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(result);
            }
        }
    }
}