using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using WeVsVirus.Business.Utility;
using WeVsVirus.Business.ViewModels;
using WeVsVirus.Models.Entities;
using WeVsVirus.Business.Exceptions;

namespace WeVsVirus.Business.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginViewModel loginViewModel);
    }
    public class AuthService : IAuthService
    {
        public AuthService(
            IJwtFactory jwtFactory,
            IOptions<JwtIssuerOptions> jwtOptions,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<AuthService> logger)
        {
            JwtOptions = jwtOptions.Value;
            UserManager = userManager;
            SignInManager = signInManager;
            JwtFactory = jwtFactory;
            Logger = logger;
        }

        private UserManager<AppUser> UserManager { get; }

        private SignInManager<AppUser> SignInManager { get; }

        private IJwtFactory JwtFactory { get; }

        private JwtIssuerOptions JwtOptions { get; }
        private ILogger<AuthService> Logger { get; }

        public async Task<string> LoginAsync(LoginViewModel loginViewModel)
        {
            var result = await SignInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {

                var identity = await GetClaimsIdentity(loginViewModel.Email);
                if (identity == null)
                {
                    throw new InternalServerErrorHttpException("Fehler beim Ausstellen des JWT.");
                }
                var jwt = await JwtTokens.GenerateJwt(identity, JwtFactory, loginViewModel.Email, JwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });

                return jwt;
            }
            else
            {
                if (result.IsLockedOut)
                {
                    throw new AccountLockedHttpException("Account wurde gesperrt, weil das Passwort zu oft falsch eingegeben wurde. Bitte beim Support melden.");
                }
                else
                {
                    throw new InvalidEmailAndPasswordCombinationHttpException();
                }
            }
        }


        private async Task<ClaimsIdentity> GetClaimsIdentity(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                var user = await UserManager.Users.FirstOrDefaultAsync(u => u.Email == email);

                var roles = await UserManager.GetRolesAsync(user);
                if (user != null)
                {
                    return await Task.FromResult(JwtFactory.GenerateClaimsIdentity(email, user.Id, roles.ToArray()));
                }
            }
            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}