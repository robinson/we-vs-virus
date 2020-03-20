using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using WeVsVirus.Models;
using WeVsVirus.DataAccess.Repositories;
using WeVsVirus.Business.Exceptions;
using WeVsVirus.Business.Utility;
using WeVsVirus.Business.ViewModels;

namespace WeVsVirus.WebApp.Api
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        public AccountController(
            IJwtFactory jwtFactory,
            IOptions<JwtIssuerOptions> jwtOptions,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IMapper mapper)
        {
            //if (jwtOptions == null)
            //{
            //    throw new ArgumentNullException(nameof(jwtOptions));
            //}
            JwtOptions = jwtOptions.Value;
            UserManager = userManager;
            SignInManager = signInManager;
            JwtFactory = jwtFactory;
            Mapper = mapper;
        }


        protected UserManager<AppUser> UserManager { get; }

        protected SignInManager<AppUser> SignInManager { get; }
        protected IJwtFactory JwtFactory { get; }

        protected JwtIssuerOptions JwtOptions { get; }
        protected IMapper Mapper { get; }

        [HttpPost("")]
        [HttpPost("[action]")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> NewUser([FromBody] SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var account = await AccountService.CreateNewUserAsync(model);
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
    }
}
