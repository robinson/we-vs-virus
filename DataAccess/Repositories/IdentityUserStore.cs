using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WeVsVirus.Models;

namespace WeVsVirus.DataAccess.Repositories
{
    public class IdentityUserStore : UserStore<AppUser>
    {
        public IdentityUserStore(IUnitOfWork unitOfWork, IdentityErrorDescriber describer = null) : base(unitOfWork.DbContext, describer)
        {
            AutoSaveChanges = false;
        }
    }
}
