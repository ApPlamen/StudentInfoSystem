namespace University.Services
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using University.Common.Authentication;
    using University.DAL.Models;
    using University.InputModels;
    using University.Repository;
    using University.ViewModels;

    public class AccountService : BaseService<User>, IAccountService
    {
        private ITokenService tokenService;
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;

        public AccountService(IMapper mapper,
            IRepository<User> user,
            ITokenService tokenService,
            SignInManager<User> signInManager,
            UserManager<User> userManager)
            : base(mapper, user)
        {
            this.tokenService = tokenService;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<UserTokensViewModel> LoginAsync(LoginUserInputModel model)
        {
            User user = await this.GetUserByEmailAsync(model.Email);

            SignInResult result = await this.signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (result.Succeeded)
            {
                return new UserTokensViewModel()
                {
                    AccessToken = await this.GenerateJwtTokenAsync(user),
                    RefreshToken = this.GenerateRefreshToken(user),
                };
            }

            throw new ArgumentException("WRONG_CREDENTIALS");
        }

        public async Task<UserTokensViewModel> RefreshTokensAsync(string refreshToken)
        {
            try
            {
                this.tokenService.ValidateToken(refreshToken);

                string email = refreshToken.GetClaim(ClaimNames.Email);
                var user = await this.GetUserByEmailAsync(email);

                return new UserTokensViewModel()
                {
                    AccessToken = await this.GenerateJwtTokenAsync(user),
                    RefreshToken = this.GenerateRefreshToken(user),
                };
            }
            catch (SecurityTokenException)
            {
                throw new Exception();//NotAuthorizedException();
            }
        }

        private async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await this.userManager.FindByEmailAsync(email);

            if (user == null)
            {
                throw new ArgumentException("Messages.WRONG_CREDENTIALS");
            }

            var userfull = repo.All()
                .Where(u => u.Id == user.Id)
                .Include(u => u.Role)
                .FirstOrDefault();

            return userfull;
        }

        private async Task<string> GenerateJwtTokenAsync(User user)
        {
            //var userRoles = await this.userManager.GetRolesAsync(user);
            //var userRole = userRoles.FirstOrDefault();

            List<Claim> claims = (await this.userManager.GetClaimsAsync(user)).ToList();

            // Specifically add the jti (nonce), iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:
            claims.AddRange(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimNames.Email, user.Email),
                new Claim(ClaimNames.Role, user.Role.Name),
            });

            return this.tokenService.GenerateJwtToken(claims);
        }

        private string GenerateRefreshToken(User user)
        {
            // You can add other claims here, if you want:
            var claims = new List<Claim>
            {
                new Claim(ClaimNames.UserId, user.Id.ToString()),
                new Claim(ClaimNames.Email, user.Email),
            };

            return this.tokenService.GenerateRefreshJwtToken(claims);
        }
    }
}
