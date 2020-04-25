namespace University_frontend.Services.DataServices
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using University_frontend.Extensions;
    using University_frontend.Services.DataServices.InputModels;
    using University_frontend.Services.DataServices.ViewModels;

    public class AccountService : BaseService, IAccountService
    {
        public static UserTokensViewModel Credentials;

        public async Task LogIn(LogInCredentialsInputDataModel model)
        {
            var content = HttpHelper.CreateByteContent(model);
            HttpResponseMessage response = await this.client.PostAsync("account/login", content);

            if (!response.IsSuccessStatusCode) throw new Exception();

            Credentials = HttpHelper.GetContent<UserTokensViewModel>(response);
        }
    }
}
