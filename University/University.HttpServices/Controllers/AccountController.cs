namespace University.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using University.InputModels;
    using University.Services;

    [Route("api/account")]
    public class AccountController : BaseServiceController<IAccountService>
    {
        public AccountController(IAccountService service)
            : base(service)
        { }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginUserInputModel model)
        {
            var result = await this.service.LoginAsync(model);

            return this.Ok(result);
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> RefreshAsync(RefreshTokensInputModel model)
        {
            object result = await this.service.RefreshTokensAsync(model.RefreshToken);
            return this.Ok(result);
        }
    }
}
