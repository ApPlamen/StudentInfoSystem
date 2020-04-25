namespace University.Services
{
    using System.Threading.Tasks;
    using University.InputModels;
    using University.ViewModels;

    public interface IAccountService : IBaseService
    {
        Task<UserTokensViewModel> LoginAsync(LoginUserInputModel model);

        Task<UserTokensViewModel> RefreshTokensAsync(string refreshToken);
    }
}
