using System.Collections.Generic;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WeVsVirus.Business.ViewModels;
using WeVsVirus.Models.Entities;
using WeVsVirus.DataAccess;
using WeVsVirus.Business.Utility;
using WeVsVirus.Business.Exceptions;

namespace WeVsVirus.Business.Services
{
    public interface IDriverAccountService
    {
        Task<DriverAccount> CreateNewUserAsync(SignUpDriverViewModel model);
    }
    
    public class DriverAccountService : IDriverAccountService
    {
        public DriverAccountService(
            UserManager<AppUser> userManager,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            UserManager = userManager;
            Mapper = mapper;
        }
        private UserManager<AppUser> UserManager { get; }
        private IUnitOfWork UnitOfWork { get; }
        private IMapper Mapper { get; }

        public async Task<DriverAccount> CreateNewUserAsync(SignUpDriverViewModel model)
        {
            var user = Mapper.Map<AppUser>(model);
            user.EmailConfirmed = true;
            // Need to wrap this in transaction since UserManager is not working properly
            // when AutoSaveChanges=false and called two times (AppUser and Role)
            // => results in foreign key constraint error for Account
            using (var transaction = UnitOfWork.DbContext.Database.BeginTransaction())
            {
                // TODO create random password
                var result = await UserManager.CreateAsync(user, "RANDOMINITIALPASSWORD");
                await UnitOfWork.CompleteAsync();
                if (result.Succeeded)
                {

                    var driverAccount = await UnitOfWork.Repository<DriverAccount>().AddAsync(new DriverAccount { AppUserId = user.Id });
                    result = await UserManager.AddToRoleAsync(user, AccessRoles.DriverUser);
                    await UnitOfWork.CompleteAsync();
                    if (result.Succeeded)
                    {
                        try
                        {
                            // TODO Send email with token to driver
                            // await AccountEmailService.SendAdminOrSupportSignUpMailAsync(supportAccount);
                            await UnitOfWork.CompleteAsync();
                            await transaction.CommitAsync();
                            return driverAccount;
                        }
                        catch
                        {
                            throw new CreateNewUserException();
                        }
                    }
                }
                if (result.Errors.FirstOrDefault(err => err.Code == IdentityErrorCodes.DuplicateUserName || err.Code == IdentityErrorCodes.DuplicateEmail) != null)
                {
                    throw new UserNameAlreadyTakenException();
                }
                else
                {
                    throw new CreateNewUserException(result.Errors.FirstOrDefault()?.Description);
                }
            }
        }
    }
}