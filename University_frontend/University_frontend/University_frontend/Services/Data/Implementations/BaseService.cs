namespace University_frontend.Services.DataServices
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class BaseService
    {
        protected HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("http://10.0.2.2:5001/api/"),
        };

        protected async Task<HttpResponseMessage> GetAsync(string path)
        {
            this.AddAuthorization();
            HttpResponseMessage response = await this.client.GetAsync(path);
            this.CheckResponseAsync(response);
            return response;
        }

        protected async Task<HttpResponseMessage> PostAsync(string path, ByteArrayContent content)
        {
            this.AddAuthorization();
            HttpResponseMessage response = await this.client.PostAsync(path, content);
            this.CheckResponseAsync(response);
            return response;
        }

        protected async Task<HttpResponseMessage> DeleteAsync(string path)
        {
            this.AddAuthorization();
            HttpResponseMessage response = await this.client.DeleteAsync(path);
            this.CheckResponseAsync(response);
            return response;
        }

        private void AddAuthorization()
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccountService.Credentials.AccessToken);
        }

        private void CheckResponseAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode) throw new Exception();
        }
    }
}
