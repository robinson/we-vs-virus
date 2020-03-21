using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using WeVsVirus.Models.Entities;
using WeVsVirus.DataAccess.Repositories;
using WeVsVirus.Business.Exceptions;
using WeVsVirus.Business.Utility;
using WeVsVirus.Business.ViewModels;
using WeVsVirus.Business.Services;

namespace WeVsVirus.WebApp.Api
{
    [Route("api/[controller]")]
    public class DriverAccountController : Controller
    {
        public DriverAccountController(
            IJwtFactory jwtFactory,
            IOptions<JwtIssuerOptions> jwtOptions,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            // AccountEmailService notificationService,
            IDriverAccountService driverAccountService,
            IAuthService authService,
            IMapper mapper)
        {
            JwtOptions = jwtOptions.Value;
            UserManager = userManager;
            SignInManager = signInManager;
            JwtFactory = jwtFactory;
            // AccountEmailService = accountEmailService;
            DriverAccountService = driverAccountService;
            AuthService = authService;
            Mapper = mapper;
        }


        // private AccountEmailService AccountEmailService { get; }

        private UserManager<AppUser> UserManager { get; }

        private SignInManager<AppUser> SignInManager { get; }
        private IDriverAccountService DriverAccountService { get; }
        private IAuthService AuthService { get; }
        private IJwtFactory JwtFactory { get; }

        private JwtIssuerOptions JwtOptions { get; }
        private IMapper Mapper { get; }

        [HttpPost("[action]")]
        // TODO only allow for health officess when health office sign up implementation is ready
        // [Authorize(Policy = PolicyNames.HealthOfficeUserPolicy)]
        [AllowAnonymous]
        public virtual async Task<IActionResult> NewUser([FromBody] SignUpDriverViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var account = await DriverAccountService.CreateNewUserAsync(model);
                    return Ok();
                }
                catch (HttpStatusCodeException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    throw new InternalServerErrorHttpException(e);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost("auth")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var jwt = await AuthService.LoginAsync(model);
                    return Ok(jwt);
                }
                catch (HttpStatusCodeException)
                {
                    throw;
                }
                catch
                {
                    throw new InternalServerErrorHttpException("Interner Serverfehler beim Einloggen.");
                }
            }
            return BadRequest(ModelState);
        }
    }
}
