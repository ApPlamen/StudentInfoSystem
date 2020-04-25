namespace University_frontend.Services.DataServices
{
    using System.Threading.Tasks;
    using University_frontend.Services.DataServices.InputModels;

    public interface IAccountService
    {
        Task LogIn(LogInCredentialsInputDataModel model);
    }
}
