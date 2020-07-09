using Codenation.Challenge.Models;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
 
namespace Codenation.Challenge.Services
{
    public class PasswordValidatorService: IResourceOwnerPasswordValidator
    {
        private readonly CodenationContext _context;
        public PasswordValidatorService(CodenationContext dbContext)
        {
            _context = dbContext;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = _context.Users.Where(u => u.Email == context.UserName
                                              && u.Password == context.Password)
                                     .AsNoTracking()
                                     .FirstOrDefault();

            if (user == null)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid username or password");
            }
            else
            {
                context.Result = new GrantValidationResult(user.Id.ToString(), "custom", UserProfileService.GetUserClaims(user));
            }
            
            return Task.CompletedTask;
        }
     
    }
}