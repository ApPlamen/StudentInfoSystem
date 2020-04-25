namespace University_frontend.Extensions
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    public static class HttpHelper
    {
        public static T GetContent<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<T>().Result;
            }
            else
            {
                throw new Exception("Cannot get data from service!" + response.IsSuccessStatusCode + " " + response.StatusCode);
            }
        }

        public static async Task<T> GetContentAsync<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else
            {
                throw new Exception("Cannot get data from service!" + response.IsSuccessStatusCode + " " + response.StatusCode);
            }
        }

        public static void CheckResponseSuccess(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannot get data from service!" + response.IsSuccessStatusCode + " " + response.StatusCode);
            }
        }

        public static ByteArrayContent CreateByteContent<T>(T model)
        {
            var content = JsonConvert.SerializeObject(model);
            var buffer = Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }
    }
}
